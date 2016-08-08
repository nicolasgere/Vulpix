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
    public class BobCore
    {
        
        List<Route> list = new List<Route>();
        List<Middleware> listMiddleware = new List<Middleware>();
        
        public void ConfigureServices(IServiceCollection services)
        {

        }
        public void Use(Action<Req,Res> action) {
            listMiddleware.Add(new Middleware(action));
        }
        public void AddRoute(string methode, string url, Action<Req,Res> action) {
            list.Add(new Route(methode,url, action));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            
            app.Run(async (context) =>
            {
                string path = context.Request.Path; 
                var arrayPath = path.Split('/');
                var functionName = "";
                var methodHTTP = context.Request.Method;
                var execute = false;
                var index = 0;
                var res = new Res(context);
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
                    var req = new Req();
                    if(context.Request.Body.CanRead && !context.Request.HasFormContentType){
                        StreamReader reader = new StreamReader(context.Request.Body);
                        string text = reader.ReadToEnd();
                        req.body = text;
                    }
                    req.paramsUrl = resultat.paramsUrl;
                    if(context.Request.HasFormContentType){
                        var form = await context.Request.ReadFormAsync();
                        req.form = form;
                    }    
                     list[index].Execute(req, res);
                }else{
                    //ERROR 404
                } 
            });
            
        }
    }
}
