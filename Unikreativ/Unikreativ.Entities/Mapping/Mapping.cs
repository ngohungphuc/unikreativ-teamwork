using System;
using System.Linq.Expressions;
using Unikreativ.Entities.Entities;
using Unikreativ.Entities.ViewModel;

namespace Unikreativ.Entities.Mapping
{
    public static class Mapping
    {
        public static Expression<Func<User, Member>> MemberMapping
        {
            get
            {
                return member => new Member
                {
                    Id = member.Id,
                    Email = member.Email,
                    CompanyName = member.CompanyName,
                    JobTitle = member.JobTitle,
                    NormalizedUserName = member.NormalizedUserName,
                    PhoneNumber = member.PhoneNumber,
                    ChargeRate = member.ChargeRate,
                    Role = member.Roles.ToString()
                };
            }
        }

        public static Expression<Func<User, Client>> ClientMapping
        {
            get
            {
                return client => new Client
                {
                    Id = client.Id,
                    Email = client.Email,
                    CompanyName = client.CompanyName,
                    Address = client.Address,
                    Country = client.Country,
                    Industry = client.Industry,
                    PhoneNumber = client.PhoneNumber,
                    UserName = client.UserName,
                    Website = client.Website
                };
            }
        }
    }
}