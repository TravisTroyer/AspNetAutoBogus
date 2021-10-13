using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace AspNetAutoBogus.Tests.Model
{
   internal class MockApiController
   {
      public static ControllerActionDescriptor ExtractAction(string method)
      {
         return new ControllerActionDescriptor
         {
            MethodInfo = typeof(MockApiController)
               .GetMethod(method)
         };
      }

      public Response InferentialResponse(Body _) => null;

      public Task<Response> InferentialTaskResponse(Body _) => null;

      public Task<IReadOnlyList<Response>> InferentialTaskListResponse(Body _) => null;

      public Task<Response> InferentialTaskRequest([FromBody]Body _) => null;

      public Task<IReadOnlyList<Response>> InferentialTaskListRequest([FromBody]IReadOnlyList<Body> _) => null;

      public Task<ActionResult<Response>> InferentialActionResultTaskResponse(Body _) => null;

      [AutoBogus(typeof(Response))]
      [AutoBogusList(typeof(Response))]
      public Task<Response> DecoratedTaskResponse(Body _) => null;

      [AutoBogus(typeof(Response))]
      [AutoBogusList(typeof(Response))]
      public Task<IReadOnlyList<Response>> DecoratedTaskListResponse(Body _) => null;

      [AutoBogus(typeof(Body))]
      [AutoBogusList(typeof(Body))]
      public Task<Response> DecoratedTaskRequest(Body _) => null;

      [AutoBogus(typeof(Body))]
      [AutoBogusList(typeof(Body))]
      public Task<IReadOnlyList<Response>> DecoratedTaskListRequest(Body _) => null;
      
      [ProducesResponseType(typeof(Response), 200)]
      public Task<IActionResult> ResponseTypeTaskResponse(Body _) => null;
      
      [ProducesResponseType(typeof(List<Response>), 200)]
      public Task<IActionResult> ResponseTypeTaskListResponse(Body _) => null;
      
      [ProducesResponseType(typeof(Response), 200)]
      public IActionResult ResponseTypeResponse(Body _) => null;
      
      [ProducesResponseType(typeof(List<Response>), 200)]
      public IActionResult ResponseTypeListResponse(Body _) => null;
   }
}
