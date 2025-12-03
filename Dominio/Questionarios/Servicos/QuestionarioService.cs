
using Dominio.Questionarios.Comandos;
using Dominio.Questionarios.Entidades;
using Dominio.Questionarios.Enumeradores;
using Dominio.Questionarios.Repositorios;
using Dominio.Questionarios.Servicos.interfaces;
using Dominio.Questoes.Entidades;

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

        public async Task<QuestionarioQuestao> ResponderQuestao(ResponderQuestaoComando comando)
        {
            Questionario questionario = await this.ValidarAsync(comando.questionarioId);

            QuestionarioQuestao? questionarioQuestao = questionario.Questoes.FirstOrDefault(x => x.Questao.Id == comando.questaoId);
            if (questionarioQuestao == null) {
                throw new Exception("Questão não pertence ao questionario");
            }

            RespostaQuestao? resposta = questionarioQuestao.Questao.Respostas.FirstOrDefault(x => x.Id == comando.respostaQuestaoId);

            if (resposta == null) {
                throw new Exception("Resposta invalida");
            }
            questionarioQuestao.SetResposta(resposta);

            return await this.questionarioQuestaoService.AtualizarAsync(questionarioQuestao);

        }

         
        public async Task<Questionario> FinalizarQuestionario(int QuestionarioId)
        {
            Questionario questionario = await ValidarAsync(QuestionarioId);

            if(questionario.Status != StatusQuestionarioEnum.Andamento)
            {
                throw new Exception("Questionario nao esta em andamento");
            }
            if(questionario.Questoes.Count(x => x.Resposta == null) > 0)
            {
                throw new Exception("Não foram respodidas todas as questoes");
            }
            questionario.SetStatus(StatusQuestionarioEnum.Completo);
            questionario.SetDataConclusao(DateTime.Now);
            double total = questionario.Questoes.Count();
            double certas = questionario.Questoes.Count(x => x.Resposta.Certa);
            questionario.SetPorcentagem((certas / total) * 100);
            await questionarioRepositorio.SalvarAsync(questionario);
            return questionario;
        }
    }
}
