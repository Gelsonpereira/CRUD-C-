using Microsoft.AspNetCore.Mvc;

namespace Modulo_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("ObterDataHoraAtual")]
        public IActionResult ObterDataHora()
        {
            var obj = new
            {
                Data = DateTime.Now.ToLongDateString(),
                Horas = DateTime.Now.ToLongTimeString()
            };

            return Ok(obj);
        }
        [HttpGet("Apresentar/{nome}")]
        public ActionResult Apresentar(String nome) 
        {
            var mensagem = $"Olá {nome}, seja bem vindo!";

            return Ok(new { mensagem });
        }
    }
}
