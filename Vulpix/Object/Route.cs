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
 public class ResultValidate{
     public bool valid;
     public Dictionary<string, string> paramsUrl;
     public ResultValidate(){
         this.valid = true;
         this.paramsUrl = new Dictionary<string, string>();
     }
 }
 public class Route{
     private string methode;
     private string route;
     private string[] routeSplit;
     private Action<Req,Res> action;
     public Route(string methode, string route, Action<Req,Res> action){
         this.methode = methode;
         this.action = action;
         this.route = route;
         this.routeSplit = route.Split('/');
     }
     public void Execute(Req req,Res res){
         action(req,res);
     }

     public ResultValidate ValidateRoute(string method, string[] url){
         var i = 0;
         var y = 0;
         var result = new ResultValidate();
         if(methode != this.methode){
             result.valid = false;
             return result;
         }
         while(result.valid && i != url.Count() && y !=routeSplit.Count()){
             bool paramsPresent = false;
             if(!String.IsNullOrEmpty(routeSplit[y]) && routeSplit[y][0]==':'){
                 paramsPresent = true;
                 result.paramsUrl.Add(routeSplit[y].Replace(":","") , url[i]);
             }

             if(url[i] == routeSplit[y] || paramsPresent){

             }else{
                 result.valid = false;
             }
             y++;
             i++;
         }
         if(i != url.Count() || y != routeSplit.Count()){
             result.valid = false;
         }
         return result;
     }
 }
}
