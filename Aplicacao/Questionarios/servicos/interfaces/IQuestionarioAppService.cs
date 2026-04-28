

using DataTransfer.Questionarios.Request;
using DataTransfer.Questionarios.Response;

namespace Aplicacao.Questionarios.servicos.interfaces
{
    public interface IQuestionarioAppService
    {
        Task<QuestionarioResponse> CriarAsync(int QuantidadeQuestoes);
        Task<QuestionarioQuestaoResponse> ResponderQuestao(QuestionarioResponderQuestaoRequest request);
        Task<QuestionarioResponse> FinalizarQuestionarioAsync(int QuestionarioId);
        Task<List<QuestionarioResponse>> ListarQuestionarios();
        Task<QuestionarioResponse> Recuperar(int codigo);
    }
}
