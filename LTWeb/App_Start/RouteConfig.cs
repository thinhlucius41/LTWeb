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
               name: "Trang cập nhật thông tin tài khoản",
               url: "cap-nhat-thong-tin/{id}",
               defaults: new { controller = "DangKy", action = "Update", id = UrlParameter.Optional },
               namespaces: new[] { "LTWeb.Controllers" }
           );
            routes.MapRoute(
               name: "Trang thông tin tài khoản",
               url: "thong-tin-tai-khoan/{id}",
               defaults: new { controller = "DangKy", action = "Detail", id = UrlParameter.Optional },
               namespaces: new[] { "LTWeb.Controllers" }
           );
            routes.MapRoute(
               name: "Trang đăng ký",
               url: "dang-ky",
               defaults: new { controller = "DangKy", action = "Register", id = UrlParameter.Optional },
               namespaces: new[] { "LTWeb.Controllers" }
           );
            routes.MapRoute(
               name: "Trang đăng nhập",
               url: "dang-nhap",
               defaults: new { controller = "HomeLogin", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "LTWeb.Controllers" }
           );
            routes.MapRoute(
                name: "Trang chi tiết tin tức",
                url: "chi-tiet-tin-tuc/{meta}/{id}",
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
               url: "chi-tiet-doi-bong/{meta}/{id}",
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
