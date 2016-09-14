
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
public class Singleton
{
  public string test = "voiture";
  public List<Route> list = new List<Route>();
  public List<Middleware> listMiddleware = new List<Middleware>();
  private Singleton()
  {
    // Prevent outside instantiation
  }

  private static readonly Singleton _singleton = new Singleton();

  public string getValue(){
    return test;
  }
  public List<Route> getRoute(){
    return list;
  }
  public List<Middleware> getMiddleware(){
    return listMiddleware;
  }
  public void setValue(string value){
    this.test = value;
  }
  public void setRoute(Route value){
    list.Add(value);
  }
  public void setMiddleware(Middleware value){
    listMiddleware.Add(value);
  }

  public static Singleton GetSingleton()
  {
    return _singleton;
  }
}
}
