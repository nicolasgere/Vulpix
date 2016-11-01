
using System;
using System.Collections.Generic;


namespace Vulpix.Objects
{
public class VulpixConfiguration
{

  private List<Route> _ListRoute = new List<Route>();
  private List<Middleware> _ListMiddleware = new List<Middleware>();
  private String _PublicFolder ;
  private Middleware _Last;
  private Middleware _First;
  private VulpixConfiguration()
  {
  }

  private static readonly VulpixConfiguration _singleton = new VulpixConfiguration();

  public List<Route> GetRoute(){
    return _ListRoute;
  }
  public Middleware GetMiddleware(){
    return _Last;
  }
  public void AddRoute(Route value){
    _ListRoute.Add(value);
  }
  public void SetPublicFolder(String name){
    _PublicFolder = name;
  }

  public string GetPublicFolder(){
    return _PublicFolder;
  }
  public void AddMiddleware(Action<Req,Res,Middleware> value){
    var newMiddleware = new Middleware(value, this._Last);
    if(_Last == null){
      _First = newMiddleware;
    }
    _Last = newMiddleware;
  }
  public void SetRouter(Action<Req,Res,Middleware> value){
    if(_First!= null){
      _First.NextMiddleware = new Middleware(value, null);
    }else{
      _First = new Middleware(value, null);
      _Last = _First;
    }
  }

  public static VulpixConfiguration GetConfiguration()
  {
    return _singleton;
  }
}
}
