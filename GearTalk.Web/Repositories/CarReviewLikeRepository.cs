
using GearTalk.Web.Data;
using GearTalk.Web.Models;
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

        public Task<CarReviewLike> AddLikeForBlog(CarReviewLike carReviewLike)
        {
            throw new NotImplementedException();
        }

        public async Task<CarReviewLike> AddLikeForReview(CarReviewLike carReviewLike)
        {
            await carReviewDbContext.CarReviewLike.AddAsync(carReviewLike);
            await carReviewDbContext.SaveChangesAsync();
            return carReviewLike;
        }

        public async Task<IEnumerable<CarReviewLike>> GetLikesForReview(Guid carReviewId)
        {
            return await carReviewDbContext.CarReviewLike.Where(x => x.CarReviewId == carReviewId).ToListAsync();
        }

        public async Task<int> GetTotatlLikes(Guid carReviewId)
        {
            return await carReviewDbContext.CarReviewLike.CountAsync(x => x.CarReviewId == carReviewId);
        }
    }
}
