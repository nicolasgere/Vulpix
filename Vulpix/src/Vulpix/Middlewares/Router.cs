using System;
using System.Collections.Generic;
using System.Linq;
using Vulpix.Objects;

namespace Vulpix.Middlewares
{
    public class Router
    {
        
        private VulpixConfiguration VulpixConfiguration = VulpixConfiguration.GetConfiguration();
        private List<Route> Routes;

        public Router (){
            Routes =  VulpixConfiguration.GetRoute();
        }
        public async void Execute(Req req, Res res, Middleware middle){

          string path = req.Context.Path;
          var arrayPath = path.Split('/');

          var methodHTTP = req.Context.Method;
          var execute = false;
          var index = 0;
          ResultValidate resultat = new ResultValidate();
          while(!execute && index != Routes.Count()){
              resultat = Routes[index].ValidateRoute(methodHTTP, arrayPath);
              execute = resultat.IsValid;
              if(!execute){
                  index++;
              }else{
              }
          }
          if(execute){
              req.ParamsUrl = resultat.ParamsUrl;
              if(req.Context.HasFormContentType){
                  var form = await req.Context.ReadFormAsync();
                  req.Form = form;
              }


               Routes[index].Execute(req, res);
          }else{
             await res.Send("Not found",404);
          }
        }
    }
}
