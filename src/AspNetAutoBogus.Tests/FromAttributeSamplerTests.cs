using System;
using AspNetAutoBogus.Sampling;
using AspNetAutoBogus.Tests.Model;
using Xunit;

namespace AspNetAutoBogus.Tests
{
   public class FromAttributeSamplerTests
   {
      [Theory]
      [InlineData(typeof(Response), nameof(MockApiController.DecoratedTaskResponse))]
      [InlineData(typeof(Response), nameof(MockApiController.DecoratedTaskListResponse))]
      [InlineData(typeof(Body), nameof(MockApiController.DecoratedTaskRequest))]
      [InlineData(typeof(Body), nameof(MockApiController.DecoratedTaskListRequest))]
      public void CanGetResponseSample(Type expected, string method)
      {
         var action = MockApiController.ExtractAction(
            method);

         var target = new FromAttributeSampler();
         var actual = target.TryGetSample(action, out var sample);

         Assert.True(actual);
         Assert.IsType(expected, sample);
      }
   }
}
