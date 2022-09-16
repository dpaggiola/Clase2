using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Security.Authentication;

namespace WebApi
{
    public class FilterAuthentication : Attribute, IAuthorizationFilter
    {
        private IUserService _userService;

        public FilterAuthentication(IUserService userService)
        {
            _userService = userService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Exception exception = new AuthenticationException("You are not allowed to do this action.");
            ErrorDto errorDto = new ErrorDto()
            {
                IsSuccess = false,
                Message = exception.Message,
                StatusCode = 401,
                Content = exception.Message
            };
            StringValues token;
            context.HttpContext.Request.Headers.TryGetValue("Authorization", out token);
            if (token.Count == 0 || token == "")
            {
                context.Result = new ObjectResult(errorDto)
                {
                    StatusCode = errorDto.StatusCode
                };
            }
            else
            {
                try
                {
                    _userService.GetUserByToken(token);
                }
                catch (KeyNotFoundException)
                {
                    context.Result = new ObjectResult(errorDto)
                    {
                        StatusCode = errorDto.StatusCode
                    };
                }
            }
        }
    }
}
