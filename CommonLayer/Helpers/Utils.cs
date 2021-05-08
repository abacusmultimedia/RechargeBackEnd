using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;


namespace CommonLayer.Helpers
{
    public class Utils
    {
        public static IConfigurationRoot _config { get; set; }

        public static class ConnectionStrings
        {
            public static string PortalConnectionString { get; set; }
        }

        public static string GetUserId(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext.User.GetUserId();
        }


        public static string GetRole(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext.User.GetRole();
        }

    }
}
