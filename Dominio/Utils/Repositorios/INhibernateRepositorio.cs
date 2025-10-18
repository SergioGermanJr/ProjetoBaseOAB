using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Dominio.Utils.Repositorios
{
    public interface INhibernateRepositorio<T> where T : class
    {
        IQueryable<T> Query();

        Task<T> RecuperarAsync(int id);

        Task SalvarAsync(T entidade);

        Task DeletarAsync(T entidade);

        Task CommitAsync();
    }
}
