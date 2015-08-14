using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using OnlineAPIBuilder.Classes;

namespace OnlineAPIBuilder.Controllers
{
    [Route("api/{client}/{version}/{callName}")]
    public class ValuesController : Controller
    {
        // GET: api/{client}/{version}/{callName}/{*.}
        [HttpGet("{*.}")]
        public List<object> Get()
        {
            string client = Helper.GetUriSegment(Request, 2);
            string version = Helper.GetUriSegment(Request, 3);
            string callName = Helper.GetUriSegment(Request, 4);
            var x = new object[] { "value1", "value2" };
            return x.ToList();
        }

        // POST api/{client}/{version}/{callName}/{*.}
        [HttpPost("{*.}")]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/{client}/{version}/{callName}/{*.}
        [HttpPut("{*.}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/{client}/{version}/{callName}/{*.}
        [HttpDelete("{*.}")]
        public void Delete(int id)
        {
        }
    }
}
