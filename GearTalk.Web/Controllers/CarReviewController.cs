using Microsoft.AspNetCore.Mvc;

namespace GearTalk.Web.Controllers
{
    public class CarReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
