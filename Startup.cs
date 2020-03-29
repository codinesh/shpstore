using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Groc.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Groc.Services;

namespace Groc
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
            services.AddDbContext<GrocIdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("GrocIdentityDbContextConnectionAzure")));
            services.AddDefaultIdentity<GroceriesUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<GrocIdentityDbContext>();
            services.AddTransient<IdentityUser<int>, GroceriesUser>();
            services.AddRazorPages();
            // services.AddAuthentication()
            //.AddMicrosoftAccount(microsoftOptions => { ... })
            // .AddGoogle(options =>
            // {
            //     IConfigurationSection googleAuthNSection =
            //         Configuration.GetSection("Authentication:Google");

            //     options.ClientId = googleAuthNSection["ClientId"];
            //     options.ClientSecret = googleAuthNSection["ClientSecret"];
            //     options.ClaimActions.MapJsonKey("urn:google:picture", "picture", "url");
            //     options.SaveTokens = true;

            //     options.Events.OnCreatingTicket = ctx =>
            //     {
            //         List<AuthenticationToken> tokens = ctx.Properties.GetTokens().ToList();

            //         tokens.Add(new AuthenticationToken()
            //         {
            //             Name = "TicketCreated",
            //             Value = DateTime.UtcNow.ToString()
            //         });

            //         ctx.Properties.StoreTokens(tokens);

            //         return Task.CompletedTask;
            //     };
            // });
            //.AddTwitter(twitterOptions => { ... })
            //.AddFacebook(facebookOptions => { ... });

            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
    }
}
