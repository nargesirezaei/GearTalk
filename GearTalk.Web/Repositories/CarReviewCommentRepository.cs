using GearTalk.Web.Data;
using GearTalk.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace GearTalk.Web.Repositories
{
    public class CarReviewCommentRepository : ICarReviewCommentRepository
    {
        public CarReviewCommentRepository(CarReviewDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public CarReviewDbContext DbContext { get; }

        public async Task<CarReviewComment> AddAsync(CarReviewComment carReviewComment)
        {
            await DbContext.CarReviewComment.AddAsync(carReviewComment);
            await DbContext.SaveChangesAsync();
            return carReviewComment;
        }

        public async Task<IEnumerable<CarReviewComment>> GetCommentsByIdAsync(Guid carReviewId)
        {
             return await DbContext.CarReviewComment.Where(x => x.CarReviewId == carReviewId)
                .ToListAsync();
        }
    }
}
