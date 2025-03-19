using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using kanis;
using Microsoft.AspNetCore.Cors;

namespace synaManage.Controllers
{
    public class HodatHerumController : ApiController
    {
        // GET: api/HodatHerum
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/HodatHerum/5
        [EnableCors()]
        [HttpGet]
        [Route("api/HodatHerum/{id}")]
        public HodatHerum Get(int id)
        {
            string str = "SELECT text  FROM hodaot_herum    where city_id = + " + id;
            var hodaa = new kanis.HodatHerum();
            hodaa.Text = DBService.getResult(str);
            return hodaa;
        }

        // POST: api/HodatHerum
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/HodatHerum/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/HodatHerum/5
        public void Delete(int id)
        {
        }
    }
}
