using Autofac;
using Autofac.Integration.WebApi;
using ITI.WhatsLearn.Reposatories;
using ITI.WhatsLearn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;

namespace ITI.WhatsLearn.Presentation
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional
                }
            );


            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            ContainerBuilder builder
                           = new ContainerBuilder();

            builder.RegisterApiControllers
                (Assembly.GetExecutingAssembly())
                .PropertiesAutowired()
                .InstancePerRequest();

            builder.RegisterType<EntitiesContext>
                ().InstancePerRequest();

            builder.RegisterGeneric(typeof(Generic<>))
                .InstancePerRequest();

            builder.RegisterType<UnitOfWork>
               ().InstancePerRequest();

            builder.RegisterAssemblyTypes
                (
                typeof(TrackService).Assembly
                ).Where(i => i.Name.EndsWith("Service"))
                .InstancePerRequest();

            IContainer IoC = builder.Build();
            config.DependencyResolver =
                new AutofacWebApiDependencyResolver(IoC);
        }
    }
}
