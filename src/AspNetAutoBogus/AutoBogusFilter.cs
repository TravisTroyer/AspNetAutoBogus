using AspNetAutoBogus.Sampling;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetAutoBogus
{
   [PublicAPI]
   public class AutoBogusFilter : IActionFilter
   {
      public void OnActionExecuted(ActionExecutedContext context) { }

      public void OnActionExecuting(ActionExecutingContext context)
      {
         if (!(context.ActionDescriptor is ControllerActionDescriptor action))
            return;

         if (!IsSampleRequested(context.HttpContext.Request))
            return;

         if (!TrySample<FromAttributeSampler>(action, out var sample)
             && !TrySample<FromListAttributeSampler>(action, out sample)
             && !TrySample<FromMethodInfoSampler>(action, out sample))
            return;

         context.Result = new JsonResult(sample);
      }

      private bool TrySample<T>(ControllerActionDescriptor action, out object sample)
         where T : ISampler, new()
      {
         var sampler = new T();
         return sampler.TryGetSample(action, out sample);
      }

      private bool IsSampleRequested(HttpRequest request)
      {
         return request.Headers.ContainsKey("x-sample-please")
                || request.Query.ContainsKey("sample-please");
      }
   }
}
