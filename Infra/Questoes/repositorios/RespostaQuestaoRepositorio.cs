

using Dominio.Questoes.Entidades;
using Dominio.Questoes.Repositorios.Interfaces;
using Infra.Utils.Repositorios;
using NHibernate;

namespace Infra.Questoes.repositorios
{
    public class RespostaQuestaoRepositorio : NhibernateRepositorio<RespostaQuestao>, IRespostaQuestaoRepositorio
    {
        public RespostaQuestaoRepositorio(ISession session) : base(session)
        {
        }
    }
}
