using Vulpix;
using Vulpix.Objects;

public class Startup : VulpixCore
{
    public Startup()
    {
        var config = VulpixConfiguration.GetConfiguration();
        base.SetRoute(config.GetRoute());
        base.SetMiddleware(config.GetMiddleware());
        base.SetPublicFolder(config.GetPublicFolder());
    }
}