using System.Globalization;
using System.Text.RegularExpressions;

namespace Globomatics.Web.Constraints;

public class SlugConstraint : IRouteConstraint
{
    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
        // An IRouteConstraint implementation that validates a slug parameter. A slug is a URL-friendly string that contains only alphanumeric characters and hyphens.
        // This constraint is used to validate the slug parameter in the TicketDetails action of the HomeController. It can be limiting to use a regular expression
        // to validate a slug, as it may not account for all possible valid slugs.
        if (!values.TryGetValue("slug", out var slug))
        {
            return false;
        }

        var slugAsString = Convert.ToString(slug, CultureInfo.InvariantCulture);

        if (string.IsNullOrWhiteSpace(slugAsString))
        {
            return false;
        }

        return Regex.IsMatch(slugAsString, "^[a-zA-Z0-9 ]+$");
    }
}