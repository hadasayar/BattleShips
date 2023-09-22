using Microsoft.Extensions.DependencyInjection;


namespace BattleShipGame
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost4200", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
        }
        public void Configure(IApplicationBuilder app)
        {
            // Use the CORS policy in the request pipeline
            app.UseCors("AllowLocalhost4200");

            // Other middleware and routing configuration...
        }
    }
}
