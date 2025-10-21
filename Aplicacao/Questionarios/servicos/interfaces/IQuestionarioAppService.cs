

using DataTransfer.Questionarios.Response;

namespace Aplicacao.Questionarios.servicos.interfaces
{
    public interface IQuestionarioAppService
    {
        Task<QuestionarioResponse> CriarAsync(int QuantidadeQuestoes);
    }
}
