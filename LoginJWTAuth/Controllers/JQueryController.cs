using Microsoft.AspNetCore.Mvc;

namespace LoginJWTAuth.Controllers
{
    public class JQueryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
