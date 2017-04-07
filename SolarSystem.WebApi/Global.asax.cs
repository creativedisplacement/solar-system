using Newtonsoft.Json;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using SolarSystem.Data.Abstract;
using SolarSystem.Data.Concrete;
using SolarSystem.Data.DAL;
using SolarSystem.Repositories.Abstract;
using SolarSystem.Repositories.Concrete;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SolarSystem.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            // Register your stuff here 
            container.Register<DbContext, SolarSystemDbContext>(Lifestyle.Transient);

            container.Register(typeof(IRepository<>), typeof(Repository<>));

            container.Register<IStarRepository, StarRepository>();
            container.Register<IPlanetRepository, PlanetRepository>();
            container.Register<IMoonRepository, MoonRepository>();

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            //container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //SimpleInjectorConfig.Register();
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }
    }
}
