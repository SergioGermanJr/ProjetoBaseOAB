namespace Dominio.Questoes.Entidades
{
    public class Questao
    {
        public virtual int Id { get; protected set; }
        public virtual string Texto { get; protected set; }
        public virtual IList<RespostaQuestao> Respostas { get; protected set; } = new List<RespostaQuestao>();
        protected Questao() { }

        public Questao(string texto) {
            setTexto(texto);
        }
        public virtual void setTexto(string texto) {
            if (texto == null || texto.Trim() == "")
                throw new Exception("Texto da resposta não pode ser vazio");
            Texto = texto;
        }
    }
}
