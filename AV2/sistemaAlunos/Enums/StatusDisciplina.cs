using System.ComponentModel;

namespace sistemaAlunos.Enums
{
    public enum StatusDisciplina
    {
        [Description("A FAZER")]
        AFazer = 0,
        [Description("EM ANDAMENTO")]
        EmAndamento = 1,
        [Description("CONCLUIDO")]
        Concluido = 2,

    }
}
