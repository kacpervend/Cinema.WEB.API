using Application.Mappings;
using Application.Services;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cinema.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Dependency register

            builder.Services.AddScoped<ICinemaRepository, CinemaRepository>();
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<IAddressRepository, AddressRepository>();

            builder.Services.AddScoped<ICinemaService, CinemaService>();
            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddScoped<IAddressService, AddressService>();

            builder.Services.AddSingleton(AutoMapperConfig.Initialize());

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<CinemaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Cinema")));

            builder.Services.AddScoped<CinemaSeeder>();

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<CinemaSeeder>();
                seeder.Seed();
            }

            app.Run();
        }
    }
}
