using GearTalk.Web.Models;

namespace GearTalk.Web.Repositories
{
    public interface ICarReviewLikeRepository
    {
        public Task<int> GetTotatlLikes(Guid carReviewId);
    }
}
