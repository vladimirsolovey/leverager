using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Leverager.HtmlHelpers
{
    public static class NavigationMenuExtensions
    {
        public static MvcHtmlString MenuLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName)
        {
            string currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            string currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
            string cssClasses = "button";

            if (actionName == currentAction && controllerName == currentController)
            {
                cssClasses = "button green";
            }

            return htmlHelper.ActionLink(linkText, actionName, controllerName, null, new { @class = cssClasses });
        }
    }
}