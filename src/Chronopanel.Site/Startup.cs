using Chronopanel.Site.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NodaTime;
using NodaTime.TimeZones;
using System.Collections.Generic;
using WebMarkupMin.AspNetCore1;
using WebMarkupMin.Core;

namespace Chronopanel.Site
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IEnumerable<ColorSwatch> colorSwatches = new List<ColorSwatch>();

            Configuration.GetSection("color-swatches").Bind(colorSwatches);

            services.AddSingleton(colorSwatches);

            services.AddSingleton<IClock>(SystemClock.Instance);
            services.AddSingleton<IDateTimeZoneProvider>(DateTimeZoneProviders.Tzdb);
            services.AddSingleton<TzdbDateTimeZoneSource>(TzdbDateTimeZoneSource.Default);

            services
                .AddWebMarkupMin(options =>
                {
                    options.AllowMinificationInDevelopmentEnvironment = true;
                    options.AllowCompressionInDevelopmentEnvironment = true;
                })
                .AddHtmlMinification(options =>
                {
                    options.MinificationSettings.WhitespaceMinificationMode = WhitespaceMinificationMode.Aggressive;
                })
                .AddHttpCompression();

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseWebMarkupMin();

            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.Headers.ContainsKey("Content-Length"))
                {
                    context.Response.Headers.Remove("Content-Length");
                }
            });

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
