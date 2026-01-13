using GearTalk.Web.Models.ViewModel;
using GearTalk.Web.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GearTalk.Web.Controllers
{
    public class CarReviewController : Controller
    {
        private readonly ICarReview carReviewRepository;
        private readonly ICarReviewLikeRepository carReviewLikeRepository;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public CarReviewController(ICarReview carReviewRepository, 
                                   ICarReviewLikeRepository carReviewLikeRepository,
                                   SignInManager<IdentityUser> signInManager,
                                   UserManager<IdentityUser> userManager)
        {
            this.carReviewRepository = carReviewRepository;
            this.carReviewLikeRepository = carReviewLikeRepository;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> Index(string urlHandle)
        {
            var liked = false;
            var carReview = await carReviewRepository.GetByUrlHandle(urlHandle);
            var carReviewViewModel = new ReviewDetailsViewModel();

            if (carReview != null)
            {
                var totalLikes = await carReviewLikeRepository.GetTotatlLikes(carReview.Id);
                if(signInManager.IsSignedIn(User))
                {
                    var likesForReview = await carReviewLikeRepository.GetLikesForReview(carReview.Id);
                    var userId = userManager.GetUserId(User);
                    if(userId != null)
                    {
                        var likeFromUser =  likesForReview.FirstOrDefault(x => x.UserId == Guid.Parse(userId));
                        liked = likeFromUser != null;
                    }
                }
                carReviewViewModel = new ReviewDetailsViewModel
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
                    TotalLikes = totalLikes,
                    Liked = liked

                };
                
            }
            
            return View(carReviewViewModel);
        }
    }
}
