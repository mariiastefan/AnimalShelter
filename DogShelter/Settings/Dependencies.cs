using DogShelter.Repositories;
using DogShelter.Services;
using System;

namespace DogShelter.Settings
{
    public static class Dependencies
    {
        public static void Inject(WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddControllers();
            applicationBuilder.Services.AddSwaggerGen();

            applicationBuilder.Services.AddDbContext<AppDBContext>();

            AddRepositories(applicationBuilder.Services);
            AddServices(applicationBuilder.Services);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<UserService>();
            services.AddScoped<AuthorizationService>();
            services.AddScoped<DogService>();
            services.AddScoped<DetailsService>();
            services.AddScoped<AdoptionService>();
            services.AddScoped<DonationService>();

        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<UnitOfWork>();
            services.AddScoped<UserRepository>();
            services.AddScoped<RoleRepository>();
            services.AddScoped<DogRepository>();
            services.AddScoped<DetailsRepository>();
            services.AddScoped<AdoptionRepository>();
            services.AddScoped<DonationRepository>();
        }

    }
}
