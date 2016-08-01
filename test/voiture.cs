using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace bob
{

    public class Voiture 
    {
        
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
                
        /*public  async void POST_Index(Req req)
        {      
           var form = req.form;
           var valeur = form["test"];  
           //var body = (MaClass) req.body;  
           return valeur;
        }*/

        public async void Index(Req req, HttpContext res)
        {          
            await res.Response.WriteAsync("voitureee");
        }

        
    }
    
}
