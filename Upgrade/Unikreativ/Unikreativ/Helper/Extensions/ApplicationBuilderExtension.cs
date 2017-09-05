using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unikreativ.Entities.Entities;
using Unikreativ.Entities.ViewModel;
using Unikreativ.Helper.Auth;

namespace Unikreativ.Helper.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseUnikreativJWT(this IApplicationBuilder app)
        {
            //app.UseJwtBearerAuthentication(new JwtBearerOptions()
            //{
            //    TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        IssuerSigningKey = TokenAuthOption.Key,
            //        ValidAudience = TokenAuthOption.Audience,
            //        ValidIssuer = TokenAuthOption.Issuer,
            //        // When receiving a token, check that we've signed it.
            //        ValidateIssuerSigningKey = true,
            //        // When receiving a token, check that it is still valid.
            //        ValidateLifetime = true,
            //        // This defines the maximum allowable clock skew - i.e. provides a tolerance on the token expiry time
            //        // when validating the lifetime. As we're creating the tokens locally and validating them on the same
            //        // machines which should have synchronised time, this can be set to zero. Where external tokens are
            //        // used, some leeway here could be useful.
            //        ClockSkew = TimeSpan.FromMinutes(0)
            //    }
            //});
            return app;
        }

        public static IApplicationBuilder UseUnikreativCustomizedMvc(this IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute("spa",
                    "{*anything}",
                    new { controller = "Home", action = "Index" });
            });

            return app;
        }

        public static void GetAutoMapper()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Client, User>();
                cfg.CreateMap<Member, User>();
                cfg.CreateMap<ProjectViewModel, Project>();
            });
        }
    }
}
