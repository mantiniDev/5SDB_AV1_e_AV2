using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemaAlunos.Models;

namespace sistemaAlunos.Data.Map
{
    public class AlunoMap : IEntityTypeConfiguration<AlunosCoruja>
    {
        public void Configure(EntityTypeBuilder<AlunosCoruja> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.email).IsRequired().HasMaxLength(128);
        }
    }
}
