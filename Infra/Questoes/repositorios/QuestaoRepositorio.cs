using Dominio.Questoes.Entidades;
using Dominio.Questoes.Repositorios.Interfaces;
using Infra.Utils.Repositorios;
using NHibernate.Linq;
using ISession = NHibernate.ISession;

namespace Infra.Questoes.repositorios
{
    public class QuestaoRepositorio : NhibernateRepositorio<Questao>, IQuestaoRepositorio
    {
        public QuestaoRepositorio(ISession session) : base(session)
        {
        }

        public Task<List<Questao>> BuscarQuestoesPorTexto(string texto)
        {
            texto = texto.Trim().Length >= 100 ? texto.Trim().Substring(0, 100) : texto.Trim();
            return Query().Where(x => (x.Texto.Trim().Length >= 100 ? x.Texto.Trim().Substring(0, 100) : x.Texto) == texto).ToListAsync();
        }
    }
}
