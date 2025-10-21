
using Dominio.Questionarios.Entidades;

namespace Dominio.Questionarios.Servicos.interfaces
{
    public interface IQuestionarioService
    {
        public Task<Questionario> ValidarAsync(int id);
        public Task<Questionario> InserirAsync(int QuantiodadeQuestoes);
    }
}
