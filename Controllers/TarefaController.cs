using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly OrganizadorContext _context;

        public TarefaController(OrganizadorContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        public IActionResult Criar(Tarefa tarefa)
        {
            if (tarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            _context.Add(tarefa);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
                return NotFound();

            if (tarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Data = tarefa.Data;
            tarefaBanco.Status = tarefa.Status;
            
            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();

            return Ok(tarefaBanco);
        }

        [HttpPatch("{id}")]
        public IActionResult AtualizacaoEspecifica(int id, [FromBody] Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
                return NotFound();

            if (!string.IsNullOrEmpty(tarefa.Titulo) && tarefa.Titulo != tarefaBanco.Titulo)
            {
                tarefaBanco.Titulo = tarefa.Titulo;
            }

            if (!string.IsNullOrEmpty(tarefa.Descricao) && tarefa.Descricao != tarefaBanco.Descricao)
            {
                tarefaBanco.Descricao = tarefa.Descricao;
            }

            if (tarefa.Data != DateTime.MinValue && tarefa.Data != tarefaBanco.Data)
            {
                tarefaBanco.Data = tarefa.Data;
            }

            if (Enum.IsDefined(typeof(EnumStatusTarefa), tarefa.Status) && tarefa.Status != tarefaBanco.Status)
            {
                tarefaBanco.Status = tarefa.Status;
            }

            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();

            return Ok(tarefaBanco);
        }


        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var idBanco = _context.Tarefas.Find(id);

            if (idBanco == null)
            {
                return NotFound(new { Erro = $"Tarefa com ID: {id} não encontrada." });
            }

            return Ok(idBanco);
        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            var todasTarefasDoBanco = _context.Tarefas.ToList();

            if ( !todasTarefasDoBanco.Any() )
            {
                return NotFound();
            
            }


            return Ok(todasTarefasDoBanco);
        }

        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            if (string.IsNullOrEmpty(titulo))
            {
                return BadRequest(new { Erro = "O título não pode ser vazio ou nulo." });
            }

            var tituloBanco = _context.Tarefas.Where(x => x.Titulo.Contains(titulo)).ToList();

            if (!tituloBanco.Any())
            {
                return NotFound();
            }

            return Ok(tituloBanco);
        }

        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            var dataBanco = _context.Tarefas.Where(x => x.Data.Date == data.Date).ToList();

            if (!dataBanco.Any())
            {
                return NotFound(new { Erro = "Nenhuma tarefa encontrada para a data fornecida." });
            }

            return Ok(dataBanco);
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatusTarefa status)
        {
            if (!Enum.IsDefined(typeof(EnumStatusTarefa), status))
            {
                return BadRequest(new { Erro = "Status inválido." });
            }

            var statusBanco = _context.Tarefas.Where(x => x.Status == status).ToList();

            if (!statusBanco.Any())
            {
                return NotFound();
            }

            return Ok(statusBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
            {
                return NotFound();

            }

            _context.Tarefas.Remove(tarefaBanco);
            _context.SaveChanges();
            
            return NoContent();
        }
    }
}
