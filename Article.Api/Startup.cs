using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Article.Domain.StoreContext.Handlers;
using Article.Domain.StoreContext.Repositories;
using Article.Infra.DataContext;
using Article.Infra.StoreContext.Repositories;
using Swashbuckle.AspNetCore.Swagger;
using Elmah.Io.AspNetCore;
using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using Article.Shared;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Article.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();

            services.AddResponseCompression();

            services.AddScoped<StoreDataContext, StoreDataContext>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<ArticleHandler, ArticleHandler>();

            // ********************
            // Setup CORS
            // ********************
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin(); // For anyone access.
            //corsBuilder.WithOrigins("http://localhost:56573"); // for a specific url. Don't add a forward slash on the end!
            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });

            //Use to documation the API
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "Store", Version = "v1" });
            });

            //Use to check the log of the API
            services.AddElmahIo(o =>
            {
                o.ApiKey = "f8ccf30d57a14f67a3f8b14033a72663";
                o.LogId = new Guid("5aca14d5-4ec9-437c-899e-fa26aed2c001");
            });

            Settings.ConnectionString = $"{Configuration["connectionString"]}";
            Console.Write($"{Configuration["connectionString"]}");

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDeveloperExceptionPage();

            app.UseMvc();
            app.UseResponseCompression();

            //config documentation
            app.UseSwagger(); // url html: http://localhost:5000/swagger/index.html
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Store - V1");
            });

            //config log   
            app.UseElmahIo();
        }
    }
}
