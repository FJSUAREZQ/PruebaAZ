using _2.BLL.Services;
using _3.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Sana_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sana_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private ISanaServices _sanaServices;

        public CustomerController(ISanaServices sanaServices)
        {
            this._sanaServices = sanaServices;
        }



        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAll()
        {
            List<Customer> list_C = await _sanaServices.GetAllCustomer();

            if (list_C.Count <= 0)
            {
                return NotFound("There are not customers");
            }


            List<CustomerDTO> list_DTO = list_C.Select(c => new CustomerDTO()
            {
                CustomerId = c.CustomerId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email
            }).ToList();

            return Ok(list_DTO);
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
