

using Dominio.Questionarios.Entidades;
using Dominio.Questionarios.Repositorios;
using Infra.Utils.Repositorios;
using NHibernate;

namespace Infra.Questionarios.Repositorios
{
    public class QuestionarioQuestaoRepositorio : NhibernateRepositorio<QuestionarioQuestao>, IQuestionarioQuestaoRepositorio
    {
        public QuestionarioQuestaoRepositorio(ISession session) : base(session)
        {
        }
    }
}
