using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Atividade_23_09_API.Models.Dtos;
using Atividade_23_09_API.Models;
using Atividade_23_09_API.DataContexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;


namespace Atividade_23_09_API.Controllers
{

    [Route("/Listar-Empresas")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EmpresaController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet] // Buscar empresas por nome, razão ou cnpj
        public async Task<IActionResult> BuscarEmpresas([FromQuery] string? nome)
        {
            var query = _context.dadosEmpresas.AsQueryable();

            if (nome is not null)
            {
                query = query.Where(x => x.Nome.Contains(nome) || x.Razao.Contains(nome) || x.Cnpj.Contains(nome));
            }

            var empresas = await query
            .Select(x => new EmpresasDto
            {
                Razao = x.Razao,
                Nome = x.Nome,
                Cnpj = x.Cnpj,
                Telefone = x.Telefone,
                Email = x.Email
            })
            .ToListAsync();

            return Ok(empresas);
        }

        [HttpPost ("/Criar-Empresa")] // Criar nova empresa
        public async Task<IActionResult> Criar([FromBody] EmpresaCriarDto novaEmpresa)
        {
            var empresa = new Empresa()
            {
                Nome = novaEmpresa.Nome,
                Razao = novaEmpresa.Razao,
                Email = novaEmpresa.Email,
                Cnpj = novaEmpresa.Cnpj,
                Telefone = novaEmpresa.Telefone,
                Inscr_estad = novaEmpresa.Inscr_estad,
                Cidade = novaEmpresa.Cidade,
                Estado = novaEmpresa.Estado,
                Cep = novaEmpresa.Cep,
                Data_cad = DateTime.Now
            };
            await _context.dadosEmpresas.AddAsync(empresa);
            await _context.SaveChangesAsync();
            return Created("", empresa);
        }

        [HttpPut("/Atualizar-Empresa")] // Atualizar empresa
        public async Task<IActionResult> Atualizar(int id, [FromBody] EmpresaCriarDto atualizarEmpresa)
        {
            var empresa = await _context.dadosEmpresas.FirstOrDefaultAsync(x => x.Id == id);//consulta empresa pelo nome
            if(empresa == null) {
                return NotFound();
            }
            empresa.Nome = atualizarEmpresa.Nome;
            empresa.Cnpj = atualizarEmpresa.Cnpj;
            empresa.Razao = atualizarEmpresa.Razao;
            empresa.Inscr_estad = atualizarEmpresa.Inscr_estad;
            empresa.Telefone = atualizarEmpresa.Telefone;
            empresa.Email = atualizarEmpresa.Email;
            empresa.Cidade = atualizarEmpresa.Cidade;
            empresa.Estado = atualizarEmpresa.Estado;
            empresa.Cep = atualizarEmpresa.Cep;

            _context.dadosEmpresas.Update(empresa);
            await _context.SaveChangesAsync();
            return Ok(empresa);

        }

        [HttpDelete("/Deletar-Empresa")]
        public async Task<IActionResult> Remover(int id)
        {
            var empresa = await _context.dadosEmpresas.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }

            _context.dadosEmpresas.Remove(empresa);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}