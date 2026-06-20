using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SecurityServiceBackend.Services;

namespace SecurityServiceBackend.Middlewares
{
    public class SessionAuthFilter : IAsyncActionFilter
    {
        private readonly IJwtService _jwtService;

        public SessionAuthFilter(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var permiteAnonimo = context.ActionDescriptor.EndpointMetadata
                .Any(m => m is AllowAnonymousAttribute);

            if (permiteAnonimo)
            {
                await next();
                return;
            }

            var token = context.HttpContext.Session.GetString("JWToken");

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new RedirectToActionResult("Login", "Login", null);
                return;
            }

            var principal = _jwtService.ValidarToken(token);

            if (principal == null)
            {
                // Token vencido o inválido: se limpia la sesión y se manda al login
                context.HttpContext.Session.Clear();
                context.Result = new RedirectToActionResult("Login", "Login", null);
                return;
            }

            context.HttpContext.User = principal;

            bool debeCambiarPassword = principal.Claims
                .FirstOrDefault(c => c.Type == "mustChangePassword")?.Value == "true";

            var controllerActual = context.RouteData.Values["controller"]?.ToString();

            if (debeCambiarPassword && controllerActual != "CambiarPassword")
            {
                context.Result = new RedirectToActionResult("CambiarPassword", "CambiarPassword", null);
                return;
            }

            await next();
        }
    }
}
