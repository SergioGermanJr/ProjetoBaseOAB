
using Dominio.Questoes.comandos;
using Dominio.Questoes.Entidades;

namespace Dominio.Questoes.Servicos.Interfaces
{
    public interface IQuestaoService
    {
        Task<Questao> ValidarAsync(int id);
        Task<Questao> InserirAsync(QuestaoInserirComando comando);
    }
}
