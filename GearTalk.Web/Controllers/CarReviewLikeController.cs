using GearTalk.Web.Models;
using GearTalk.Web.Models.ViewModel;
using GearTalk.Web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GearTalk.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarReviewLikeController : ControllerBase
    {
        private readonly ICarReviewLikeRepository reviewLikeRepository;

        public CarReviewLikeController(ICarReviewLikeRepository reviewLikeRepository)
        {
            this.reviewLikeRepository = reviewLikeRepository;
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddLikeForCarReview([FromBody] AddLikeRequest likeRequest)
        {
            //mapping from view to domain

            var model = new CarReviewLike
            {
                CarReviewId = likeRequest.CarReviewId,
                UserId = likeRequest.UserId,
            };
            await reviewLikeRepository.AddLikeForReview(model);
            return Ok();
        }
    

        [HttpGet]
        [Route("{carReviewId:guid}/totalLikes")]
        public async Task<IActionResult> GetTotalLikeForReview([FromRoute] Guid carReviewId)
        {
             var totalLikes = await reviewLikeRepository.GetTotatlLikes(carReviewId);
            return Ok(totalLikes);
        }

    }
}
