using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Vulpix;

namespace test
{
    public class MyController
    {
        public async void Index(Req req, Res res)
        {
            await res.Response.WriteAsync("test voiture");
        }
        public async void Form(Req req, Res res)
        {
            await res.Response.WriteAsync(req.paramsUrl["id"]);
        }
        public async void Body(Req req, Res res)
        {
            await res.Response.WriteAsync(req.body);
        }
    }
}
