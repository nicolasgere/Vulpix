using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Vulpix
{

     public class Req{

        public IFormCollection form;
        public HttpRequest context;
        public dynamic body;
        public Dictionary<string, string> paramsUrl;

    }
}
