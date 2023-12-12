using Microsoft.EntityFrameworkCore;
using sistemaAlunos.Data.Map;
using sistemaAlunos.Models;

namespace sistemaAlunos.Data
{
    public class SistemaTarefasDBContex : DbContext
    {
        public SistemaTarefasDBContex(DbContextOptions<SistemaTarefasDBContex> Options) : base(Options)
        {
        }

        public DbSet<AlunosCoruja> corujaAlunos { get; set; }        
        public DbSet<DisciplinaCoruja> corujaDisciplina { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new DisciplinaMap());
            base.OnModelCreating(modelBuilder);
        }

    } 
}
