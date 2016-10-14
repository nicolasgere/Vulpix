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
    public class VulpixCore
    {

        List<Route> list = new List<Route>();
        Middleware last ;

        public void ConfigureServices(IServiceCollection services)
        {

        }
        public void setRoute(List<Route> value) {
            this.list = value;
        }
        public void setMiddleware(Middleware value) {
            this.last = value;
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
              var res = new Res(context);
              var req = new Req();
              req.context = context.Request;
              last.Execute(req, res) ;
            });

        }
    }
}
