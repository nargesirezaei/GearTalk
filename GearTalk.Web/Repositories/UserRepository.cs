using GearTalk.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GearTalk.Web.Repositories
{
    public class UserRepository : IUsersRepository
    {
        private readonly AuthDbContext authDbContext;

        public UserRepository(AuthDbContext authDbContext)
        {
            this.authDbContext = authDbContext;
        }
        public async Task<IEnumerable<IdentityUser>> GetAllAsync()
        {
            var users =  await authDbContext.Users.ToListAsync();
            var superAdminUser = await authDbContext.Users
                .FirstOrDefaultAsync(x => x.Email == "narges@gearTalks.com");

            if(superAdminUser != null)
            {
                users.Remove(superAdminUser);
            }
            return users;
        }
    }
}
