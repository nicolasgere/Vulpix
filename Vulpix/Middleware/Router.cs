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
using System.Reflection;

namespace Vulpix
{
    public class Router
    {
        public async void exec(Req req, Res res, Middleware middle){

          var config = Singleton.GetSingleton();
          var list = config.getRoute();

          string path = req.context.Path;

          var arrayPath = path.Split('/');

          var functionName = "";
          var methodHTTP = req.context.Method;
          var execute = false;
          var index = 0;

          ResultValidate resultat = new ResultValidate();

          while(!execute && index != list.Count()){
              resultat = list[index].ValidateRoute(methodHTTP, arrayPath);
              execute = resultat.valid;
              if(!execute){
                  index++;
              }else{
              }
          }
          if(execute){
              if(req.context.Body.CanRead && !req.context.HasFormContentType){
                  StreamReader reader = new StreamReader(req.context.Body);
                  string text = reader.ReadToEnd();
                  req.body = text;
              }
              req.paramsUrl = resultat.paramsUrl;
              if(req.context.HasFormContentType){
                  var form = await req.context.ReadFormAsync();
                  req.form = form;
              }


              list[index].Execute(req, res);
          }else{
              //ERROR 404
          }
        }
    }
}
