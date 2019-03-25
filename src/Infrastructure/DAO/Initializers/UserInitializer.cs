using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Core.Models.Entities;
using Infrastructure.DAO.Data;
using System;
using Models.Entities;

namespace Infrastructure.DAO.Initializers
{
    public class UserInitializer
    {
        public static async Task Initialize (UserManager<User> userManager, RoleManager<Role> roleManager,
            ApplicationDbContext context)
        {

            context.Database.EnsureCreated();
            var contextOLD = context;
            var defaultUsers = new List<User>()
            {
                new User
                {
                    UserName = "user",
                    Email = "user@user.com",
                    FirstName = "Just",
                    LastName = "User",
                    EmailConfirmed = true
                },
                new User
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    FirstName = "Just",
                    LastName = "Admin",
                    EmailConfirmed = true
                }
            };

            var defaultPassword = "Admin1!";

            // Adding users
            if (!await userManager.Users.AnyAsync())
            {
                foreach (var u in defaultUsers)
                {
                    var result = await userManager.CreateAsync(u);
                    if (result.Succeeded)
                    {
                        await userManager.AddPasswordAsync(u, defaultPassword);
                        if(u.UserName == "admin")
                            await userManager.AddToRoleAsync(u, "Admin");
                        await userManager.AddToRoleAsync(u, "User");
                    }
                }
            }
            // If context changed
            if (contextOLD != context)
                await context.SaveChangesAsync();
        }
    }
}
