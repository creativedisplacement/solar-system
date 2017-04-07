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

namespace SolarSystem.WebApi
{
    public class SimpleInjectorConfig
    {
        public static void Register()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            // Register your stuff here 
            container.Register<DbContext, SolarSystemDbContext>(Lifestyle.Scoped);

            container.Register(typeof(IRepository<>), typeof(Repository<>), Lifestyle.Scoped);

            container.Register<IStarRepository, StarRepository>(Lifestyle.Scoped);
            container.Register<IPlanetRepository, PlanetRepository>(Lifestyle.Scoped);
            container.Register<IMoonRepository, MoonRepository>(Lifestyle.Scoped);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            //container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}