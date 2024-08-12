using _1.DALL.Repositories._Category;
using _1.DALL.Repositories._Customer;
using _1.DALL.Repositories._Order;
using _1.DALL.Repositories._OrderDetail;
using _1.DALL.Repositories._Product;
using _1.DALL.Repositories._ProductoCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DALL.UnitOfWork
{
    public interface IUnitOfWork :IDisposable
    {

        IRepositoryCategory _repositoryCategory { get; }
        IRepositoryCustomer _repositoryCustomer { get; }
        IRepositoryOrder _repositoryOrder { get; }
        IRepositoryOrderDetail _repositoryOrderDetail { get; }
        IRepositoryProduct _repositoryProduct { get; }
        IRepositoryProductCategory _repositoryProductCategory { get; }

        Task<int> SaveComplete();

    }
}
