using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptDevMVC.Security
{
    public class CustomAuthorizationFilterAttribute
    {
        private readonly string[] _authorizations;

        public CustomAuthorizationFilterAttribute(params string[] authorizations)
        {
            _authorizations = authorizations;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string authorization = context.HttpContext.Session.GetString("Authorization");
            if (!_authorizations.Contains(authorization))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
