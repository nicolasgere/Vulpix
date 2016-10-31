using System.Collections.Generic;


namespace Vulpix
{
    public class ResultValidate{
     public bool IsValid;
     public Dictionary<string, string> ParamsUrl;
     public ResultValidate(){
         this.IsValid = true;
         this.ParamsUrl = new Dictionary<string, string>();
     }
    }
}