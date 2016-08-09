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
    public class Startup : Vulpix
    {

        public Startup(){
           var foo = new MyController();
           base.AddRoute("GET","/", foo.Index);
        }
    }
}
