
using NHibernate;
using ISession = NHibernate.ISession;

namespace Infra.Utils.Repositorios
{
    public class NhibernateRepositorio<T> where T : class
    {
        protected readonly ISession session;
        public NhibernateRepositorio(ISession session)
        {
            this.session = session;
        }
        public virtual IQueryable<T> Query()
        {
            return session.Query<T>();
        }
        public virtual Task<T> RecuperarAsync(int id)
        {
            return session.GetAsync<T>(id);
        }
        public virtual async Task<T> SalvarAsync(T entidade)
        {
            await session.SaveOrUpdateAsync(entidade);
            return entidade;
        }
        public virtual async Task DeletarAsync(T entidade)
        {
            await session.DeleteAsync(entidade);
        }
    }
}
