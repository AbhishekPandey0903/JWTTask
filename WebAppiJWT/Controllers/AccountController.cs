using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;

namespace WebAppiJWT.Controllers
{
    
    public class AccountController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage validLogin(string userName, string userPassword)
        {
            if(userName=="admin" && userPassword == "admin123")
            {
                return Request.CreateResponse(HttpStatusCode.OK, value: TokenManager.GenerateToken(userName));
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, message: "userName or Password is invalid");
            }

        }

        [HttpGet]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetEmployee()
        {
            return Request.CreateResponse(HttpStatusCode.OK, value:"Successfully Valid");
        }
       
        
    }
}