using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Vulpix
{

     public class Middleware{
         private Action<Req,Res, Middleware> action;
         public Middleware NextMiddleware;
         public Middleware(Action<Req,Res,Middleware > action, Middleware next){
             this.action = action;
             this.NextMiddleware = next;
         }
         public void Next(Req req, Res res){
            if(this.NextMiddleware != null){
           NextMiddleware.Execute( req, res);
             }
         }
         public void Execute(Req req, Res res){
            action(req,res,this);
         }
    }
}
