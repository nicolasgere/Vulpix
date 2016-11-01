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
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using Vulpix.Objects;

namespace Vulpix
{
    public class VulpixCore
    {

        private List<Route> _Routes = new List<Route>();
        private Middleware _LastMiddleware;
         
        private String _PublicFolder;

        public void ConfigureServices(IServiceCollection services)
        {

        }
        public void SetRoute(List<Route> value) {
            this._Routes = value;
        }
        public void SetPublicFolder(String value) {
            this._PublicFolder = value;
        }
        public void SetMiddleware(Middleware value) {
            this._LastMiddleware = value;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            if(!String.IsNullOrEmpty(_PublicFolder)){
                 app.UseStaticFiles(new StaticFileOptions(){
                        FileProvider = new PhysicalFileProvider(
                        Path.Combine(Directory.GetCurrentDirectory(), @""+_PublicFolder)),
                        RequestPath = new PathString("/"+_PublicFolder)
                });
            }
           
            app.Run(async (context) =>
            {
                await Task.Run(()=>{
                    var res = new Res(context);
                    var req = new Req();
                    req.Context = context.Request;
                    _LastMiddleware.Execute(req, res) ;
                });
             
            });

        }
    }
}
