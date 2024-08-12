using _1.DALL.Repositories._GenericRepository;
using _3.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DALL.Repositories._Product
{
    public interface IRepositoryProduct:IGenericRepository<Product>
    {

        Task<IEnumerable<Product>> GetAllProductsCat();

    }
}
