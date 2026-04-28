using Dominio.Questionarios.Entidades;
using Dominio.Questionarios.Repositorios;
using Infra.Utils.Repositorios;
using NHibernate;

namespace Infra.Questionarios.Repositorios
{
    public class QuestionarioRepositorio : NhibernateRepositorio<Questionario>, IQuestionarioRepositorio
    {
        public QuestionarioRepositorio(ISession session) : base(session)
        {
        }
    }
}
