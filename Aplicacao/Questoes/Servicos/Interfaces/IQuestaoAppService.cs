

using DataTransfer.Questoes.Requests;
using DataTransfer.Questoes.Response;

namespace Aplicacao.Questoes.Servicos.Interfaces
{
    public interface IQuestaoAppService
    {
        Task<QuestaoResponse> ValidarAsync(int id);
        Task<QuestaoResponse> InserirAsync(QuestaoInserirRequest request);
    }
}
