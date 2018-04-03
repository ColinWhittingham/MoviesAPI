namespace MoviesAPI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Http;
    using Autofac;
    using Autofac.Integration.WebApi;

    public class IocConfig
    {
        public static void RegisterIoc(HttpConfiguration config)
        {
            //create a new autofac container
            var builder = new ContainerBuilder();

            //register all types
            InitializeContainer(builder);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        public static void InitializeContainer(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterApiControllers(assembly);

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
        }
    }
}