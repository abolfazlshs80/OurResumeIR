using Microsoft.AspNetCore.Mvc;
using System.Linq;

public static class ViewComponentExtensions
{
    public static string GetDefaultViewPath(this ViewComponent viewComponent)
    {
        var type = viewComponent.GetType();

        // ProFileUser_ProfileLayoutViewComponent => ProFileUser_ProfileLayout
        var componentName = type.Name.Replace("ViewComponent", "View");

        // Handler\User\Layout
        var @namespace = type.Namespace.Replace("Handler", "Views"); // OurResumeIR.MVC.ViewComponents.Handler.User.Layout
        var folders = @namespace.Split('.')
            .SkipWhile(p => p != "ViewComponents")
            .Skip(1) // Skip "ViewComponents"
            .ToArray();

        // Handler -> User -> Layout
        var path =string.Join('/',folders) ;

        // ~/ViewComponents/Views/User/Layout/ProFileUser_ProfileLayoutView.cshtml
        return $"~/ViewComponents/{path}/{componentName}.cshtml";
    }
}