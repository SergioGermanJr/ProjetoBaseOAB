

using Aplicacao.Questionarios.servicos.interfaces;
using DataTransfer.Questionarios.Response;
using DataTransfer.Questoes.Response;
using Dominio.Questionarios.Entidades;
using Dominio.Questionarios.Servicos.interfaces;
using Infra.Utils.UnityOfWork.Interface;

namespace Aplicacao.Questionarios.servicos
{
    public class QuestionarioAppService : IQuestionarioAppService
    {
        private readonly IQuestionarioService questionarioService;
        private readonly IUnitOfWork unitOfWork;

        public QuestionarioAppService(IQuestionarioService questionarioService, IUnitOfWork unitOfWork)
        {
            this.questionarioService = questionarioService;
            this.unitOfWork = unitOfWork;
        }

        public async Task<QuestionarioResponse> CriarAsync(int QuantidadeQuestoes)
        {
            try
            {
                unitOfWork.BeginTransaction();
                Questionario questionario = await questionarioService.InserirAsync(QuantidadeQuestoes);
                QuestionarioResponse response = new QuestionarioResponse
                {
                    DataInicio = questionario.DataInicio,
                    Status = questionario.Status,
                    Questoes = questionario.Questoes
                                .Select(qq => new QuestaoResponse
                                {
                                    Texto = qq.Questao.Texto
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
