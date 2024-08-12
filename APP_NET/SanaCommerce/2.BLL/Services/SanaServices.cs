using _1.DALL.UnitOfWork;
using _3.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BLL.Services
{
    public class SanaServices: ISanaServices
    {

        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Class Constructor
        /// </summary>
        /// <param name="unitOfWork">Dependency injection of UoW</param>
        public SanaServices(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        #region Customer
        public async Task<bool> CreateCustomer(Customer customer)
        {
            await _unitOfWork._repositoryCustomer.Create(customer);
            await _unitOfWork.SaveComplete();
            return true;
        }



        public async Task<List<Customer>> GetAllCustomer()
        {
            List<Customer> list_c = new List<Customer>();
            var _customerTemp = await _unitOfWork._repositoryCustomer.GetAll();
            list_c= _customerTemp.ToList();

            return list_c;
        }


        public async Task<Customer> GetByIdCustomer(int id)
        {
            return await _unitOfWork._repositoryCustomer.GetById(id);
        }


        public async Task<bool> UpdateCustomer(Customer customer)
        {
            bool resp = await _unitOfWork._repositoryCustomer.Update(customer);
            await _unitOfWork.SaveComplete();
            return resp;
        }

        public async Task<bool> DeleteCustomer(Customer customer)
        {
            bool resp = await _unitOfWork._repositoryCustomer.Delete(customer);
            await _unitOfWork.SaveComplete();
            return resp;
        }

        #endregion Customer



        #region Product
        public async Task<bool> CreateProduct(Product product)
        {
            await _unitOfWork._repositoryProduct.Create(product);
            await _unitOfWork.SaveComplete();
            return true;
        }



        public async Task<List<Product>> GetAllProducts()
        {
            List<Product> list_p = new List<Product>();
            var _productTemp = await _unitOfWork._repositoryProduct.GetAll();
            list_p = _productTemp.ToList();

            return list_p;
        }


        public async Task<List<Product>> GetAllProductsCat()
        {
            List<Product> list_p = new List<Product>();
            var _productTemp = await _unitOfWork._repositoryProduct.GetAllProductsCat();
            list_p = _productTemp.ToList();

            return list_p;
        }


        public async Task<Product> GetByIdProduct(int id)
        {
            return await _unitOfWork._repositoryProduct.GetById(id);
        }


        public async Task<bool> UpdateProduct(Product product)
        {
            bool resp = await _unitOfWork._repositoryProduct.Update(product);
            await _unitOfWork.SaveComplete();
            return resp;
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            bool resp = await _unitOfWork._repositoryProduct.Delete(product);
            await _unitOfWork.SaveComplete();
            return resp;
        }

        #endregion Product



        #region GenerateOrder
        /// <summary>
        /// Generate a Order and OrderDetail
        /// </summary>
        /// <param name="order">Order info</param>
        /// <param name="orderDetails">OrderDetail info</param>
        /// <returns>OrderId generated</returns>
        public async Task<int> GenerateOrder(Order order, List<OrderDetail> orderDetails) 
        {
            int resp = 0;

            await _unitOfWork._repositoryOrder.Create(order);
            await _unitOfWork.SaveComplete();

            int newOrderID = order.OrderId;//After Save, we can get new OrderId


            if (newOrderID > 0) 
            {
                foreach (var detail in orderDetails)
                {
                    detail.OrderId = newOrderID;
                    await _unitOfWork._repositoryOrderDetail.Create(detail);
                }

                await _unitOfWork.SaveComplete();

                resp = newOrderID;
            }

            return resp;
        }

        #endregion GenerateOrder
    }
}
