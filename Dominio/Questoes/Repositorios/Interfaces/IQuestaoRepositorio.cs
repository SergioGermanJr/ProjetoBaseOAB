using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Questoes.Entidades;

namespace Dominio.Questoes.Repositorios.Interfaces
{
    public interface IQuestaoRepositorio
    {
        IEnumerable<Questao> Query();

        Task<Questao> RecuperarAsync(int id);
    }
}
