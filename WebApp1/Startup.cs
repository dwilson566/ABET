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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApp1.Areas.Identity.Data;

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
            services.AddDefaultIdentity<WebApp1.Areas.Identity.Data.WebApp1User>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Administrator"));
                options.AddPolicy("AbetAccredited", policy => policy.RequireRole("Accreditor"));
                options.AddPolicy("ProfessorOnly", policy => policy.RequireRole("Professor"));

                // options.AddPolicy("AdminAndAbet", 
                //     policy => policy.RequireRole("AbetAccredited", "AdminOnly"));

                
            
            });

			services.AddRazorPages(options => {
                    
				options.Conventions.AuthorizePage("/Secret", "AdminOnly" );
                options.Conventions.AuthorizePage("/Abet", "AbetAccredited" );
                
                options.Conventions.AuthorizePage("/Professor",  "ProfessorOnly" );
                options.Conventions.AuthorizePage("/Student");


			});
            ConfigureRoles(services.BuildServiceProvider()).GetAwaiter().GetResult();

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
            ///////////////////---Administrator Role-----/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			var roleMgr = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var exists = await roleMgr.RoleExistsAsync("Administrator");
			if (!exists)
			{
				var admin = new IdentityRole
				{
					Name = "Administrator"
				};
				await roleMgr.CreateAsync(admin);
			}

			var adminRole = await roleMgr.FindByNameAsync("Administrator");
			var userMgr = serviceProvider.GetRequiredService<UserManager<WebApp1User>>();
			var user = await userMgr.FindByEmailAsync("admin@gmail.com");

			if (user != null)
			{

				var isAdmin = await userMgr.IsInRoleAsync(user, "Administrator");
				if (!isAdmin)
				{
					await userMgr.AddToRoleAsync(user, "Administrator");
				}
            }
            ///////////////////////////---Accreditor Role-----/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			
            var roleAcc = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var existsOne = await roleAcc.RoleExistsAsync("Accreditor");
			if (!existsOne)
			{
				var accre = new IdentityRole
				{
					Name = "Accreditor"
				};
				await roleAcc.CreateAsync(accre);
			}

			var AccreRole = await roleAcc.FindByNameAsync("Accreditor");
			var AccewMgr = serviceProvider.GetRequiredService<UserManager<WebApp1User>>();
			var userOne = await AccewMgr.FindByEmailAsync("accreditor@gmail.com");

			if (userOne != null)
			{

				var isAccre = await AccewMgr.IsInRoleAsync(userOne, "Accreditor");
				if (!isAccre)
				{
					await AccewMgr.AddToRoleAsync(userOne, "Accreditor");
				}
            }

             /////////////////////////---Professor Role-----/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			
            var roleProfessor = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var existsTwo = await roleProfessor.RoleExistsAsync("Professor");
			if (!existsTwo)
			{
				var profess = new IdentityRole
				{
					Name = "Professor"
				};
				await roleProfessor.CreateAsync(profess);
			}

			var ProfeRole = await roleProfessor.FindByNameAsync("Professor");
			var ProfeMgr = serviceProvider.GetRequiredService<UserManager<WebApp1User>>();
			var userTwo = await ProfeMgr.FindByEmailAsync("professor@gmail.com");

			if (userTwo != null)
			{

				var isProfes = await ProfeMgr.IsInRoleAsync(userTwo, "Professor");
				if (!isProfes)
				{
					await ProfeMgr.AddToRoleAsync(userTwo, "Professor");
				}
            }
            


			

        }
    }
}
