
using GearTalk.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace GearTalk.Web.Repositories
{
    public class CarReviewLikeRepository : ICarReviewLikeRepository
    {
        private readonly CarReviewDbContext carReviewDbContext;
        public CarReviewLikeRepository(CarReviewDbContext carReviewDbContext)
        {
            this.carReviewDbContext = carReviewDbContext;
        }
        public async Task<int> GetTotatlLikes(Guid carReviewId)
        {
            return await carReviewDbContext.CarReviewLike.CountAsync(x => x.CarReviewId == carReviewId);
        }
    }
}
