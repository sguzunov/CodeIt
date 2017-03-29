using System;
using System.Web.Mvc;
using System.Web.Routing;
using CodeIt.Data.Models;
using CodeIt.Services.Data.Contracts;
using Bytes2you.Validation;

using Microsoft.AspNet.Identity;

namespace CodeIt.Web.Controllers
{
    [Authorize]
    public abstract class BaseAuthorizationController : Controller
    {
        private readonly IUsersService users;

        public BaseAuthorizationController(IUsersService users)
        {
            Guard.WhenArgument(users, nameof(users)).IsNull().Throw();

            this.users = users;
        }

        protected User LoggedUser { get; set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            var identityUser = requestContext.HttpContext.User;
            if (this.LoggedUser == null && identityUser.Identity.IsAuthenticated)
            {
                this.LoggedUser = this.users.GetById(identityUser.Identity.GetUserId());
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}