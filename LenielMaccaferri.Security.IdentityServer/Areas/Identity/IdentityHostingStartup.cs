using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(LenielMaccaferri.Security.IdentityServer.Areas.Identity.IdentityHostingStartup))]
namespace LenielMaccaferri.Security.IdentityServer.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}