using GearTalk.Web.Models.Domain;

namespace GearTalk.Web.Repositories
{
    public interface ICarCategory
    {
        public Task<IEnumerable<CarCategory>> GetAllAsync();
        public Task<CarCategory?> GetByIdAsync(Guid Id);
        public Task<CarCategory> AddAsync(CarCategory carCategory);
        public Task<CarCategory?> UpdateAsync(CarCategory carCategory);
        public Task<CarCategory> DeleteAsync(Guid id);

    }
}
