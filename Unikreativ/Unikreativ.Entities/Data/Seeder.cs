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
    public class Seeder
    {
        private ApplicationDbContext _context;

        public Seeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public async void SeedUser()
        {
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

            var client = new User
            {
                Email = "kmstechnology@com.vn",
                UserName = "kms",
                CompanyName = "KMS",
                Website = "http://www.kms-technology.com/",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                LockoutEnabled = false,
                PhoneNumber = "(+84) 8 3811 9977",
                SecurityStamp = Guid.NewGuid().ToString(),
                Industries = User.Industry.Technology
            };

            var roleStore = new RoleStore<IdentityRole>(_context);

            if (!_context.Roles.Any(r => r.Name == "Administrator"))
            {
                string[] roles = new string[]
                    {"Administrator", "Manager", "Developer", "Accountant", "Designer", "Client", "Watcher"};

                foreach (var role in roles)
                {
                    await roleStore.CreateAsync(new IdentityRole { Name = role, NormalizedName = role });
                }
            }

            if (!_context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<User>();
                user.PasswordHash = password.HashPassword(user, "tranmaiphuong2609");
                client.PasswordHash = password.HashPassword(user, "kms123");

                var userStore = new UserStore<User>(_context);
                await userStore.CreateAsync(user);
                await userStore.AddToRoleAsync(user, "Administrator");

                await userStore.CreateAsync(client);
                await userStore.AddToRoleAsync(client, "Client");
            }

            await _context.SaveChangesAsync();
        }
    }
}