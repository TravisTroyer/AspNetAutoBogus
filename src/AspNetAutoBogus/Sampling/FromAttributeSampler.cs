using System.Reflection;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace AspNetAutoBogus.Sampling
{
   public class FromAttributeSampler : ISampler
   {
      public bool TryGetSample(ControllerActionDescriptor action, out object sample)
      {
         sample = default;

         var attribute = action.MethodInfo.GetCustomAttribute<AutoBogusAttribute>();
         if (attribute == null)
            return false;

         return Generator.Single(attribute.BogusType, out sample);
      }
   }
}
