using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTDI_Food.data.bo;
using CTDI_Food.data.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CTDI_Food.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class catalogController : ControllerBase
    {

        private readonly catalogbo _catalog;

        public catalogController(catalogbo catalog)
        {
            _catalog = catalog;
        }
        // GET: api/catalog
        [HttpGet]
        public ActionResult<IEnumerable<catalog>> Get()
        {
            return Ok(_catalog.get_productsWithDiscountsFilteredByDate());
        }

        // GET: api/catalog/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/catalog
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/catalog/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
