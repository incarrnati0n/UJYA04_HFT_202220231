using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UJYA04_HFT_20222023.Logic;
using UJYA04_HFT_20222023.Logic.LogicClasses;
using UJYA04_HFT_20222023.Models;
using UJYA04_HFT_20222023.Repository;

namespace UJYA04_HFT_20222023.Endpoint
{
    public class Startup
    {
  
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<FootyDbContext>();

            services.AddTransient<IRepository<Teams>, TeamsRepository>();
            services.AddTransient<IRepository<Managers>, ManagersRepository>();
            services.AddTransient<IRepository<Players>, PlayersRepository>();

            services.AddTransient<ITeamsLogic, TeamsLogic>();
            services.AddTransient<IManagersLogic, ManagersLogic>();
            services.AddTransient<IPlayersLogic, PlayersLogic>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "UJYA04_HFT_20222023.Endpoint", Version = "v1" });
            });
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UJYA04_HFT_20222023.Endpoint v1"));
            }


            app.UseExceptionHandler(c => c.Run(async context => 
            {
                var exception = context.Features
                        .Get<IExceptionHandlerPathFeature>()
                        .Error;
                var response = new { error = exception.Message};
                await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();   
            });
        }
    }
}
