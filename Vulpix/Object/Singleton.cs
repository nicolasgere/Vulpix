
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

namespace Vulpix
{
public class Singleton
{

  public List<Route> list = new List<Route>();
  public List<Middleware> listMiddleware = new List<Middleware>();
  public Middleware last;
  public Middleware first;
  private Singleton()
  {
  }

  private static readonly Singleton _singleton = new Singleton();

  public List<Route> getRoute(){
    return list;
  }
  public Middleware getMiddleware(){
    return last;
  }
  public void setRoute(Route value){
    list.Add(value);
  }
  public void setMiddleware(Action<Req,Res,Middleware> value){
    var temp = new Middleware(value, this.last);
    if(last == null){
      first = temp;
    }
    last = temp;
  }
  public void setRouter(Action<Req,Res,Middleware> value){
    first.NextMiddleware = new Middleware(value, null);
  }

  public static Singleton GetSingleton()
  {
    return _singleton;
  }
}
}
