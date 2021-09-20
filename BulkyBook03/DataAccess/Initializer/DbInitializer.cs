using System;
using System.Linq;
using BulkyBook03.DataAccess.Data;
using BulkyBook03.Models;
using BulkyBook03.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook03.DataAccess.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            if (_db.Roles.Any(r => r.Name == SD.Role_Admin)) return;
            _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult(); //tạo sẵn các role, lấy kết quả
            _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Comp)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Indi)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
    UserName = "admin@gmail.com",       //user admin cũng được tạo sẵn, lấy kết quả.
    Email="admin@gmail.com",
    EmailConfirmed=true,
    Name = "Hoang Ha"
            },"Admin@123").GetAwaiter().GetResult();
            ApplicationUser user = _db.ApplicationUsers.                 // đưa user co email= admin vào database.
                Where(u => u.Email == "admin@gmail.com").FirstOrDefault();
            _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult(); // đưa user trên, gán với roleAdmin và lấy kết quả 

        }
    }
}