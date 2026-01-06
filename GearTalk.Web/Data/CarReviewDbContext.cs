using GearTalk.Web.Models;
using GearTalk.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GearTalk.Web.Data
{
    public class CarReviewDbContext : DbContext
    {
        public CarReviewDbContext(DbContextOptions<CarReviewDbContext> options) : base(options)
        {

        }

        //create tables here
        public DbSet<CarReview> CarReviews { get; set; }
        public DbSet<CarCategory> CarCategories { get; set; }   
        public DbSet<CarReviewLike> CarReviewLike  { get; set; }
    }
}
