using System;
using System.Text;

namespace Vulpix.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = new VulpixServer();
            var foo = new MyController();
            app.Use(BodyParser.Exec);
            app.AddRoute("GET", "/", foo.Index);

            app.Listen(5000);
        }

        public class MyController
        {
            public async void Index(Req req, Res res)
            {
                Console.WriteLine("GET: /");

                byte[] response = Encoding.ASCII.GetBytes("Hello world!");

                await res.Response.Body.WriteAsync(response, 0, response.Length);
            }
        }
    }
}
