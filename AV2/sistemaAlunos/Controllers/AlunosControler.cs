using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistemaAlunos.Models;

namespace sistemaAlunos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosControler : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<AlunosCoruja>> BuscarTodosUsuarios() 
        {
            return Ok();
        }
    }
}
