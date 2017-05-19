using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Unikreativ.Entities.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Unikreativ.Entities.Data
{
    public static class Seeder
    {
        public static async void SeedUser(IApplicationBuilder app)
        {
            using (var context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>())
            {
                string[] roles = new string[] { "Administrator", "Manager", "Developer", "Accountant", "Designer", "Client", "Watcher" };

                foreach (var role in roles)
                {
                    var roleStore = new RoleStore<IdentityRole>(context);
                    //add default  role to db
                    if (!context.Roles.Any(r => r.Name == role))
                    {
                        await roleStore.CreateAsync(new IdentityRole(role));
                    }
                }

                var user = new User
                {
                    Email = "helentran2609@gmail.com",
                    UserName = "helentran",
                    NormalizedUserName = "HelenTran",
                    PhoneNumber = "0937005331",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    LockoutEnabled = false,
                    FullName = "Trần Mai Phương",
                    JobTitle = "Web Developer",
                    CompanyName = "Unikreativ",
                    ChargeRate = 14,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Industries = User.Industry.Technology
                };
                var userStore = new UserStore<User>(context);
                //create user account and assign role for account
                if (!context.Users.Any(u => u.UserName == user.UserName))
                {
                    var password = new PasswordHasher<User>();
                    var hashed = password.HashPassword(user, "tranmaiphuong2609");
                    user.PasswordHash = hashed;

                    var result = await userStore.CreateAsync(user);
                    if (result.Succeeded)
                    {
                        await userStore.AddToRoleAsync(user, roles[0]);
                    }
                }
            }
        }
    }
}