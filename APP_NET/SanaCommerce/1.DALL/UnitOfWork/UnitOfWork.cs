using _1.DAL.DataContext;
using _1.DALL.Repositories._Category;
using _1.DALL.Repositories._Customer;
using _1.DALL.Repositories._Order;
using _1.DALL.Repositories._OrderDetail;
using _1.DALL.Repositories._Product;
using _1.DALL.Repositories._ProductoCategory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DALL.UnitOfWork
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly SanaDbContext _context;

        public IRepositoryCategory _repositoryCategory { get; private set; }
        public IRepositoryCustomer _repositoryCustomer { get; private set; }
        public IRepositoryOrder _repositoryOrder { get; private set; }
        public IRepositoryOrderDetail _repositoryOrderDetail { get; private set; }
        public IRepositoryProduct _repositoryProduct { get; private set; }
        public IRepositoryProductCategory _repositoryProductCategory { get; private set; }


        public UnitOfWork(SanaDbContext sanaDbContext,
                           IRepositoryCategory repositoryCategory,
                           IRepositoryCustomer repositoryCustomer,
                           IRepositoryOrder repositoryOrder,
                           IRepositoryOrderDetail repositoryOrderDetail,
                           IRepositoryProduct repositoryProduct,
                           IRepositoryProductCategory repositoryProductCategory
                           )
        {
            this._context = sanaDbContext;
            _repositoryCategory = repositoryCategory;
            this._repositoryCustomer = repositoryCustomer;
            this._repositoryOrder = repositoryOrder;
            this._repositoryOrderDetail = repositoryOrderDetail;
            this._repositoryProduct = repositoryProduct;
            this._repositoryProductCategory = repositoryProductCategory;
        }


        /// <summary>
        /// Free resources and close open connections
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }

        /// <summary>
        /// save changes in contexxt
        /// </summary>
        /// <returns>New elemetnt Id</returns>
        public async Task<int> SaveComplete()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
