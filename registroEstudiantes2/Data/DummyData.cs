﻿using Microsoft.AspNetCore.Identity;
using registroEstudiantes2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace registroEstudiantes2.Data
{
    public class DummyData
    {
        public static async Task Initialize(ApplicationDbContext context,
            UserManager<ApplicationUser>userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();
            string[] roleNames = { "admin", "estudiante", "docente" };
            foreach (var roleName in roleNames)
            {
                if (!roleManager.RoleExistsAsync(roleName).Result)
                {
                    ApplicationRole role = new ApplicationRole
                    {
                        Name = roleName,
                        NormalizedName = roleName
                    };
                    roleManager.CreateAsync(role).Wait();
                }
            }
            if (await userManager.FindByEmailAsync("admin1@gmail.com")==null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "admin1@gmail.com",
                    Email = "admin1@gmail.com",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };

                IdentityResult result = userManager.CreateAsync(user, "Admin1234$").Result;
                if(result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "admin").Wait();
                }
            }
        }
    }
}
