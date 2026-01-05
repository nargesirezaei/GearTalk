using GearTalk.Web.Models.Domain;

namespace GearTalk.Web.Repositories
{
    public interface ICarReview
    {
        public Task<IEnumerable<CarReview>> GetAllAsync();
        public Task<CarReview?> GetAsync(Guid id);
        public Task<CarReview> AddAsync(CarReview carReview);
        public Task<CarReview?> UpdateAsync(CarReview carReview);
        public Task<CarReview?> DeleteAsync(Guid id);
        public Task<CarReview?> GetByUrlHandle(string urlHandle);
        
    }
}
