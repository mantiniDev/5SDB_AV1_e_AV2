using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistemaAlunos.Models;
using sistemaAlunos.Repositorios.Interfaces;

namespace sistemaAlunos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosControler : ControllerBase
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunosControler(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<AlunosCoruja>>> BuscarTodosUsuarios()
        {
            List<AlunosCoruja> aluno = await _alunoRepositorio.BuscarTodosAluno();
            return Ok(aluno);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<AlunosCoruja>>> BuscarPorId(int id)
        {
            AlunosCoruja aluno = await _alunoRepositorio.BuscarPorId(id);
            return Ok(aluno);
        }

        [HttpPost]
        public async Task<ActionResult<List<AlunosCoruja>>> Cadastrar([FromBody] AlunosCoruja alunoCoruja)
        {
            AlunosCoruja aluno = await _alunoRepositorio.Adicionar(alunoCoruja);
            return Ok(aluno);
        }

        [HttpPut]
        public async Task<ActionResult<List<AlunosCoruja>>> Atualizar([FromBody] AlunosCoruja alunoCoruja, int id)
        {
            alunoCoruja.Id = id;
            AlunosCoruja aluno = await _alunoRepositorio.Atualizar(alunoCoruja, id);
            return Ok(aluno);
        }

        [HttpDelete]
        public async Task<ActionResult<List<AlunosCoruja>>> Apagar(int id)
        {
            bool apagado = await _alunoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
