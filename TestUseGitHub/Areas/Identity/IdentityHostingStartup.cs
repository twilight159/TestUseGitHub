using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestUseGitHub.Models;

[assembly: HostingStartup(typeof(TestUseGitHub.Areas.Identity.IdentityHostingStartup))]
namespace TestUseGitHub.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TestUseGitHubContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TestUseGitHubContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<TestUseGitHubContext>();
            });
        }
    }
}