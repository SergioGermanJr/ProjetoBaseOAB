

using Dominio.Questionarios.Entidades;
using Dominio.Questionarios.Repositorios;
using Dominio.Questionarios.Servicos.interfaces;
using Dominio.Questoes.Entidades;
using Dominio.Questoes.Repositorios.Interfaces;

namespace Dominio.Questionarios.Servicos
{
    public class QuestionarioQuestaoService : IQuestionarioQuestaoService
    {
        private readonly IQuestionarioQuestaoRepositorio questionarioQuestaoRepositorio;
        private readonly IQuestaoRepositorio questaoRepositorio;

        public QuestionarioQuestaoService(IQuestionarioQuestaoRepositorio questionarioQuestaoRepositorio, IQuestaoRepositorio questaoRepositorio)
        {
            this.questionarioQuestaoRepositorio = questionarioQuestaoRepositorio;
            this.questaoRepositorio = questaoRepositorio;
        }

        public async Task<QuestionarioQuestao> InstanciarAsync(Questionario questionario)
        {
            Questao questao = await this.questaoRepositorio.QuestaoAleatoria();
            QuestionarioQuestao questionarioQuestao = new(questao, questionario);
            return questionarioQuestao;

        }
    }
}
