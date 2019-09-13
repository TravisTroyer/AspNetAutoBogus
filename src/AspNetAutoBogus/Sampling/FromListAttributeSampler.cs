using System.Reflection;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace AspNetAutoBogus.Sampling
{
   public class FromListAttributeSampler : ISampler
   {
      public bool TryGetSample(ControllerActionDescriptor action, out object sample)
      {
         sample = default;

         var attribute = action.MethodInfo.GetCustomAttribute<AutoBogusListAttribute>();
         if (attribute == null)
            return false;

         return Generator.List(attribute.BogusType, attribute.Count, out sample);
      }
   }
}
