using System.Web.Http;
using Newtonsoft.Json;

public static class WebApiConfig
{
    public static void Register(HttpConfiguration config)
    {
        // Enable attribute routing
        config.MapHttpAttributeRoutes();

        // Default API route
        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );

        // Configure JSON formatter
        var jsonFormatter = config.Formatters.JsonFormatter;
        jsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
    }
}
