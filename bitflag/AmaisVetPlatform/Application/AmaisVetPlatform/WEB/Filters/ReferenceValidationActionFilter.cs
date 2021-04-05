using DTO.Subscription;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Services.Subscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Filters
{
    public class ReferenceValidation : ActionFilterAttribute
    {
        private readonly SubscriptionSteps currentSubscriptionStep;
        private bool redirect;
        public ReferenceValidation(SubscriptionSteps currentSubscriptionStep)
        {
            this.currentSubscriptionStep = currentSubscriptionStep;
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string reference;
            if (!context.RouteData.Values.TryGetValue("reference", out object _reference))
            {
                context.Result = SubscriptionNotFound();
            }
            else
            {
                if (_reference == null || string.IsNullOrWhiteSpace(Convert.ToString(_reference)))
                {
                    context.Result = SubscriptionNotFound();
                }
                else
                {

                    reference = Convert.ToString(_reference);
                    var subscriptionService = (SubscriptionService)context.HttpContext.RequestServices.GetService(typeof(SubscriptionService));
                    if (!await subscriptionService.ReferenceExistsAsync(reference)) 
                    {
                        context.Result = SubscriptionNotFound();
                    }
                    else
                    {
                        var subscriptionStep = await subscriptionService.GetCertificateSubscriptionStepAsync(reference);

                        if (subscriptionStep == SubscriptionSteps.None) context.Result = SubscriptionStepError();
                        else if (subscriptionStep == SubscriptionSteps.Certificate && currentSubscriptionStep != SubscriptionSteps.Certificate) context.Result = Certificate(reference);
                        else if (subscriptionStep == SubscriptionSteps.Payment && currentSubscriptionStep == SubscriptionSteps.HealthQuestionnaireBlock) context.Result = Payment(reference);
                        else if (subscriptionStep == SubscriptionSteps.HealthQuestionnaireBlock) context.Result = HealthBlock(reference);
                        else if (subscriptionStep == SubscriptionSteps.Plans && (currentSubscriptionStep == SubscriptionSteps.HealthQuestionnaire || currentSubscriptionStep == SubscriptionSteps.Payment || currentSubscriptionStep == SubscriptionSteps.Certificate)) context.Result = SubscriptionStepError();
                        else if (subscriptionStep == SubscriptionSteps.HealthQuestionnaire && (currentSubscriptionStep == SubscriptionSteps.Payment || currentSubscriptionStep == SubscriptionSteps.Certificate)) context.Result = SubscriptionStepError();
                        else if (subscriptionStep == SubscriptionSteps.Payment && (currentSubscriptionStep == SubscriptionSteps.Certificate)) context.Result = SubscriptionStepError();

                        if (currentSubscriptionStep == SubscriptionSteps.HealthQuestionnaireUnblock) context.Result = null;
                        if (subscriptionStep == SubscriptionSteps.HealthQuestionnaireBlock && currentSubscriptionStep == SubscriptionSteps.HealthQuestionnaireBlock) context.Result = null;
                    }
                }
            }
            if (context.Result == null) await next();
        }
        private RedirectToRouteResult SubscriptionNotFound() => new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Subscription" }, { "action", "SubscriptionNotFound" } });
        private RedirectToRouteResult SubscriptionStepError() => new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Subscription" }, { "action", "SubscriptionStepError" } });
        private RedirectToRouteResult Certificate(string reference) => new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Subscription" }, { "action", "Certificate" }, { "reference", reference } });
        private RedirectToRouteResult HealthBlock(string reference) => new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Subscription" }, { "action", "HealthBlock" }, { "reference", reference } });
        private RedirectToRouteResult Payment(string reference) => new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Subscription" }, { "action", "Payment" }, { "reference", reference } });
    }
}
