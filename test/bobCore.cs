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
    public class bobCore
    {
        
        List<Route> list = new List<Route>();
        
        
        public void ConfigureServices(IServiceCollection services)
        {

        }
        public void AddRoute(string methode, string url, Action<Req,HttpContext> action) {
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
                //list[0].Execute();
                string path = context.Request.Path; 
                var arrayPath = path.Split('/');
                var functionName = "";
                var methodHTTP = context.Request.Method;
                if(arrayPath.Count() == 2){
                    functionName = "Index";
                }else if(arrayPath.Count() == 3){
                    functionName = arrayPath[2];
                }
                var req = new Req();
                if(context.Request.Body.CanRead){
                StreamReader reader = new StreamReader(context.Request.Body);
                string text = reader.ReadToEnd();
                var body = text;
                }
                /*var form = await context.Request.ReadFormAsync();
                req.form = form;*/
                functionName = methodHTTP + "_" + functionName;
                list[0].Execute(req, context);
                /*
                
                var currentController = getControlleur(arrayPath[1]);
                System.Console.WriteLine(currentController.GetType().Name);
                var method = currentController.GetType().GetMethod(functionName);
                
                var result = (Task) method.Invoke(currentController,new object[]{req});
                var res1 = result.GetType().GetProperty ("Result").GetValue (result) ;
                var res = Convert.ToString(res1);
                System.Console.WriteLine(res);
                await context.Response.WriteAsync(res);*/
            });
            
        }




        /*public controlleur getControlleur(string controlleurName){
            
            for( var i =0; i<listCont.Count;i++){
                if(controlleurName==listCont[i].GetType().Name){
                    System.Console.WriteLine("ICI");
                    return listCont[i];
                }
            }
            return listCont[0];
            
        }*/
    }
}
