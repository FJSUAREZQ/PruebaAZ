using _3.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BLL.Services
{
    public interface ISanaServices
    {

        #region Customer
        Task<bool> CreateCustomer(Customer customer);

        Task<List<Customer>> GetAllCustomer();

        Task<Customer> GetByIdCustomer(int id);

        Task<bool> UpdateCustomer(Customer customer);

        Task<bool> DeleteCustomer(Customer customer);
        #endregion customer



        #region Product
        Task<bool> CreateProduct(Product product);

        Task<List<Product>> GetAllProducts();

        Task<List<Product>> GetAllProductsCat();

        Task<Product> GetByIdProduct(int id);

        Task<bool> UpdateProduct(Product product);

        Task<bool> DeleteProduct(Product product);
        #endregion Product



        #region GenerateOrder
        Task<int> GenerateOrder(Order order, List<OrderDetail> orderDetails);

        #endregion GenerateOrder


    }
}
