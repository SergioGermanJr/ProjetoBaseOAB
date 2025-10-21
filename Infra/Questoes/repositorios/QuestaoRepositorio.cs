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

        public async Task<List<Questao>> BuscarQuestoesPorTexto(string texto)
        {
            texto = texto.Trim().Length >= 100 ? texto.Trim().Substring(0, 100) : texto.Trim();
            return await Query().Where(x => (x.Texto.Trim().Length >= 100 ? x.Texto.Trim().Substring(0, 100) : x.Texto) == texto).ToListAsync();
        }

        public async Task<Questao> QuestaoAleatoria()
        {
            List<int> ids = session.Query<Questao>()
                .Select(q => q.Id)
                .ToList();

            Random random = new Random();
            int idAleatorio = ids[random.Next(ids.Count)];

            return await this.RecuperarAsync(idAleatorio);

            
        }
    }
}
