using Microsoft.AspNetCore.Mvc.Controllers;

namespace AspNetAutoBogus.Sampling
{
   public interface ISampler
   {
      bool TryGetSample(ControllerActionDescriptor action, out object sample);
   }
}
