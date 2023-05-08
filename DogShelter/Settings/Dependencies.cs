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

            //AddRepositories(applicationBuilder.Services);
            //AddServices(applicationBuilder.Services);
        }

        private static void AddServices(IServiceCollection services)
        {
       
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<UnitOfWork>();
        }

    }
}
