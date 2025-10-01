using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using atividadeApi.Models.Dtos;
using atividadeApi.Models;

namespace atividadeApi.Controllers
{
    [Route("/Atividade")]
    [ApiController]
    public class AtividadeController : ControllerBase
    {
        private static List<Atividade> _ListaAtividade = new List<Atividade>
        {
            new Atividade()
            {
                Id = 1,
                Descricao = "Atividade 1",
                DataAbertura = new DateTime(2025, 09, 03),
                DataFechamento = new DateTime(2025, 09, 11)
            }
        };
        private static int _proximoId = 3;

        [HttpGet("{id}/Mostrar Atividade")]
        public IActionResult BuscarTodos()
        {
            return Ok(_ListaAtividade);
        }

        [HttpGet("{id}/Buscar atividade por ID")]
        public IActionResult BuscarPorId(int id)
        {
            var chamado = _ListaAtividade.FirstOrDefault(x => x.Id == id);

            if (chamado == null)
            {
                return NotFound();
            }

            return Ok(chamado);
        }

        
        [HttpPost("{id}/Criar nova atividade")]
        public IActionResult Criar([FromBody] atividadeDto novaAtividade)
        {
            var atividade = new Atividade() { Descricao = novaAtividade.Descricao };

            atividade.Id = _proximoId++;
            _ListaAtividade.Add(atividade);

            return Created("", atividade);
        }

        [HttpPut("{id}/Atualizar atividade")]
        public IActionResult Atulizacao(int id, [FromBody] atividadeDto novaAtividade)
        {
            var atividade = _ListaAtividade.FirstOrDefault(item => item.Id == id);

            if (atividade == null)
            {
                return NotFound();
            }

            atividade.Descricao = novaAtividade.Descricao;
            return Ok(atividade);
        }

        [HttpPut("{id}/status")]
        public IActionResult AtulizarStatus(int id, [FromBody] Atividade Atividade)
        {
            var atividade = _ListaAtividade.FirstOrDefault(item => item.Id == id);

            if (atividade == null)
            {
                return NotFound();
            }

            atividade.Status = Atividade.Status;
            return Ok(atividade.Status);
        }

      
        [HttpPost("{id}/Finalizar")]
        public IActionResult FinalizarAtividade(int id)
        {
            var atividade = _ListaAtividade.FirstOrDefault(x => x.Id == id);

            if (atividade == null)
            {
                return NotFound();
            }

            atividade.Status = "Finalizado";
            return Ok(atividade.Status);
        }

   
        [HttpDelete("{id}/Deletar Atividade")]
        public IActionResult Remover(int id)
        {
            var atividade = _ListaAtividade.FirstOrDefault(x => x.Id == id);

            if (atividade == null)
            {
                return NotFound();
            }

            _ListaAtividade.Remove(atividade);
            return NoContent();
        }
    }
}
