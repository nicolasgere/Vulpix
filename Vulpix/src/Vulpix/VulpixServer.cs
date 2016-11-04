using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;

using Vulpix.Middlewares;
using Vulpix.Objects;

namespace Vulpix
{

  public class VulpixServer {
    private VulpixConfiguration _VulpixConfiguration  = VulpixConfiguration.GetConfiguration();

    public void AddRoute(string methode, string url, Action<Req,Res> action) {
      _VulpixConfiguration.AddRoute(new Route(methode,url, action));
    }
    public void Use(Action<Req,Res,Middleware> action) {
      _VulpixConfiguration.AddMiddleware(action);
    }
    public void UseStaticFolder(String name){
      _VulpixConfiguration.SetPublicFolder(name);
    }
    public void Listen(int port){
      _VulpixConfiguration.SetRouter(new Router().Execute);
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
