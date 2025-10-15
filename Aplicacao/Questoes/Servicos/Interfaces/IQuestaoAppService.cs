

using DataTransfer.Questoes.Response;

namespace Aplicacao.Questoes.Servicos.Interfaces
{
    public interface IQuestaoAppService
    {
        Task<QuestaoResponse> ValidarAsync(int id);
    }
}
