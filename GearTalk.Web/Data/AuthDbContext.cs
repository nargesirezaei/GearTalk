using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GearTalk.Web.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) 
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //seed Roles (User, Admin, SuperAdmin)

            var adminRoleId = "E8330C27-40D8-43B2-9981-2D657C82ABAF";
            var superAdminRoleId = "BE44FCA6-CEE9-465C-8A6B-18D94B9E9F0A";
            var userRoleId = "C4F7A47C-1CD3-4F1F-8034-48F9493AE17A";
            
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId
                },
                new IdentityRole
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = superAdminRoleId
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = userRoleId
                },
            };
            //when we run this line of code EF core will seed these roles into db
            builder.Entity<IdentityRole>().HasData(roles);


            //Seed SuperAdmin
            var superAdminId = "BFE0E3CE-FBBB-4014-903E-92B9C86EA5D4";
            var superAdminUser = new IdentityUser
            {
                Id = superAdminId,
                UserName = "superadmin@gearTalks.com",
                NormalizedUserName = "SUPERADMIN@GEARTALKS.COM",
                Email = "superadmin@gearTalks.com",
                NormalizedEmail = "SUPERADMIN@GEARTALKS.COM",
                EmailConfirmed = true
            };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(superAdminUser, "Khodam121!");
            builder.Entity<IdentityUser>().HasData(superAdminUser);


            //Super admin will have all roles
            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId ,
                    UserId = superAdminId
                },

                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId =userRoleId ,
                    UserId = superAdminId
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }
    }
}
//AuthDbContext er EF Core-koblingen mellom ASP.NET Core Identity og SQL Server.
//Den har en jobb: fortelle EF Core hvordan identity data skal lagres i db, den innholder bare lagring
//IdentityDbContext: betyr vi bruker identity sine ferdige tabeller
//EF core oppretter tabeller som : Users, Roles, UserRoles  
//dbo.AspNetUsers : brukerTabellen(Id, UserNAme, Email, PasswordHash),dbo.AspNetRoles: rolleTabellen(Id, Name(Admin/User/Super?), NormalizedName)
//dbo.AspNetUserRoles : Koblingstabelle mellom brukere og riller userId = RoleId
//dbo.AspNetUserClaims : ekstra claims per bruker, CanEdit=true. dbo.AspNetUserLogins: eksterne innlogginger(om man kan logge via facebook osv)
//Disse tabellene er Identity sine standardtabeller som EF Core oppretter og bruker til å lagre brukere, roller og koblingen mellom dem.
//Identity håndterer logikken, mens EF Core sørger for at dataene lagres korrekt i SQL Server.
