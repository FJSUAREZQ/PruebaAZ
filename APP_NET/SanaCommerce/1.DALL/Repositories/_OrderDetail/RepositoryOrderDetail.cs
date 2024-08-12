using _1.DAL.DataContext;
using _1.DALL.Repositories._Customer;
using _1.DALL.Repositories._GenericRepository;
using _3.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DALL.Repositories._OrderDetail
{
    public class RepositoryOrderDetail: GenericRepository<OrderDetail>, IRepositoryOrderDetail
    {

        public RepositoryOrderDetail(SanaDbContext _context) : base(_context)
        { }



    }
}
