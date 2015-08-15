using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using OnlineAPIBuilder.Classes;

namespace OnlineAPIBuilder.Controllers
{
    [Route("api/{client}/{version}/{callName}")]
    public class GenericController : BaseController
    {
        // GET: api/{client}/{version}/{callName}/{*.}
        [HttpGet("{*.}")]
        public List<object> Get()
        {
            var x = new object[] { "value1", "value2" };
            return x.ToList();
        }

        // POST api/{client}/{version}/{callName}/{*.}
        [HttpPost("{*.}")]
        public List<object> Post()
        {
            var allKeys = Request.Form.Keys;
            var result = new List<object>();
            foreach (var key in allKeys)
            {
                var value = Request.Form[key];
                result.Add(new { key, value });
            }
            return result;
        }

        // PUT api/{client}/{version}/{callName}/{*.}
        [HttpPut("{*.}")]
        public void Put([FromBody]string value)
        {
        }

        // DELETE api/{client}/{version}/{callName}/{*.}
        [HttpDelete("{*.}")]
        public void Delete(int id)
        {
        }
    }
}
