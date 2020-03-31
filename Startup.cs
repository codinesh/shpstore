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
using Groc.AuthorizationHandlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace Groc
{
    public class Startup
    {
        private readonly IWebHostEnvironment env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            this.env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (env.IsProduction())
            {
                services.AddDbContext<GrocIdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("GrocIdentityDbContextConnectionAzure")));
            }
            else if (env.IsDevelopment())
            {
                services.AddDbContext<GrocIdentityDbContext>(options =>
                options.UseSqlite(
                        Configuration.GetConnectionString("GrocIdentityDbContextConnection")));
            }

            services.AddDefaultIdentity<GroceriesUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<GrocIdentityDbContext>();

            services.AddTransient<IdentityUser<int>, GroceriesUser>();
            services.AddRazorPages();

            services.AddControllers(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

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

            services.AddScoped<IAuthorizationHandler, UserAuthHandler>();
            services.AddSingleton<IAuthorizationHandler, AdminAuthHandler>();
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
                app.UseExceptionHandler("/");
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
