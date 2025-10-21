
using Dominio.Questionarios.Entidades;

namespace Dominio.Questionarios.Servicos.interfaces
{
    public interface IQuestionarioQuestaoService
    {
        Task<QuestionarioQuestao> InstanciarAsync(Questionario questionario);
    }
}
