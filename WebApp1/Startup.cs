using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using WebApp1.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using WebApp1.Services;
using WebApp1.Areas.Identity.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;



namespace WebApp1
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<WebApp1.Areas.Identity.Data.WebApp1User>(options => options.SignIn.RequireConfirmedAccount = true)
               .AddRoles<IdentityRole>()
               
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // requires
            // using Microsoft.AspNetCore.Identity.UI.Services;
            // using WebPWrecover.Services;
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);

<<<<<<< HEAD

           services.AddDbContext<OutcomesContext>(options =>
                    options.UseSqlite(Configuration.GetConnectionString("OutcomesContext")));

                      
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
            }
            );
=======
            services.AddAuthorization();
>>>>>>> b9bb2329eac1893a631f16227e0981cd0ffc93aa
           
            services.AddRazorPages(options => {
               
				options.Conventions.AuthorizeFolder("/");
                options.Conventions.AuthorizePage("/Private/Roles" , "AdminOnly");
                 

			});
            

			ConfigureRoles(services.BuildServiceProvider()).GetAwaiter().GetResult();
            

            services.AddDbContext<OutcomesContext>(options =>
                    options.UseSqlite(Configuration.GetConnectionString("OutcomesContext")));

            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }

       private async Task ConfigureRoles(ServiceProvider serviceProvider)
		{

			var roleMgr = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var exists = await roleMgr.RoleExistsAsync("Admin");
			if (!exists)
			{
				var admin = new IdentityRole
				{
					Name = "Admin"
				};
				await roleMgr.CreateAsync(admin);
			}

			var adminRole = await roleMgr.FindByNameAsync("Admin");
			var userMgr = serviceProvider.GetRequiredService<UserManager<WebApp1User>>();
			var user = await userMgr.FindByEmailAsync("ealfaloujeh1@buffs.wtamu.edu");
          
            

			if (user != null)
			{

				var isAdmin = await userMgr.IsInRoleAsync(user, "Admin");
				if (!isAdmin)
				{
					await userMgr.AddToRoleAsync(user, "Admin");
				}
                var claims = await userMgr.GetClaimsAsync(user);
                if (user.IsAdmin)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                }
                
				

			}
        }

		
    }
}
