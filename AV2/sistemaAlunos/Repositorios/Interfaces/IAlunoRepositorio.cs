using sistemaAlunos.Models;

namespace sistemaAlunos.Repositorios.Interfaces
{
    public interface IAlunoRepositorio
    {
        Task<List<AlunosCoruja>> BuscarTodosAluno();
        Task<AlunosCoruja> BuscarPorId(int id);
        Task<AlunosCoruja> Adicionar(AlunosCoruja aluno);
        Task<AlunosCoruja> Atualizar(AlunosCoruja aluno, int id);
        Task<bool> Apagar(int id);
    }
}
