using Microsoft.EntityFrameworkCore;
using WebApplication6.DAL;

namespace WebApplication6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(opt => 
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            
            });
            

            var app = builder.Build();
            app.UseStaticFiles();

 app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=DashBoard}/{action=Index}/{id?}"
          );

            app.MapControllerRoute
                (
                name:"Default",
                pattern:"{controller=Home}/{action=Index}/{Id?}"
                );
            
            app.Run();
        }
    }
}
