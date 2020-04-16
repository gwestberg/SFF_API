using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SFF_API.Repositories;
using SFF_API.Context;
using Microsoft.EntityFrameworkCore;

namespace SFF_API
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
             services.AddScoped<IMovieRepository, MovieRepository>();
             services.AddScoped<IStudioRepository, StudioRepository>();
             services.AddScoped<IReviewRepository, ReviewRepository>();
             services.AddScoped<ITriviaRepository, TriviaRepository>();
             services.AddScoped<IRentalRepository, RentalRepository>();
            services.AddDbContext<RentalServiceContext>(opt =>
               opt.UseSqlite("Data Source = SFF_Database.db;"));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
