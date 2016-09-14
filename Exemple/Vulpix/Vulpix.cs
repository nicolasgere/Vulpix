using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using test;

namespace bob
{

  public class Vulpix {
    public Singleton config  = Singleton.GetSingleton();

    public void AddRoute(string methode, string url, Action<Req,Res> action) {
      config.setRoute(new Route(methode,url, action));
    }
    public void Use(Action<Req,Res> action) {
      config.setMiddleware(new Middleware(action));
    }
    public void listen(){
      var config = new ConfigurationBuilder()
      .AddEnvironmentVariables(prefix: "ASPNETCORE_")
      .Build();

      var host = new WebHostBuilder()
      .UseConfiguration(config)
      .UseKestrel()
      .UseContentRoot(Directory.GetCurrentDirectory())
      .UseIISIntegration()
      .UseStartup<Startup>()
      .Build();

      host.Run();
    }

  }
  public class Startup : VulpixCore
  {

    public Startup(){
      var config = Singleton.GetSingleton();
      base.setRoute(config.getRoute());
      base.setMiddleware(config.getMiddleware());
    }
  }

}
