using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MenuQuick.DB;
namespace MenuQuick.Controllers
{

    public class ProdController : ApiController
    {
        public IEnumerable<Prod> Get()
        {

            var db = new MenuQuickEntities();
            var item = db.Prod.OrderBy(x => x.item).AsEnumerable();

            return item;
        }

        public string Get(int id)
        {
            return "value";
        }

        public void Post([FromBody]string value)
        {
        }
        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}
