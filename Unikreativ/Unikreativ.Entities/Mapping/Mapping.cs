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
                    Phone = member.PhoneNumber,
                    Role = member.Roles.ToString()
                };
            }
        }
    }
}