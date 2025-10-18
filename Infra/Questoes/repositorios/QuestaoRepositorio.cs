using Dominio.Questoes.Entidades;
using Dominio.Questoes.Repositorios.Interfaces;
using Infra.Utils.Repositorios;
using ISession = NHibernate.ISession;

namespace Infra.Questoes.repositorios
{
    public class QuestaoRepositorio : NhibernateRepositorio<Questao>, IQuestaoRepositorio
    {
        public QuestaoRepositorio(ISession session) : base(session)
        {
        }
    }
}
