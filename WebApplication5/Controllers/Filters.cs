using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
	public class Filters
	{
		public class AuthFilter : Attribute, IAuthorizationFilter
		{
			public void OnAuthorization(AuthorizationFilterContext context)
			{
				if (context.HttpContext.Session.Get("LogSession") == null)
				{
					context.Result = new UnauthorizedResult();
				}
			}
		}
	}
}
