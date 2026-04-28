using Dominio.Questoes.Entidades;

namespace Dominio.Questionarios.Entidades
{
    public class QuestionarioQuestao
    {
        public virtual int Id { get; protected set; }
        public virtual Questao Questao { get; protected set; }
        public virtual Questionario Questionario { get; protected set; }
        public virtual RespostaQuestao? Resposta { get; protected set; }
        protected QuestionarioQuestao() { }

        public QuestionarioQuestao(Questao questao, Questionario questionario)
        {
            SetQuestao(questao);
            SetQuestionario(questionario);
        }
        public virtual void SetQuestao(Questao questao) { 
            this.Questao = questao;
        }
        public virtual void SetQuestionario(Questionario questionario) { 
            this.Questionario = questionario;
        }
        public virtual void SetResposta(RespostaQuestao resposta)
        {
            this.Resposta = resposta;
        }



    }

    
}
