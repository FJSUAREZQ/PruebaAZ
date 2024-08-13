using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sana_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HiYouController : ControllerBase
    {
        // GET: api/<HiYouController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Hola UD por cuarta vez!!!", "value2" };
        }

        // GET api/<HiYouController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HiYouController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HiYouController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HiYouController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
