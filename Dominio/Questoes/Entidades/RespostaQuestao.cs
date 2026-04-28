
namespace Dominio.Questoes.Entidades
{
    public class RespostaQuestao
    {
        public virtual int Id { get; protected set; }
        public virtual Questao Questao { get; protected set; }
        public virtual string Texto { get; protected set; }
        public virtual bool Certa { get; protected set; }

        protected RespostaQuestao() { }

        public virtual void SetTexto(string texto)
        {
            if(texto == null || texto.Trim() == "")
                throw new Exception("Texto da resposta não pode ser vazio");
            Texto = texto;
        }

        public virtual void SetCerta(bool certa)
        {
            Certa = certa;
        }

        public virtual void SetQuestao(Questao questao)
        {
            if(questao == null)
                throw new Exception("Questão não pode ser nula");
            Questao = questao;
        }

        public RespostaQuestao(Questao questao, string texto,  bool certa)
        {
            SetQuestao(questao);
            SetTexto(texto);
            SetCerta(certa);
        }
    }
}
