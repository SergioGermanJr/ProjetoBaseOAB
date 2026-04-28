using Dominio.Questionarios.Entidades;
using Dominio.Questoes.Entidades;

namespace DataTransfer.Questionarios.Request
{
    public class QuestionarioResponderQuestaoRequest
    {
        public int questionarioId { get; set; }
        public int questaoId { get; set; }
        public int respostaQuestaoId { get; set; }
    }
}
