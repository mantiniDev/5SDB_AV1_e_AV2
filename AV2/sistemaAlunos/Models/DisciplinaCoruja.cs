using sistemaAlunos.Enums;

namespace sistemaAlunos.Models
{
    public class DisciplinaCoruja
    {
        public int Id { get; set; }
        public string? name { get; set; }
        public string? Descricao { get; set; }
        public StatusDisciplina Status { get; set; }
    }
}