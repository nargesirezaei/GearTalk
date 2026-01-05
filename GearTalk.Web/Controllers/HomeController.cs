using System.Diagnostics;
using System.Threading.Tasks;
using GearTalk.Web.Models;
using GearTalk.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GearTalk.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarReview carReviewRepository;
        private readonly ICarCategory carCategoryRepository;

        public HomeController(ILogger<HomeController> logger, ICarReview carReview, ICarCategory carCategory)
        {
            _logger = logger;
            this.carReviewRepository = carReview;
            this.carCategoryRepository = carCategory;
        }

        public async Task<IActionResult> Index()
        {
            var carCategories = await carCategoryRepository.GetAllAsync();
            var carReviews = await carReviewRepository.GetAllAsync();
            return View(carReviews);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
