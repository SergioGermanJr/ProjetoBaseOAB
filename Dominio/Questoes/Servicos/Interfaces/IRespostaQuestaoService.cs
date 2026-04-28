using Dominio.Questoes.comandos;
using Dominio.Questoes.Entidades;

namespace Dominio.Questoes.Servicos.Interfaces
{
    public interface IRespostaQuestaoService
    {
        Task<RespostaQuestao> ValidarAsync(int id);

    }
}
