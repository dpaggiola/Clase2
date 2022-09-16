using Domain;
using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Security.Authentication;

namespace WebApi
{
    public class ProtectFilter : Attribute, IActionFilter
    {
        private RoleType _role;
        private IUserService _userService;

        public ProtectFilter(RoleType role)
        {
            _role = role;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            this._userService = context.HttpContext.RequestServices.GetService<IUserService>();
            StringValues token;
            context.HttpContext.Request.Headers.TryGetValue("Authorization", out token);
            Exception exception = new AuthenticationException("You are not allowed to do this action.");
            ErrorDto errorDto = new ErrorDto()
            {
                IsSuccess = false,
                Message = exception.Message,
                StatusCode = 401,
                Content = exception.Message
            };
            try
            {
                User user = _userService.GetUserByToken(token);
                if (user!= null && user.Role!= _role)
                {
                    context.Result = new ObjectResult(errorDto)
                    {
                        StatusCode = errorDto.StatusCode
                    };
                }
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException();
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
