using _1.DAL.DataContext;
using _1.DALL.Repositories._Customer;
using _1.DALL.Repositories._GenericRepository;
using _3.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DALL.Repositories._Product
{
    public class RepositoryProduct: GenericRepository<Product>, IRepositoryProduct
    {

        private readonly SanaDbContext _context;

        public RepositoryProduct(SanaDbContext context) : base(context)
        {
            this._context = context;
        }


        public async Task<IEnumerable<Product>> GetAllProductsCat()
        {
            var resp = await _context.Products
                                            .Include(p => p.ProductCategories)
                                            .ThenInclude(c => c.Category)
                                            .ToListAsync();
            return resp;
        }



    }
}
