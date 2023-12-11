using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemaAlunos.Models;

namespace sistemaAlunos.Data.Map
{
    public class DisciplinaMap : IEntityTypeConfiguration<DisciplinaCoruja>
    {
        public void Configure(EntityTypeBuilder<DisciplinaCoruja> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descricao).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();

        }
    }
}
