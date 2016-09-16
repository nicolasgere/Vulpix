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
    public class BodyParser
    {
        public async void Exec(Req req, Res res, Middleware middle){
            System.Console.WriteLine("1 middleware");
            middle.Next(req,res);
        }
    }
}
