namespace Dominio.Questoes
{
    public class Questao
    {
        public virtual int Id { get; protected set; }
        public virtual string Texto { get; protected set; }
        protected Questao() { }

        public Questao(string texto) {
            setTexto(texto);
        }
        public virtual void setTexto(string texto) { 
            this.Texto = texto;
        }
    }
}
