using System;


namespace Vulpix.Objects
{

     public class Middleware{
         private Action<Req,Res, Middleware> _Action;
         public Middleware NextMiddleware;
         public Middleware(Action<Req,Res,Middleware > action, Middleware next){
             this._Action = action;
             this.NextMiddleware = next;
         }
         public void Next(Req req, Res res){
            if(this.NextMiddleware != null){
                NextMiddleware.Execute( req, res);
             }
         }
         public void Execute(Req req, Res res){
            _Action(req,res,this);
         }
    }
}
