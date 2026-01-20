using GearTalk.Web.Models;

namespace GearTalk.Web.Repositories
{
    public interface ICarReviewCommentRepository
    {
        public Task<CarReviewComment> AddAsync(CarReviewComment carReviewComment);
        public Task<IEnumerable<CarReviewComment>> GetCommentsByIdAsync(Guid carReviewId);
    }
}
