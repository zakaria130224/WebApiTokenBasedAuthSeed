using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using BookHome.Core.Repository;
using BookHome.Infrastracture;
using BookHome.Infrastracture.Repository;
using BookHome.Infrastracture.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BookHome.WebApi.App_Start
{
    public class AutofacConfig
    {
        [Obsolete]
        public static void RegisterComponents()
        {
            var builder = new ContainerBuilder();
            //builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterAssemblyTypes(typeof(UserService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerHttpRequest();
            //builder.RegisterType<UserService>().As<IUserService>();

            builder.RegisterType<DBContext>();

            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}