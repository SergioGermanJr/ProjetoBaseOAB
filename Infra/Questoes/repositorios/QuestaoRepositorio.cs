using Dominio.Questoes.Entidades;
using Dominio.Questoes.Repositorios.Interfaces;
using ISession = NHibernate.ISession;

namespace Infra.Questoes.repositorios
{
    public class QuestaoRepositorio : IQuestaoRepositorio
    {
        private readonly ISession session;
        public QuestaoRepositorio(ISession session) { 
            this.session = session;
        }

        public IEnumerable<Questao> Query()
        {
            return this.session.Query<Questao>();
        }

        public Task<Questao> RecuperarAsync(int id)
        {
            return this.session.GetAsync<Questao>(id);
        }
    }
}
