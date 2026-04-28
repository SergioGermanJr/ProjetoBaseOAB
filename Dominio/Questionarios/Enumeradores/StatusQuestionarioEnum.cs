using System.ComponentModel;

namespace Dominio.Questionarios.Enumeradores
{
    public enum StatusQuestionarioEnum
    {
        [Description("Em andamento")]
        Andamento = 0,

        [Description("Completo")]
        Completo = 1,

        [Description("Cancelado")]
        Cancelado = 2
    }
}
