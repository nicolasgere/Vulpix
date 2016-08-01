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
    public class Moto : controlleur
    {
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async Task<string> GET_Index()
        {          
           return "Je suis une moto";
        }
        
    }
}
