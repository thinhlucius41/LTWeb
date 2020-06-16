using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LTWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            
            routes.MapRoute(
                name: "Trang chi tiết tin tức",
                url: "bai-bao/{meta}-{id}",
                defaults: new { controller = "TinTuc", action = "Details", id = UrlParameter.Optional },
                 namespaces: new[] { "LTWeb.Controllers" }
            );
            routes.MapRoute(
                name: "Trang tin tức",
                url: "tin-tuc",
                defaults: new { controller = "TinTuc", action = "PageNews", id = UrlParameter.Optional },
                 namespaces: new[] { "LTWeb.Controllers" }
            );
            routes.MapRoute(
               name: "Trang chi tiết đội bóng",
               url: "doi-bong/{meta}-{id}",
               defaults: new { controller = "ClubsInfo", action = "Details", id = UrlParameter.Optional },
                namespaces: new[] { "LTWeb.Controllers" }
           );
            routes.MapRoute(
                name: "Trang danh sách đội bóng",
                url: "cac-doi-bong",
                defaults: new { controller = "ClubsInfo", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "LTWeb.Controllers" }
            );
            routes.MapRoute(
                name: "Trang chủ",
                url: "trang-chu",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "LTWeb.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"LTWeb.Controllers"}
            );
        }
    }
}
