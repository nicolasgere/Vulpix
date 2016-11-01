using Vulpix;
 public class Startup : VulpixCore
  {

    public Startup(){
      var config = VulpixConfiguration.GetConfiguration();
      base.SetRoute(config._listRoute);
      base.SetMiddlewares(config._middlewaresList);
      base.SetPublicFolder(config._publicFolderName);
    }
  }