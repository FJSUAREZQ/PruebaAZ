using _1.DAL.DataContext;
using _1.DALL.Repositories._GenericRepository;
using _3.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DALL.Repositories._Category
{
    public class RepositoryCategory : GenericRepository<Category>, IRepositoryCategory
    {

        public RepositoryCategory(SanaDbContext _context) : base(_context)
        { }


        // Implement specific methods for Category repository

    }
}
