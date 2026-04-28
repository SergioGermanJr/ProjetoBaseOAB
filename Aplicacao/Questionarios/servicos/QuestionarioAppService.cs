

using Aplicacao.Questionarios.servicos.interfaces;
using DataTransfer.Questionarios.Request;
using DataTransfer.Questionarios.Response;
using DataTransfer.Questoes.Response;
using Dominio.Questionarios.Comandos;
using Dominio.Questionarios.Entidades;
using Dominio.Questionarios.Repositorios;
using Dominio.Questionarios.Servicos.interfaces;
using Dominio.Questoes.Entidades;
using Infra.Utils.UnityOfWork.Interface;
using NHibernate.Linq;

namespace Aplicacao.Questionarios.servicos
{
    public class QuestionarioAppService : IQuestionarioAppService
    {
        private readonly IQuestionarioService questionarioService;
        private readonly IQuestionarioRepositorio questionarioRepositorio;
        private readonly IUnitOfWork unitOfWork;

        public QuestionarioAppService(IQuestionarioService questionarioService, IUnitOfWork unitOfWork, IQuestionarioRepositorio questionarioRepositorio)
        {
            this.questionarioService = questionarioService;
            this.unitOfWork = unitOfWork;
            this.questionarioRepositorio = questionarioRepositorio;
        }

        public async Task<QuestionarioResponse> CriarAsync(int QuantidadeQuestoes)
        {
            try
            {
                unitOfWork.BeginTransaction();
                Questionario questionario = await questionarioService.InserirAsync(QuantidadeQuestoes);
                QuestionarioResponse response = new QuestionarioResponse
                {
                    Id = questionario.Id,
                    DataInicio = questionario.DataInicio,
                    Porcentagem = questionario.Porcentagem,
                    Status = questionario.Status,
                    Questoes = questionario.Questoes
                    .Select(x => new QuestionarioQuestaoResponse
                    {
                        questaoId = x.Questao.Id,         
                        respostaQuestaoId = x?.Resposta?.Id
                    })
                    .ToList()
                };
                await unitOfWork.CommitAsync();
                return response;
             }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public async Task<QuestionarioResponse> Recuperar(int codigo)
        {
            Questionario questionario = await this.questionarioService.ValidarAsync(codigo);
            QuestionarioResponse response = new QuestionarioResponse
            {
                Id = questionario.Id,
                DataInicio = questionario.DataInicio,
                Porcentagem = questionario.Porcentagem,
                Status = questionario.Status,
                Questoes = questionario.Questoes
                    .Select(x => new QuestionarioQuestaoResponse
                    {
                        questaoId = x.Questao.Id,
                        respostaQuestaoId = x.Resposta?.Id
                    })
                    .ToList()
            };
            return response;

        }
        public async Task<List<QuestionarioResponse>> ListarQuestionarios()
        {
            try
            {
                unitOfWork.BeginTransaction();
                List<Questionario> questionarios = await this.questionarioRepositorio.Query().ToListAsync();
                List<QuestionarioResponse> response = questionarios
                .Select(q => new QuestionarioResponse
                {
                    Id = q.Id,
                    Porcentagem = q.Porcentagem,
                    DataInicio = q.DataInicio,
                    Status = q.Status,
                    Questoes = q.Questoes
                    .Select(x => new QuestionarioQuestaoResponse
                    {
                        questaoId = x.Questao.Id,          
                        respostaQuestaoId = x.Resposta?.Id
                    })
                    .ToList()
                })
                .ToList();

                await unitOfWork.CommitAsync();
                return response;
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public async Task<QuestionarioQuestaoResponse> ResponderQuestao(QuestionarioResponderQuestaoRequest request)
        {
            try
            {
                ResponderQuestaoComando comando = new ResponderQuestaoComando { 
                    questaoId = request.questaoId,
                    questionarioId = request.questionarioId,
                    respostaQuestaoId = request.respostaQuestaoId
                };  
                unitOfWork.BeginTransaction();

                QuestionarioQuestao questionarioQuestao = await this.questionarioService.ResponderQuestao(comando);

                await unitOfWork.CommitAsync();

                return new QuestionarioQuestaoResponse { questaoId = questionarioQuestao.Questao.Id, respostaQuestaoId = questionarioQuestao.Resposta.Id };
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public async Task<QuestionarioResponse> FinalizarQuestionarioAsync(int QuestionarioId)
        {
            try
            {
                unitOfWork.BeginTransaction();

                Questionario questionario = await this.questionarioService.FinalizarQuestionario(QuestionarioId);

                QuestionarioResponse response = new QuestionarioResponse
                {
                    Id = questionario.Id,
                    Porcentagem = questionario.Porcentagem,
                    DataInicio = questionario.DataInicio,
                    Status = questionario.Status,
                    Questoes = questionario.Questoes
                    .Select(x => new QuestionarioQuestaoResponse
                    {
                        questaoId = x.Questao.Id,
                        respostaQuestaoId = x.Resposta?.Id
                    })
                    .ToList()
                };

                await unitOfWork.CommitAsync();

                return response;

            }
            catch 
            {
                unitOfWork.Rollback();
                throw;
            }
        }
    }
}
