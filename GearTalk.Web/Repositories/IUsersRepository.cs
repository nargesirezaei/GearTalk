using Microsoft.AspNetCore.Identity;

namespace GearTalk.Web.Repositories
{
    public interface IUsersRepository
    {
        Task<IEnumerable<IdentityUser>> GetAllAsync();
    }
}
