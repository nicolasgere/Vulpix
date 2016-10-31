using System;
using System.IO;
using Newtonsoft.Json;


namespace Vulpix
{
    public class BodyParser
    {
        public void Exec(Req req, Res res, Middleware middle){
            if(req.Context.Body.CanRead && !req.Context.HasFormContentType){
                  StreamReader reader = new StreamReader(req.Context.Body);
                  req.Body = JsonConvert.DeserializeObject(reader.ReadToEnd());
              }              
              middle.Next(req, res);
        }
    }
}
