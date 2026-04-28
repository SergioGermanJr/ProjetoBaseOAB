namespace Dominio.Questoes.comandos
{
    public class QuestaoInserirComando
    {
        public string Texto { get; set; }
        public IList<RespostaQuestaoInserirComando> Respostas { get; set; } = new List<RespostaQuestaoInserirComando>();
    }
}
