using Microsoft.EntityFrameworkCore;
using sistemaAlunos.Data;
using sistemaAlunos.Models;
using sistemaAlunos.Repositorios.Interfaces;

namespace sistemaAlunos.Repositorios
{
    public class AlunoRepossitorio : IAlunoRepositorio
    {
        private readonly SistemaTarefasDBContex _dBContex;
        public AlunoRepossitorio(SistemaTarefasDBContex sistemaTarefasDBContex) 
        {
            _dBContex = sistemaTarefasDBContex;
        }
        public async Task<AlunosCoruja> BuscarPorId(int id)
        {
            return await _dBContex.Aluno_Coruja.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<AlunosCoruja>> BuscarTodosAluno()
        {
            return await _dBContex.Aluno_Coruja.ToListAsync();
        }

        public async Task<AlunosCoruja> Adicionar(AlunosCoruja aluno)
        {
            await _dBContex.Aluno_Coruja.AddAsync(aluno);    
            await _dBContex.SaveChangesAsync();

            return aluno;
        }
        public async Task<AlunosCoruja> Atualizar(AlunosCoruja aluno, int id)
        {
            AlunosCoruja alunoPorID = await BuscarPorId(id);

            if(alunoPorID == null) 
            {
                throw new Exception($"Usuário por ID: {id} não foi encontrado no banco de dados.");
            }

            alunoPorID.nome = aluno.nome;
            alunoPorID.email = aluno.email;

            _dBContex.Aluno_Coruja.Update(alunoPorID);
            await _dBContex.SaveChangesAsync();

            return alunoPorID;
        }
        public async Task<bool> Apagar(int id)
        {
            AlunosCoruja alunoPorID = await BuscarPorId(id);

            if (alunoPorID == null)
            {
                throw new Exception($"Usuário por ID: {id} não foi encontrado no banco de dados.");
            }

            _dBContex.Aluno_Coruja.Remove(alunoPorID);
            await _dBContex.SaveChangesAsync();

            return true;    
        }

        

        
    }
}
