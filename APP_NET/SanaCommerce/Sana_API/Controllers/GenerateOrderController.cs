using _2.BLL.Services;
using _3.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Sana_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sana_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerateOrderController : ControllerBase
    {

        private ISanaServices _sanaServices;

        public GenerateOrderController(ISanaServices sanaServices)
        {
            this._sanaServices = sanaServices;
        }



        //// GET: api/<GenerateOrderController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<GenerateOrderController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}


        // POST api/<GenerateOrderController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OrderDTO orderDTO)
        {
            try 
            {
                int res = 0;

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (orderDTO == null)
                {
                    return NotFound("collection is empty");
                }

                Order o_DB = new Order()
                {
                    CustomerId = orderDTO.CustomerId,
                    OrderDate = DateOnly.FromDateTime(DateTime.Now),
                    TotalAmount = orderDTO.TotalAmount
                };


                List<OrderDetail> orderDetailsBD = orderDTO.OrderDetailsDTO.Select(od => new OrderDetail
                {
                    ProductId = od.ProductId,
                    Quantity = od.Quantity,
                    Subtotal = od.Subtotal
                }).ToList();


                 res = await _sanaServices.GenerateOrder(o_DB, orderDetailsBD);

                if (res <= 0)
                {
                    return NoContent();
                }

                return Ok(res);

            }
            catch
            {
                return BadRequest("Error generating order..!");
            }

        }

        

       
    }
}
