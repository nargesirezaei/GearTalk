using GearTalk.Web.Models;

namespace GearTalk.Web.Repositories
{
    public interface ICarReviewLikeRepository
    {
        public Task<int> GetTotatlLikes(Guid carReviewId);
        public Task<CarReviewLike> AddLikeForReview(CarReviewLike carReviewLike);
        public Task<IEnumerable<CarReviewLike>> GetLikesForReview(Guid carReviewId);
    }
}
