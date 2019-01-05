using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggingWeb.Models;
using Microsoft.AspNetCore.Identity;

namespace BloggingWeb.Data
{
    public static class DbSeeder
    {
        public static void SeedDb(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            SeedPeople(context);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = "Member1@email.com",
                Email = "Member1@email.com"
            };

            userManager.CreateAsync(user, "Password123!").Wait();
        }

        private static void SeedPeople(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            context.People.Add(
                new Person() { Name = "Member1" }
                );
            context.SaveChanges();
        }
    }
}
