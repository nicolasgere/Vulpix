using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;


namespace Vulpix
{
    public class VulpixServer
    {
        private VulpixConfiguration _vulpixConfiguration = VulpixConfiguration.GetConfiguration();

        public void AddRoute(string methode, string url, Action<Req, Res> action)
        {
            _vulpixConfiguration.AddRoute(new Route(methode, url, action));
        }

        public void Use(Action<Req, Res> action)
        {
            var middleware = new Middleware(action);
            _vulpixConfiguration.AddMiddleware(middleware);
        }

        public void UseStaticFolder(String name)
        {
            _vulpixConfiguration._publicFolderName = name;
        }

        public void Listen(int port)
        {
            _vulpixConfiguration.SetRouter(new Router().Execute);

            var config = new ConfigurationBuilder()
            .AddEnvironmentVariables(prefix: "ASPNETCORE_")
            .Build();

            var host = new WebHostBuilder()
            .UseConfiguration(config)
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>()
            .UseUrls("http://localhost:" + port.ToString())
            .Build();

            host.Run();
        }

    }


}
