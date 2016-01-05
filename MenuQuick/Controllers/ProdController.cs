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
        public IEnumerable<m_Prod> Get()
        {

            var db = new MenuQuickEntities();
            var item = db.Prod.OrderBy(x => x.item).Select(x=> new m_Prod(){
                prod_id = x.prod_id,
                prod_name = x.prod_name,
                price =x.price,
                imgsrc = "http://menuquick.fly.idv.tw/p" + x.prod_id + ".jpg"}).AsEnumerable();

            return item;
        }

        public class m_Prod {
            public int prod_id { get; set; }
            public string cust_email { get; set; }
            public int item { get; set; }
            public string prod_name { get; set; }
            public int price { get; set; }
            public string imgsrc { get; set; }
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
