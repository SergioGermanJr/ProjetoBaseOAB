
using Dominio.Questionarios.Entidades;
using Dominio.Questionarios.Repositorios;
using Dominio.Questionarios.Servicos.interfaces;

namespace Dominio.Questionarios.Servicos
{
    public class QuestionarioService : IQuestionarioService
    {
        private readonly IQuestionarioRepositorio questionarioRepositorio;
        private readonly IQuestionarioQuestaoService questionarioQuestaoService;
        public QuestionarioService(IQuestionarioRepositorio questionarioRepositorio, IQuestionarioQuestaoService questionarioQuestaoService)
        {
            this.questionarioRepositorio = questionarioRepositorio;
            this.questionarioQuestaoService = questionarioQuestaoService;
        }
        public async Task<Questionario> InserirAsync(int QuantiodadeQuestoes)
        {
            Questionario questionario = new Questionario();
            for (int i = 0; i < QuantiodadeQuestoes; i++) {
                QuestionarioQuestao questionarioQuestao;
                bool Contem;
                do
                {
                    questionarioQuestao = await this.questionarioQuestaoService.InstanciarAsync(questionario);

                    Contem = questionario.Questoes.Any(x => x.Questao.Id == questionarioQuestao.Questao.Id);

                } while (Contem);
                questionario.Questoes.Add(questionarioQuestao);
            }
            await this.questionarioRepositorio.SalvarAsync(questionario);
            return questionario;
        }

        public async Task<Questionario> ValidarAsync(int id)
        {
            Questionario questionario = await this.questionarioRepositorio.RecuperarAsync(id);
            if (questionario == null) {
                throw new Exception("Questionario não encontrada");
            }
            return questionario;

        }
    }
}
