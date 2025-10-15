namespace Dominio.Questoes.Entidades
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
            Texto = texto;
        }
    }
}
