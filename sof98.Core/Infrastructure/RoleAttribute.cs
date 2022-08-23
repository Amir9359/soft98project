using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using soft98.Core.Interface;
using soft98.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace soft98.Core.Infrastructure
{
    public class RoleAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private IUserRepository _userRepository;
        private string RoleName;

        public RoleAttribute(string roleName)
        {
            RoleName = roleName;
        }

        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                string userName = context.HttpContext.User.Identity.Name;

                _userRepository =
                    (IUserRepository)context.HttpContext.RequestServices.GetService(typeof(IUserRepository));
                var result = await _userRepository.ChenckUserRole(RoleName, userName);

                context.Result = new RedirectResult("/Account/SignOut");

            }
        }
    }
}