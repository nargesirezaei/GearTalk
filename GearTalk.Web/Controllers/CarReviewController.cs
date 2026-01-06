using GearTalk.Web.Models.ViewModel;
using GearTalk.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GearTalk.Web.Controllers
{
    public class CarReviewController : Controller
    {
        private readonly ICarReview carReviewRepository;
        private readonly ICarReviewLikeRepository carReviewLikeRepository;

        public CarReviewController(ICarReview carReviewRepository, ICarReviewLikeRepository carReviewLikeRepository)
        {
            this.carReviewRepository = carReviewRepository;
            this.carReviewLikeRepository = carReviewLikeRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Index(string urlHandle)
        {
            var carReview = await carReviewRepository.GetByUrlHandle(urlHandle);
            var carReviewLikeViewModel = new ReviewDetailsViewModel();

            if (carReview != null)
            {
                var totalLikes = await carReviewLikeRepository.GetTotatlLikes(carReview.Id);

                 carReviewLikeViewModel = new ReviewDetailsViewModel
                {
                    Id = carReview.Id,
                    Content = carReview.Content,
                    ModelName = carReview.ModelName,
                    Author = carReview.Author,
                    FeaturedImageUrl = carReview.FeaturedImageUrl,
                    PublishedDate = carReview.PublishedDate,
                    ShortDescription = carReview.ShortDescription,
                    UrlHandle = carReview.UrlHandle,
                    Visible = carReview.Visible,
                    CarCategoryId = carReview.CarCategoryId,
                    category = carReview.category,
                    TotalLikes = totalLikes

                };
                
            }
            
            return View(carReviewLikeViewModel);
        }
    }
}
