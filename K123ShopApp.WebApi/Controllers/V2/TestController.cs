using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace K123ShopApp.WebApi.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TestController : Controller
    {
        // GET: api/values

        [HttpGet]
        [MapToApiVersion("2.0")]
        public IEnumerable<string> Get()
        {
            return new string[] { "Version 2", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [MapToApiVersion("2.0")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [MapToApiVersion("2.0")]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [MapToApiVersion("2.0")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [MapToApiVersion("2.0")]
        public void Delete(int id)
        {
        }
    }
}

