using API_Agenda.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace API_Agenda
{
    public class Start
    {
        public Start(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EntityDB>(options =>
                options.UseInMemoryDatabase("InMemoryDatabase"));
            services.AddScoped<EventoService>();
            

         
        }
    }
}
