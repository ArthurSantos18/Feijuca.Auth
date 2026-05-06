using Feijuca.Auth.Attributes;
using Feijuca.Auth.Providers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Feijuca.Auth.Api.Tests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeijucaExampleController(ITenantProvider tenantService) : ControllerBase
    {
        [HttpGet("token-validation")]
        [Authorize]
        public ActionResult<string> SimpleAuthentication()
        {
            var tenant = tenantService.GetTenant();
            var user = tenantService.GetUser();
            var groups = tenantService.GetGroups();

            return Ok($"Hello from Feijuca! 🎉 You are authenticated. Tenant (Realm): {tenant.Name}, Username: {user.Username}, UserID: {user.Id}, Groups: {string.Join(", ", groups)}");
        }

        [HttpGet("role-validation")]
        [Authorize]
        [RequiredRole("RoleName")]
        public ActionResult<string> RoleAuthentication()
        {
            var tenant = tenantService.GetTenant();
            var user = tenantService.GetUser();
            var groups = tenantService.GetGroups();

            return Ok($"Hello from Feijuca! 🎉 You are authenticated with a valid role. Tenant (Realm): {tenant.Name} Username: {user.Username}, UserID: {user.Id}, Groups: {string.Join(", ", groups)}");
        }
    }
}
