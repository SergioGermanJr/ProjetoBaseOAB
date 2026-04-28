

using DataTransfer.Questoes.Response;
using Dominio.Questionarios.Entidades;
using Dominio.Questionarios.Enumeradores;

namespace DataTransfer.Questionarios.Response
{
    public class QuestionarioResponse
    {
        public virtual int? Id { get; set; }
        public virtual DateTime? DataInicio { get;  set; }
        public virtual double? Porcentagem { get; set; }
        public virtual StatusQuestionarioEnum Status { get; set; }
        public virtual List<QuestionarioQuestaoResponse>? Questoes { get; set; }
    }
}
