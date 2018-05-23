using System.Web.Http;
using WebActivatorEx;
using VillageSqlDB_API;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace VillageSqlDB_API
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        
                        c.SingleApiVersion("v1", "VillageSqlDB_API");

                       
                    })
                .EnableSwaggerUi(c =>
                    {
                       
                    });
        }
    }
}
