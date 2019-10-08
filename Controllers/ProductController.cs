using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTDI_Food.data.bo;
using CTDI_Food.data.contexts;
using CTDI_Food.data.models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;

namespace ODataWithoutEF.Controllers
{
    public class catalogController : ODataController    
    {

				// this is the catalog controller rest api
				// it returns products with the discount and 
				// and calculated final price.  It does this 
				// using a business object.

        private readonly catalogbo _catalog;

        public catalogController(catalogbo catalog)
        {
            _catalog = catalog;
        }


        [ODataRoute]
        public ActionResult<IEnumerable<catalog>> Get()
        {

            return Ok(_catalog.get_productsWithDiscountsFilteredByDate());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
