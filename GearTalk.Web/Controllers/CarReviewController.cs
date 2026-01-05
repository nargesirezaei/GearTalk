using GearTalk.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GearTalk.Web.Controllers
{
    public class CarReviewController : Controller
    {
        private readonly ICarReview carReviewRepository;
        public CarReviewController(ICarReview carReviewRepository)
        {
            this.carReviewRepository = carReviewRepository;
           
        }


        [HttpGet]
        public async Task<IActionResult> Index(string urlHandle)
        {
            var carReview = await carReviewRepository.GetByUrlHandle(urlHandle);
            return View(carReview);
        }
    }
}
