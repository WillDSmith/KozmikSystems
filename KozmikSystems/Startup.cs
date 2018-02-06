using KozmikSystems.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(KozmikSystems.Startup))]
namespace KozmikSystems
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }

        // This method will create default User Roles and an Admin User for Login
        private void CreateRolesandUsers()
        {
            var context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<User>(new UserStore<User>(context));

            // Create the Admin Role and a default Admin User
            if (!roleManager.RoleExists("Admin"))
            {
                // Create the admin role
                var role = new IdentityRole {Name = "Admin"};
                roleManager.Create(role);

                // Add the admin super user, that maintains the site to Admin Role
                // by getting the super user by Username
                var superUser = userManager.FindByName("Shakey");

                userManager.AddToRole(superUser.Id, "Admin");
            }

            if (!roleManager.RoleExists("Staff"))
            {
                // Create the admin role
                var role = new IdentityRole {Name = "Staff"};
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Parent"))
            {
                // Create the admin role
                var role = new IdentityRole {Name = "Parent"};
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Guest"))
            {
                // Create the admin role
                var role = new IdentityRole {Name = "Guest"};
                roleManager.Create(role);
            }
        }
    }
}
