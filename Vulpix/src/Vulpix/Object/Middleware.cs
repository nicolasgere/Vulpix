using System;


namespace Vulpix
{
     public class Middleware{
         private Action<Req,Res> _action;

         public Middleware(Action<Req,Res> action){
             this._action = action;
         }

        public void Execute(Req req, Res res)
        {
            _action(req, res);
        }
    }
}
