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
using bob;

namespace test
{
 public class Route{
     private string methode;
     private string route;
     private Action<Req,HttpContext> action;
     public Route(string methode, string route, Action<Req,HttpContext> action){
         this.methode = methode;
         this.action = action;
         this.route = route;
     }
     public void Execute(Req req,HttpContext res){
         action(req,res);
     }
 }
}
