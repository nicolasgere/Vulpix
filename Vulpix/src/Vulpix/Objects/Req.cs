
using System.Collections.Generic;

using Microsoft.AspNetCore.Http;


namespace Vulpix.Objects
{

     public class Req{

        public IFormCollection Form;
        public HttpRequest Context;
        public dynamic Body;
        public Dictionary<string, string> ParamsUrl;

    }
}
