using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vulpix;

namespace test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = new VulpixServer();
            var foo = new MyController();
            app.AddRoute("GET","/", foo.Index);
            app.AddRoute("GET","/voiture/:id", foo.Form);
            app.Use(new BodyParser().Exec);
            app.Listen();
        }
    }
}
