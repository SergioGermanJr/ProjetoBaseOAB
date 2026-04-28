
using Dominio.Questionarios.Comandos;
using Dominio.Questionarios.Entidades;

namespace Dominio.Questionarios.Servicos.interfaces
{
    public interface IQuestionarioService
    {
        public Task<Questionario> ValidarAsync(int id);
        public Task<Questionario> InserirAsync(int QuantiodadeQuestoes);
        public Task<QuestionarioQuestao> ResponderQuestao(ResponderQuestaoComando comando);
        public Task<Questionario> FinalizarQuestionario(int QuestionarioId);
    }
}
