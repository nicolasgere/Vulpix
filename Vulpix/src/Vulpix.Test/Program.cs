using System;
using System.Text;
using Vulpix.Middlewares;
using Vulpix.Objects;

namespace Vulpix.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = new VulpixServer();
            var foo = new MyController();

            app.AddRoute("GET", "/", foo.Index);
            app.Use(new BodyParser().Exec);
            app.Listen(5000);
        }

        public class MyController
        {
            public async void Index(Req req, Res res)
            {
                await res.Send("Hello world!");
            }
        }
    }
}
