
using System;
using System.Collections.Generic;


namespace Vulpix
{
    public class VulpixConfiguration
    {
        private static readonly VulpixConfiguration _vulpixConfiguration = new VulpixConfiguration();

        public List<Route> _listRoute { get; }
        public LinkedList<Middleware> _middlewaresList { get; }
        public String _publicFolderName { get; set; }

        private VulpixConfiguration()
        {
            _listRoute = new List<Route>();
            _middlewaresList = new LinkedList<Middleware>();
        }

        public static VulpixConfiguration GetConfiguration()
        {
            return _vulpixConfiguration;
        }

        public void AddRoute(Route value)
        {
            _listRoute.Add(value);
        }

        public void AddMiddleware(Middleware middleware)
        {
            _middlewaresList.AddLast(middleware);
        }

        public void SetRouter(Action<Req, Res> value)
        {
            var middleware = new Middleware(value);
            _middlewaresList.AddLast(middleware);
        }
    }
}
