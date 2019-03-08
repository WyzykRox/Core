using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Core.Models.Entities;
using Infrastructure.DAO.Data;
using System;

namespace Infrastructure.DAO.Initializers
{
    public class RoleInitializer
    {
        public static async Task Initialize (RoleManager<Role> roleManager,
            ApplicationDbContext context)
        {

            context.Database.EnsureCreated();
            var contextOLD = context;

            var defaultRoles = new List<Role>()
            {
                new Role() { Name="Admin",   Description = "This is the administrator role" },
                new Role() { Name="User",    Description = "This is the user role" }
            };

            // Adding roles
            if (!await roleManager.Roles.AnyAsync())
            {
                foreach (var r in defaultRoles)
                {
                    r.CreatedDate = DateTime.Now;
                    await roleManager.CreateAsync(r);
                }
            }
           
            // If context changed
            if (contextOLD != context)
                await context.SaveChangesAsync();
        }
    }
}
