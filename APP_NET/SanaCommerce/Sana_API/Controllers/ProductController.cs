using _2.BLL.Services;
using _3.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Sana_API.Models;

namespace Sana_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private ISanaServices _sanaServices;

        public ProductController(ISanaServices sanaServices)
        {
            this._sanaServices = sanaServices;
        }



        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProductsCat()
        {
            try 
            {
                List<Product> list_p = await _sanaServices.GetAllProductsCat();

                if (list_p.Count <= 0)
                {
                    return NotFound("There are not products");
                }


                List<ProductDTO> list_DTO = list_p.Select(c => new ProductDTO()
                {
                    ProductId = c.ProductId,
                    Name = c.Name,
                    Description = c.Description,
                    Price = c.Price,
                    Stock = c.Stock,
                    Categories = string.Join(",", 
                                                    ((from x in c.ProductCategories
                                                        select x.Category).Select(z => z.Name).ToList()) 
                                             ).ToString()
                }).ToList();

                return Ok(list_DTO);


            }
            catch (Exception ex) 
            {
                return NotFound("There was a problem: " + ex.Message.ToString() );
            }
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Customer _customer = await _sanaServices.GetByIdCustomer(id);

            if (_customer == null)
            {
                return NotFound("There are not customers");
            }


            CustomerDTO c_DTO = new CustomerDTO()
            {
                CustomerId = _customer.CustomerId,
                FirstName = _customer.FirstName,
                LastName = _customer.LastName,
                Email = _customer.Email
            };

            return Ok(c_DTO);
        }



        // POST api/<CustomerController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CustomerDTO collection)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (collection == null)
            {
                return NotFound("collection is empty");
            }

            Customer c_DB = new Customer()
            {
                FirstName = collection.FirstName,
                LastName = collection.LastName,
                Email = collection.Email
            };

            bool res = await _sanaServices.CreateCustomer(c_DB);

            if (!res)
            {
                return NoContent();
            }

            return Ok(res);

        }



        // PUT api/<CustomerController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CustomerDTO _customer_DTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Customer _customer_DB = await _sanaServices.GetByIdCustomer(_customer_DTO.CustomerId);

            if (_customer_DB == null)
            {
                return NotFound("There is not a customer for that Id");
            }


            _customer_DB.FirstName = _customer_DTO.FirstName;
            _customer_DB.LastName = _customer_DTO.LastName;
            _customer_DB.Email = _customer_DTO.Email;


            bool resp = await _sanaServices.UpdateCustomer(_customer_DB);

            if (!resp)
            {
                return NoContent();
            }


            return Ok(resp);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Customer _customer_DB = await _sanaServices.GetByIdCustomer(id);

                if (_customer_DB == null)
                {
                    return NotFound("There is not a customer for that Id");
                }

                bool res = await _sanaServices.DeleteCustomer(_customer_DB);

                if (!res)
                {
                    return NoContent();
                }

                return Ok("Customer deleted!");
            }
            catch
            {
                return BadRequest("Error..!");
            }

        }


    }
}
