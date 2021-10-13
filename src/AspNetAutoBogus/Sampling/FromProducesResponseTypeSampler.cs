using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace AspNetAutoBogus.Sampling
{
   public class FromProducesResponseTypeSampler : ISampler
   {
      public bool TryGetSample(ControllerActionDescriptor action, out object sample)
      {
         sample = default;

         var attribute = action.MethodInfo.GetCustomAttribute<ProducesResponseTypeAttribute>();
         if (attribute == null)
            return false;

         var type = attribute.Type;
         
         var eType = type.GetInterface(typeof(IEnumerable<>).Name);
         if (eType != null)
            return Generator.List(eType.GenericTypeArguments.First(), 3, out sample);

         return Generator.Single(type, out sample);
      }
   }
}
