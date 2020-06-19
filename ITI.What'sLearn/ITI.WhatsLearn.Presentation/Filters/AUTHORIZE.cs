using BroadCaster.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;


namespace ITI.WhatsLearn.Presentation.Filters
{

    public class AUTHORIZE
        : AuthorizationFilterAttribute
    {

        public string Roles { get; set; }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string jwt_token =
                actionContext.Request.Headers.Authorization?
                    .Parameter;

            if (string.IsNullOrEmpty(jwt_token))
            {
                actionContext.Response
                    = actionContext.Request.CreateResponse
                    (HttpStatusCode.Unauthorized, "Not Authenticated");
                return;
            }


            Dictionary<string, string>
                cliams = SecurityHelper.Validate(jwt_token);

            if (cliams == null)
            {
                actionContext.Response
                    = actionContext.Request.CreateResponse
                    (HttpStatusCode.Unauthorized, "Not Authorized");
                return;
            }




            string role = cliams.First(i => i.Key == "Role").Value;

            string userRole = role;
            string[] requiredRoles = Roles.Split(new char[] { ',' });


            if (!requiredRoles.Contains(userRole))
            {
                actionContext.Response
                    = actionContext.Request.CreateResponse
                    (HttpStatusCode.Unauthorized, "Not Authorized");
                return;
            }

        }
    }
}
