using System.Reflection;
using FluentValidation;
using Iteris.Meetup.CQRS.Api.Behaviors;
using Iteris.Meetup.CQRS.Data.Repositories;
using Iteris.Meetup.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Iteris.Meetup.CQRS.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Iteris.Meetup.CQRS.Api", Version = "v1"});
            });
            services.AddMemoryCache();

            var assemblies = new[]
                {Assembly.Load("Iteris.Meetup.CQRS.Command"), Assembly.Load("Iteris.Meetup.CQRS.Query")};
            services.AddMediatR(assemblies);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggerBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));

            AssemblyScanner.FindValidatorsInAssemblies(assemblies)
                           .ForEach(v => services.AddScoped(v.InterfaceType, v.ValidatorType));

            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddSingleton<ICacheDbRepository, CacheDbRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Iteris.Meetup.CQRS.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
