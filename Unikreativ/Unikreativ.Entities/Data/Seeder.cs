using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Unikreativ.Entities.Entities;

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
            var helen = new User
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
                Industry = "Technology"
            };

            var tony = new User
            {
                Email = "ngohungphuc95@gmail.com",
                UserName = "tony",
                NormalizedUserName = "TonyHudson",
                PhoneNumber = "01269976689",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                LockoutEnabled = false,
                FullName = "Ngô Hùng Phúc",
                JobTitle = "Web Developer",
                CompanyName = "None",
                ChargeRate = 14,
                SecurityStamp = Guid.NewGuid().ToString(),
                Industry = "Technology"
            };

            var client = new User
            {
                Email = "kmstechnology@com.vn",
                UserName = "kms",
                Address = "123 Cộng Hòa Quận Tân Bình",
                Country = "Việt Nam",
                CompanyName = "KMS",
                Website = "http://www.kms-technology.com/",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                LockoutEnabled = false,
                PhoneNumber = "(+84) 8 3811 9977",
                SecurityStamp = Guid.NewGuid().ToString(),
                Industry = "Technology"
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

            if (!_context.Users.Any(u => u.UserName == helen.UserName))
            {
                var password = new PasswordHasher<User>();
                helen.PasswordHash = password.HashPassword(helen, "tranmaiphuong2609");
                tony.PasswordHash = password.HashPassword(tony, "tony95");
                client.PasswordHash = password.HashPassword(client, "kms123");

                var userStore = new UserStore<User>(_context);

                await userStore.CreateAsync(helen);
                await userStore.AddToRoleAsync(helen, "Administrator");

                await userStore.CreateAsync(tony);
                await userStore.AddToRoleAsync(tony, "Developer");

                await userStore.CreateAsync(client);
                await userStore.AddToRoleAsync(client, "Client");
            }

            await _context.SaveChangesAsync();
        }
    }
}