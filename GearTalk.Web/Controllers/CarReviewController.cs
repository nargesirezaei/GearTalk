using GearTalk.Web.Models;
using GearTalk.Web.Models.ViewModel;
using GearTalk.Web.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GearTalk.Web.Models.ViewModel;

namespace GearTalk.Web.Controllers
{
    public class CarReviewController : Controller
    {
        private readonly ICarReview carReviewRepository;
        private readonly ICarReviewLikeRepository carReviewLikeRepository;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ICarReviewCommentRepository carReviewComment;

        public CarReviewController(ICarReview carReviewRepository, 
                                   ICarReviewLikeRepository carReviewLikeRepository,
                                   SignInManager<IdentityUser> signInManager,
                                   UserManager<IdentityUser> userManager,
                                   ICarReviewCommentRepository carReviewComment)
        {
            this.carReviewRepository = carReviewRepository;
            this.carReviewLikeRepository = carReviewLikeRepository;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.carReviewComment = carReviewComment;
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
                //get comment for car reiew
                var reviewCommentDomainModel = await carReviewComment.GetCommentsByIdAsync(carReview.Id);
                var carReviewCommentsForView = new List<CarReviewCommentView>();


                foreach(var reviewComment in reviewCommentDomainModel)
                {
                    carReviewCommentsForView.Add(new CarReviewCommentView
                    {
                        Description = reviewComment.Description,
                        DateAdded = reviewComment.DateAdded,
                        Username = (await userManager.FindByIdAsync(reviewComment.UserId.ToString())).UserName
                    });
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
                    Liked = liked,
                    Comments = carReviewCommentsForView

                };
                
            }
            
            return View(carReviewViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ReviewDetailsViewModel reviewDetailsView)
        {
            if(signInManager.IsSignedIn(User))
            {
                var domainModel = new  Models.CarReviewComment
                {
                    CarReviewId = reviewDetailsView.Id,
                    Description = reviewDetailsView.CommentDescription,
                    UserId = Guid.Parse(userManager.GetUserId(User)),
                    DateAdded = DateTime.Now
                };
                await carReviewComment.AddAsync(domainModel);
                return RedirectToAction("Index", "CarReview", new { UrlHandle = reviewDetailsView.UrlHandle });
            }

            return View();
            
        }
    }



}
