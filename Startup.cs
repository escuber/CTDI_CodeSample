using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

using Microsoft.AspNetCore.Authorization;
using AspNet.Security.OAuth.Validation;
using Microsoft.AspNetCore.Identity;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using System.Collections.Generic;

using Microsoft.Net.Http.Headers;
using Microsoft.AspNet.OData.Extensions;
using CTDI_Food.data.models;
using CTDI_Food.data.contexts;
using Microsoft.OData.Edm;
using Microsoft.AspNet.OData.Builder;
using CTDI_Food.data.bo;

namespace CTDI_Food
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration/*, IHostingEnvironment env*/)
        {
            Configuration = configuration;
        }


        // this is the setup for the odata objects
        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<product>("product");
            builder.EntitySet<productDiscount>("productDiscount");
            builder.EntitySet<discount>("discount");

            return builder.GetEdmModel();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ViewModels.MapperVm.AutoMapperConfig.Init();

            // Configure Identity options and password complexity here
            services.Configure<IdentityOptions>(options =>
            {
                // User settings
                options.User.RequireUniqueEmail = true;
            });

            


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = OAuthValidationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OAuthValidationDefaults.AuthenticationScheme;
            }).AddOAuthValidation();


            // Add cors
            services.AddCors();

            // Add framework services.
            services.AddMvc();
            /* ODATA part */
            services.AddOData();


            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "CTDI_Food API", Version = "v1" });

                c.AddSecurityDefinition("OpenID Connect", new OAuth2Scheme
                {
                    Type = "oauth2",
                    Flow = "password",
                    TokenUrl = "/connect/token"
                });
            });

            // add application developed dependancies
            services.AddScoped<productsContext>(ctx => new productsContext(productsContext.CreateNewContextOptions()));
            services.AddScoped<catalogbo>(ctx => new catalogbo(new productsContext(productsContext.CreateNewContextOptions())));


        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug(LogLevel.Warning);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Enforce https during production
                //var rewriteOptions = new RewriteOptions()
                //    .AddRedirectToHttps();
                //app.UseRewriter(rewriteOptions);


                app.UseExceptionHandler("/Home/Error");
            }


            //Configure Cors
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());


            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = (context) =>
                {
                    var headers = context.Context.Response.GetTypedHeaders();

                    headers.CacheControl = new CacheControlHeaderValue
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromDays(365)
                    };
                }
            });
            app.UseSpaStaticFiles();
            app.UseAuthentication();


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CTDI_Food API V1");
            });


            app.UseMvc(rb =>
            {
                rb.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
                rb.Count().Filter().OrderBy().Select().MaxTop(null);
                rb.MapODataServiceRoute("odata", "odata", GetEdmModel());
                rb.EnableDependencyInjection();
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
