using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vulpix;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = new VulpixServer();
            app.AddRoute("GET", "/", (Req req, Res res) => {
                await res.Response.WriteAsync("Hello World!");
            });
            app.Listen();
        }
    }
}
