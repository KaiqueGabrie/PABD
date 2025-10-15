using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIservico.Models.Dtos;
using APIservico.Models;
using APIservico.DataContexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace APIservico.Controllers
{
    [Route("/chamados")]
    [ApiController]
    public class ChamadoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChamadoController(AppDbContext context)
        {
            _context = context;
        }

        private static List<Chamado> _listaChamados = new List<Chamado>
        {
        //    //new Chamado() {Id = 1, Titulo = "Erro na Tela de Acesso", Descricao = "O usuário não conseguiu logar"},
        //    //new Chamado() {Id = 2, Titulo = "Sistema com lentidão", Descricao = "Demora no carregamento das telas"}
        };
         

        [HttpGet] // Buscar todos chamados
        public async Task<IActionResult> BuscarTodos([FromQuery] string? search, [FromQuery] string? situacao)
        {


            var query = _context.Chamados.AsQueryable();

            //List<Chamado> chamados;
            if(search is not null) // Buscar por Título
            {
                query = query.Where(x => x.Titulo.Contains(search));

                // Pode ser utilizado, porém poderá ter que duplicar mais códigos.
                //chamados = await _context.Chamados.Where(x => x.Titulo.Contains(search)).ToListAsync();
                //return Ok(chamados);
            }
            if (situacao is not null) // Busca por situação
            { 
                query = query.Where(x => x.Status.Equals(situacao));

            }

            var chamados = await query
                .Include(p => p.Prioridade)
                .Select(c => new
            {
                c.Id,
                c.Titulo,
                c.Status,
                Prioridade = new {c.Prioridade.Nome}
            })
                .ToListAsync();
            return Ok(chamados);

            //var chamados = await _context.Chamados.ToListAsync();
            //return Ok(chamados);
        }

        [HttpGet("{id}")] // Buscar por ID
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var chamado = await _context.Chamados.FirstOrDefaultAsync(x => x.Id == id);
            
            if(chamado is null)
            {
                return NotFound();
            }

            return Ok(chamado);
            //var chamado = _listaChamados.FirstOrDefault(x => x.Id == id);// busca o chamado do id, ou se não houver retorna nulo.
            //if (chamado == null)
            //{
            //    return NotFound();
            //}
            //return Ok(chamado); // se não for nulo, vai retornar o chamado por completo.
        }

        [HttpPost] // Criar novo Chamado
        public async Task<IActionResult> Criar([FromBody] ChamadoDto novoChamado) // criado o chamadoDto somente para não puxar id e status, puxar apenas titulo e descrição.
        {
            var prioridade = await _context.Prioridades.FirstOrDefaultAsync(x => x.Id == novoChamado.PrioridadeId);
            if(prioridade is null)
            {
                return NotFound("Prioridade informado não encontrada");
            }

            var chamado = new Chamado() { Titulo = novoChamado.Titulo, Descricao = novoChamado.Descricao, PrioridadeId = novoChamado.PrioridadeId };

            await _context.Chamados.AddAsync(chamado);
            await _context.SaveChangesAsync();

            //chamado.Id = _proximoId++;
            //chamado.Status = "Aberto";
            //_listaChamados.Add(chamado);
            return Created("", chamado);
        }
        [HttpPut("{id}")] // PUT Atualizar Chamado
        public async Task<IActionResult> Atualizar(int id, [FromBody] ChamadoDto atualizacaoChamado)
        {
            var chamado = await _context.Chamados.FirstOrDefaultAsync(x => x.Id == id);

            if (chamado is null)
            {
                return NotFound();
            }

            chamado.Titulo = atualizacaoChamado.Titulo;
            chamado.Descricao = atualizacaoChamado.Descricao;

            _context.Chamados.Update(chamado);
            await _context.SaveChangesAsync();

            return Ok(chamado);
            //var chamado = _listaChamados.FirstOrDefault(x => x.Id == id);// busca o chamado do id, ou se não houver retorna nulo.
            //if (chamado == null)
            //{
            //    return NotFound();
            //}
            //chamado.Titulo = novoChamado.Titulo;
            //chamado.Descricao = novoChamado.Descricao;
            //chamado.Status = chamado.Status;

            //return Ok(chamado); // se não for nulo, vai retornar o chamado por completo.
        }

        [HttpPut("{id}/Fechar-Chamado")] // Fechar Chamado                                             
        public IActionResult FecharChamado(int id)
        {
            var chamado = _listaChamados.FirstOrDefault(x => x.Id == id);// busca o chamado do id, ou se não houver retorna nulo.
            if (chamado == null)
            {
                return NotFound();
            }
            chamado.Status = "Fechado";
            chamado.DataFechamento = DateTime.Now;

            return Ok(chamado.Status); // se não for nulo, vai retornar o chamado por completo.
        }


        [HttpDelete("{id}")] // Deletar Chamado
        public IActionResult Remover(int id)
        {

            //var chamado = _listaChamados.FirstOrDefault(x => x.Id == id);// busca o chamado do id, ou se não houver retorna nulo.
            //if (chamado == null)
            //{
            //    return NotFound();
            //}
            
            //_listaChamados.Remove(chamado);

            return NoContent();
        }
    }
}
