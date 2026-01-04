using GearTalk.Web.Data;
using GearTalk.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GearTalk.Web.Repositories
{
    public class CarCategoryRepository : ICarCategory
    {
        private readonly CarReviewDbContext dbContext;

        public CarCategoryRepository(CarReviewDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<CarCategory> AddAsync(CarCategory carCategory)
        {   
            await dbContext.AddAsync(carCategory);
            await dbContext.SaveChangesAsync();
            return carCategory;
        }


        public async Task<IEnumerable<CarCategory>> GetAllAsync()
        {
            return await dbContext.CarCategories.ToListAsync();
           
        }

        public async Task<CarCategory?> UpdateAsync(CarCategory carCategory)
        {
            //først finner vi objektet med samme id
            var exixtingCategory = await dbContext.CarCategories.FindAsync(carCategory.Id);
            //deretter setter vi nye verdier til objektet 
            if(exixtingCategory != null)
            {
                exixtingCategory.Name = carCategory.Name;
                exixtingCategory.DisplayName = carCategory.DisplayName;

                await dbContext.SaveChangesAsync();
                return exixtingCategory;
            }
            return null;

            
        }
        public async Task<CarCategory> DeleteAsync(Guid id)
        {
            var category = await dbContext.CarCategories.FindAsync(id);

            if (category == null)
                throw new KeyNotFoundException($"CarCategory med id {id} finnes ikke.");

            dbContext.CarCategories.Remove(category);
            await dbContext.SaveChangesAsync();

            return category;
        }



        public async Task<CarCategory?> GetByIdAsync(Guid Id)
        {
            return await dbContext.CarCategories.FirstOrDefaultAsync(x => x.Id == Id);
            
        }
    }
}
