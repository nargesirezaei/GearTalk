using GearTalk.Web.Data;
using GearTalk.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GearTalk.Web.Repositories
{
    public class CarReviewRepository : ICarReview
    {
        private readonly CarReviewDbContext dbContext;
        public CarReviewRepository(CarReviewDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<CarReview> AddAsync(CarReview carReview)
        {
            await dbContext.AddAsync(carReview);
            await dbContext.SaveChangesAsync();
            return carReview;
        }

        public async Task<CarReview?> DeleteAsync(Guid id)
        {
            var existingCarReview = dbContext.CarReviews.FirstOrDefault(x => x.Id == id);
            if (existingCarReview == null)
            {
                throw new KeyNotFoundException($"CarReview med id {id} finnnes ikke");
            }
            dbContext.CarReviews.Remove(existingCarReview);
            await dbContext.SaveChangesAsync();
            return existingCarReview;
        }

        public async Task<IEnumerable<CarReview>> GetAllAsync()
        {
            //denne er en måte i  EF som tar med alle objekter som har navigasjon med denne tabellen
            return await dbContext.CarReviews.Include(x => x.category).ToListAsync();

        }

        public async Task<CarReview?> GetAsync(Guid id)
        {
            return await dbContext.CarReviews.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<CarReview?> GetByUrlHandle(string urlHandle)
        {
            return await dbContext.CarReviews.Include(x => x.category).FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
            
        }

        public async Task<CarReview?> UpdateAsync(CarReview carReview)
        {
            var existingReview = await dbContext.CarReviews.Include(x => x.category).FirstOrDefaultAsync(x => x.Id == carReview.Id);

            if (existingReview != null)
            {
                existingReview.Id = carReview.Id;
                existingReview.ModelName = carReview.ModelName;
                existingReview.Content = carReview.Content;
                existingReview.ShortDescription = carReview.ShortDescription;
                existingReview.YouTubeVideoUrl = carReview.YouTubeVideoUrl;
                existingReview.FeaturedImageUrl = carReview.FeaturedImageUrl;
                existingReview.UrlHandle = carReview.UrlHandle;
                existingReview.PublishedDate = carReview.PublishedDate;
                existingReview.Author = carReview.Author;
                existingReview.CarCategoryId = carReview.CarCategoryId;

                await dbContext.SaveChangesAsync();
                return existingReview;
            }
         
            return null;
        }
    }
}
