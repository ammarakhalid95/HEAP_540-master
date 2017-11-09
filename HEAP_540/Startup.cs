using HEAP_540.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HEAP_540.Startup))]
namespace HEAP_540
{
    public partial class Startup
    {
        //public void Configuration(IAppBuilder app)
        //{
        //    ConfigureAuth(app);
        //}
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }


        // In this method we will create default User roles and Admin user for login   
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
  
            if (!roleManager.RoleExists("IT Administrator"))
            {
                  
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "IT Administrator";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

                var user = new ApplicationUser();
                user.UserName = "HEAP";
                user.Email = "heapifymanager540@gmail.com";

                string userPWD = "Pa$$word1";

                var chkUser = UserManager.Create(user, userPWD);

                 
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "IT Administrator");

                }
            }

            // creating Receptionist role    
            if (!roleManager.RoleExists("Medical Receptionist"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Medical Receptionist";
                roleManager.Create(role);

            }

            // creating Creating Employeee role    
            if (!roleManager.RoleExists("Employee"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);

            }
            
            // creating Creating Employeee role    
            if (!roleManager.RoleExists("Medical Staff"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Medical Staff";
                roleManager.Create(role);

            }
            
            // creating Creating Employeee role    
            if (!roleManager.RoleExists("Patient Billing Rep"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Patient Billing Rep";
                roleManager.Create(role);

            }
        }
    }
}
