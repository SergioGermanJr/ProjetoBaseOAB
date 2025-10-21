
using Dominio.Questionarios.Enumeradores;

namespace Dominio.Questionarios.Entidades
{
    public class Questionario
    {
        public virtual int Id { get; protected set; }
        public virtual DateTime? DataInicio { get; protected set; }
        public virtual StatusQuestionarioEnum Status { get; protected set; }
        public virtual int Porcentagem { get; protected set; }
        public virtual DateTime? DataConclusao { get; protected set; }
        public virtual IList<QuestionarioQuestao> Questoes { get; protected set; } = new List<QuestionarioQuestao>();

        public Questionario(){
            SetStatus(StatusQuestionarioEnum.Andamento);
            SetPorcentagem(0);
            DataInicio = DateTime.Now;
        }
        public virtual void SetStatus(StatusQuestionarioEnum Status){ 
            this.Status = Status;
        }
        public virtual void SetPorcentagem(int porcentagem) {  
            this.Porcentagem = porcentagem;
        }
        public virtual void SetDataConclusao(DateTime? dataConclusao) { 
            this.DataConclusao = dataConclusao;
        }
    }

    
}
