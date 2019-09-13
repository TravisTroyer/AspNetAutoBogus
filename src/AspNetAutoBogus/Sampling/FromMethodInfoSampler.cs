using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace AspNetAutoBogus.Sampling
{
   public class FromMethodInfoSampler : ISampler
   {
      public bool TryGetSample(ControllerActionDescriptor action, out object sample)
      {
         var type = action.MethodInfo.ReturnType;
         type = ExtractGenericFrom(type, typeof(Task<>));
         type = ExtractGenericFrom(type, typeof(ActionResult<>));

         foreach (var parameter in action.MethodInfo.GetParameters())
         {
            var attribute = parameter.GetCustomAttribute<FromBodyAttribute>();
            if (attribute != null)
            {
               type = parameter.ParameterType;
               break;
            }
         }

         var eType = type.GetInterface(typeof(IEnumerable<>).Name);
         if (eType != null)
            return Generator.List(eType.GenericTypeArguments.First(), 3, out sample);

         return Generator.Single(type, out sample);
      }

      private Type ExtractGenericFrom(Type source, Type from)
      {
         if (source.Name.Equals(from.Name))
            return source.GenericTypeArguments.Length == 1 ? source.GenericTypeArguments.First() : source;

         return source;
      }
   }
}
