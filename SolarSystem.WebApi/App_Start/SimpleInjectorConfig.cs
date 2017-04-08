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

            container.Register<DbContext, SolarSystemDbContext>(Lifestyle.Transient);
            container.Register(typeof(IRepository<>), typeof(Repository<>));
            container.Register<IStarRepository, StarRepository>();
            container.Register<IPlanetRepository, PlanetRepository>();
            container.Register<IMoonRepository, MoonRepository>();
            container.Register<IDetailedProfileRepository, DetailedProfileRepository>();

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            //container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}