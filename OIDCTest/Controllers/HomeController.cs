using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OIDCTest.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("logincallback")]
        public ActionResult Callback(string code, string state)
        {
            Console.WriteLine(code);
            Console.WriteLine(state);
            return Ok();
        }

        [Authorize]
        [Route("secured")]
        // GET: HomeController
        public ActionResult Secured()
        {
            return View();
        }


    }
}
