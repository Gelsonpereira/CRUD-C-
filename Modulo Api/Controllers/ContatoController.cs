using Microsoft.AspNetCore.Mvc;
using Modulo_Api.Context;
using Modulo_Api.Models;
using System.Runtime.InteropServices;

namespace Modulo_Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;

        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var contato = _context.Contatos.ToList();
            return Ok(contato);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
                return NotFound();

            return Ok(contato);
        }
        [HttpGet("ObterPorNome")]
        public IActionResult ObterContatoPorNome(string nome)
        {
            var contatos = _context.Contatos.Where(c => c.Nome == nome);

            if (contatos == null)
                return NotFound();

            return Ok(contatos);
        }

        [HttpPost("Criar")]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return CreatedAtAction(nameof(AtualizarContato), new { id = contato.Id}, contato);
        }
        [HttpPut("{id}")]
        public IActionResult AtualizarContato(int id, Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(id);
                
            if (contatoBanco == null)
                return NotFound();

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contato);
        }

        [HttpDelete("{id}/Deletar")]
        public IActionResult DeletarContato(int id) 
        {
            var contato = _context.Contatos.Find(id);

            if(contato == null) 
                return NotFound();

            _context.Contatos.Remove(contato);
            _context.SaveChanges();
            return Ok(contato);
        }
    }
}
