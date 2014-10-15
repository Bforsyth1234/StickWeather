using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StickWeather.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickWeather.DataModel.Migrations
{
    public class Seeder
    {
        ApplicationUser _test;
        ApplicationUser _test2;
        ApplicationUser _test3;
        public void Seed(ApplicationDbContext db, bool seedRoles = false, bool seedUsers = false)
        {
            var store = new UserStore<ApplicationUser>(db);
            var manager = new UserManager<ApplicationUser>(store);

            if (seedRoles) SeedRoles(db);
            if (seedUsers) SeedUsers(db, manager);

            _test = manager.FindByName("Test@gmail.com");
            _test2 = manager.FindByName("Test2@gmail.com");
            _test3 = manager.FindByName("Test3@gmail.com");
        }
        public void SeedRoles (ApplicationDbContext db)
        { 
                        var store = new RoleStore<IdentityRole>(db);
            var manager = new RoleManager<IdentityRole>(store);

            if (!db.Roles.Any(x => x.Name == "Basic User"))
            {
                var role = new IdentityRole { Name = "Basic User" };
                manager.Create(role);
            }
            if (!db.Roles.Any(x => x.Name == "Admin"))
            {
                var role = new IdentityRole { Name = "Admin" };
                manager.Create(role);
            }

            
        }
        public void SeedUsers(ApplicationDbContext db, UserManager<ApplicationUser> manager)
        {
            if(!db.Users.Any(x => x.UserName == "Test@gmail.com"))
            {
                _test = new ApplicationUser()
                {
                    UserName = "Test@gmail.com",
                    ZipCode = 06897
                };
                manager.Create(_test, "test");
                manager.AddToRoles(_test.Id, "Basic User");
            }

            if (!db.Users.Any(x => x.UserName == "Test2@gmail.com"))
            {
                _test2 = new ApplicationUser()
                {
                    UserName = "Test2@gmail.com",
                    ZipCode = 05401
                };
                manager.Create(_test2, "test2");
                manager.AddToRoles(_test2.Id, "Basic User");
            }

            if (!db.Users.Any(x => x.UserName == "Test3@gmail.com"))
            {
                _test3 = new ApplicationUser()
                {
                    UserName = "Test3@gmail.com",
                    ZipCode = 05401
                };
                manager.Create(_test3, "test3");
                manager.AddToRoles(_test3.Id, "Admin");
            }
        }
    }
}
