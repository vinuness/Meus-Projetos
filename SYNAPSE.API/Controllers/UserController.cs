using Microsoft.AspNetCore.Mvc;
using SYNAPSE.API.Docente;
using SYNAPSE.API.Model;

namespace SYNAPSE.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        DOCENTEBLL docbll = new();

        [HttpPost("cadastro")]
        public IActionResult InserirDocentes([FromBody] DocenteModel docente)
        {
            try
            {
                docbll.InserirDocente(docente);
                return Ok("Docente inserido com sucesso.");
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public List<DocenteModel> ListarDocentes()
        {
            DOCENTEBLL docbll = new();
            return docbll.ListarDocentes();
        }

        [HttpDelete("logout")]
        public IActionResult DeletarDoncente(int id)
        {
            DOCENTEBLL bll = new();
            try
            {
                bll.DeletarDoncente(id);
                return StatusCode(204);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {
            DOCENTEBLL bll = new();
            try
            {
                bll.Login(login);
                return Ok($"Login Feito com Sucesso");
            }
            catch
            {
                throw;
            }
        }
    }
}