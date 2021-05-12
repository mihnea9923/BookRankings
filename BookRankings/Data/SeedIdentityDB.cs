using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRankings.Data
{
    public static class SeedIdentityDB
    {
        public static void Seed(RoleManager<IdentityRole> roleManager)
        {
            if(roleManager.RoleExistsAsync("user").GetAwaiter().GetResult() == false)
            {
                roleManager.CreateAsync(new IdentityRole() { Name = "user" }).GetAwaiter().GetResult();
            }
            if (roleManager.RoleExistsAsync("admin").GetAwaiter().GetResult() == false)
            {
                roleManager.CreateAsync(new IdentityRole() { Name = "admin" }).GetAwaiter().GetResult();
            }
        }
        public static void SeedAdmin(UserManager<IdentityUser> userManager)
        {
            if(userManager.GetUsersInRoleAsync("admin").GetAwaiter().GetResult().Count == 0)
            {
                IdentityUser admin = new IdentityUser() { Email = "admin@admin.com", UserName = "admin@admin.com" };
                userManager.CreateAsync(admin , "P@ssw0rd").GetAwaiter().GetResult();
                userManager.AddToRoleAsync(admin, "admin").GetAwaiter().GetResult();

            }
        }
    }
}
