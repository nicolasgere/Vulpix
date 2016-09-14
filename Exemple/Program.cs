using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bob;

namespace test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = new Vulpix();
            var foo = new MyController();
            app.AddRoute("GET","/", foo.Index);
            app.Use(new BodyParser().exec);
            app.listen();

        }
    }
}
