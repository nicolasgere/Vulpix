using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Vulpix
{
    public class Res
    {
        public HttpResponse Response;

        public Res(HttpContext context)
        {
            this.Response = context.Response;
        }

        public async Task Send(object obj)
        {
            await this.Send(obj, 200);
            //Response.StatusCode = 200;
            //Response.ContentType = "application/json";
            //await Response.WriteAsync(JsonConvert.SerializeObject(obj));
        }

        public async Task Send(object obj, int code)
        {
            Response.StatusCode = code;
            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(obj));
        }

        public async Task Send(string text)
        {
            await this.Send(text, 200);
            //Response.StatusCode = 200;
            //Response.ContentType = "text/HTML";
            //await Response.WriteAsync(text);
        }

        public async Task Send(string text, int code)
        {
            Response.StatusCode = code;
            Response.ContentType = "text/HTML";
            await Response.WriteAsync(text);
        }
    }
}
