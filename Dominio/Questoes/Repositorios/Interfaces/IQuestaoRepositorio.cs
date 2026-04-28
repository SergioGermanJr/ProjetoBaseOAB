using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Questoes.Entidades;
using Dominio.Utils.Repositorios;

namespace Dominio.Questoes.Repositorios.Interfaces
{
    public interface IQuestaoRepositorio: INhibernateRepositorio<Questao>
    {
        public Task<List<Questao>> BuscarQuestoesPorTexto(string texto);

        Task<Questao> QuestaoAleatoria();
    }
}
