using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UI.Filtres
{
    public class JwtAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var path = context.HttpContext.Request.Path.ToString().ToLower();

            if (path.Contains("account/login")) 
                return;

            var token = context.HttpContext.Request.Cookies["tasty-cookies"];

            if(string.IsNullOrEmpty(token) )
            {
                context.Result = new RedirectToActionResult("Login", "account", null);
            }
        }
    }
}
