using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using Unikreativ.Entities.Data;
using Unikreativ.Entities.Entities;
using Unikreativ.Entities.Models.Auth;
using Unikreativ.Entities.ViewModel;
using Unikreativ.Helper.Auth;
using Unikreativ.Helper.Confirm;
using Unikreativ.Helper.Extensions;
using Unikreativ.Repositories.Interface;
using Unikreativ.Repositories.Repositories;
using Unikreativ.Repositories.UnitOfWork;
using Unikreativ.Services.Interface;
using Unikreativ.Services.Services;

namespace Unikreativ
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddCustomizedDataAccess(Configuration);
            services.AddUnikreativAuthorization();
            services.AddUnikreativJsonOption();
            services.AddCustomizedIdentity();
            services.AddUnikreativServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, Seeder seeder)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
                seeder.SeedUser();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            #region Handle Exception

            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Use(async (context, next) =>
                {
                    var error = context.Features[typeof(IExceptionHandlerFeature)] as IExceptionHandlerFeature;
                    //when authorization has failed, should retrun a json message to client
                    if (error?.Error is SecurityTokenExpiredException)
                    {
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new RequestResult
                        {
                            State = RequestState.NotAuth,
                            Msg = "token expired"
                        }));
                    }

                    //when orther error, retrun a error message json to client
                    else if (error != null && error.Error != null)
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new RequestResult
                        {
                            State = RequestState.Failed,
                            Msg = error.Error.Message
                        }));
                    }

                    //when no error, do next.
                    else await next();
                });
            });

            #endregion Handle Exception
            app.UseUnikreativJWT();
            app.UseIdentity();
            ApplicationBuilderExtension.GetAutoMapper();
            app.UseUnikreativCustomizedMvc();
        }

        
    }
}