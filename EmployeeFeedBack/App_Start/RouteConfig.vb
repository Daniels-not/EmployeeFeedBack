Imports System.Web.Mvc
Imports System.Web.Routing
Imports Microsoft.AspNet.FriendlyUrls

Public Module RouteConfig
    Sub RegisterRoutes(ByVal routes As RouteCollection)
        Dim settings As FriendlyUrlSettings = New FriendlyUrlSettings() With {
            .AutoRedirectMode = RedirectMode.Permanent
        }

        routes.EnableFriendlyUrls(settings)

        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        routes.MapRoute(
            name:="Default",
            url:="{controller}/{action}/{id}",
            defaults:=New With {.action = "Index", .id = UrlParameter.Optional}
        )
    End Sub
End Module