using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Unikreativ.Entities.Entities;

namespace Unikreativ.Entities.Data
{
    public class Seeder
    {
        private readonly ApplicationDbContext _context;

        public Seeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public async void SeedUser()
        {
            string[] roles = new string[] { "Administrator", "Manager", "Developer", "Accountant", "Designer", "Client", "Watcher" };

            foreach (var role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(_context);
                //add default  role to db
                if (!_context.Roles.Any(r => r.Name == role))
                {
                    await roleStore.CreateAsync(new IdentityRole(role));
                }
            }

            var user = new ApplicationUser
            {
                Email = "helentran2609@gmail.com",
                UserName = "helentran",
                NormalizedUserName = "HelenTran",
                PhoneNumber = "0937005331",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                FullName = "Trần Mai Phương",
                JobTitle = "Web Developer",
                CompanyName = "Unikreativ",
                ChargeRate = 14
            };

            //create user account and assign role for account
            if (!_context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "tranmaiphuong2609");
                user.PasswordHash = hashed;

                var userStore = new UserStore<ApplicationUser>(_context);
                await userStore.CreateAsync(user);
                await userStore.AddToRoleAsync(user, "Administrator");
            }
        }
    }
}