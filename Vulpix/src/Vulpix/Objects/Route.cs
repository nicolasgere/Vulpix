using System;
using System.Linq;


namespace Vulpix.Objects
{

 public class Route{
     private string _Methode;
     private string _RoutePath;
     private string[] _RouteSplit;
     private Action<Req,Res> _Action;
     public Route(string methode, string route, Action<Req,Res> action){
         this._Methode = methode;
         this._Action = action;
         this._RoutePath = route;
         this._RouteSplit = route.Split('/');
     }
     public void Execute(Req req,Res res){
         _Action(req,res);
     }

     public ResultValidate ValidateRoute(string methodName, string[] url){
         var i = 0;
         var y = 0;
         var result = new ResultValidate();
         
         if(methodName != this._Methode){
             result.IsValid = false;
             return result;
         }
         while(result.IsValid && i != url.Count() && y !=_RouteSplit.Count()){
             bool paramsPresent = false;
             if(!String.IsNullOrEmpty(_RouteSplit[y]) && _RouteSplit[y][0]==':'){
                 paramsPresent = true;
                 result.ParamsUrl.Add(_RouteSplit[y].Replace(":","") , url[i]);
             }

             if(url[i] == _RouteSplit[y] || paramsPresent){

             }else{
                 result.IsValid = false;
             }
             y++;
             i++;
         }
         if(i != url.Count() || y != _RouteSplit.Count()){
             result.IsValid = false;
         }
         return result;
     }
 }
}
