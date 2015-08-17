using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using OnlineAPIBuilder.Classes;
using OnlineAPIBuilder.ViewModels;

namespace OnlineAPIBuilder.Controllers
{
    [Route("api/{client}/{version}/{callName}")]
    public class GenericController : BaseController
    {
        // GET: api/{client}/{version}/{callName}/{*.}
        [HttpGet("{*.}")]
        public List<object> Get()
        {
            //query string test /api/09090/v1.0/GetAllThings?where=skopje&orderby=id&top=5&firstname=pero
            //route values test /api/09090/v1.0/GetAllThings/skopje/id/5/pero
            //var values = GetRequesData("where", "orderby", "top", "firstname");
            var x = new object[] { "value1", "value2" };
            return x.ToList();
        }

        // POST api/{client}/{version}/{callName}/{*.}
        [HttpPost("{*.}")]
        public List<object> Post([FromBody]Dictionary<object, object> test)
        {
            var result = new List<object>();
            if (test == null || test.Count == 0)
            {
                var allKeys = Request.Form.Keys;
                foreach (var key in allKeys)
                {
                    var value = Request.Form[key];
                    result.Add(new { key, value });
                }
            }
            else
                foreach (var key in test.Keys)
                {
                    var value = test[key];
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
