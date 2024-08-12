using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DALL.Repositories._GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {

        Task<T> GetById(int id);

        Task<IEnumerable<T>> GetAll();

        Task<bool> Create(T entity);

        Task<bool> Update(T entity);

        Task<bool> Delete(T entity);

    }
}




