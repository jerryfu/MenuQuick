using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MenuQuick.DB;
namespace MenuQuick.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public LoginMessage SignIn(LoginData dd)
        {
            LoginMessage r = new LoginMessage();

            using (var db = new MenuQuickEntities())
            {

                var item = db.Cust.Where(x => x.cust_email == dd.account && x.pwd == dd.password).FirstOrDefault();
                if (item == null)
                {
                    r.result = false;
                    r.message = "帳號或密碼不正確";
                }
                else {

                    var token = new Token();
                    var token_value = Guid.NewGuid().ToString();
                    token.cust_email = dd.account;
                    token.expired_date = DateTime.Now.AddHours(1);
                    token.tocken = token_value;

                    db.Token.Add(token);
                    db.SaveChanges();

                    r.token = token_value;
                    r.result = true;
                    r.message = string.Empty;
                }
            }

            return r;
        }
    }


    public class LoginData
    {
        public string account { get; set; }
        public string password { get; set; }
        public string valide { get; set; }
    }

    public class LoginMessage
    {
        public bool result { get; set; }
        public string message { get; set; }
        public string token { get; set; }
    }
}
