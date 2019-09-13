using System;
using System.Collections.Generic;
using AspNetAutoBogus.Sampling;
using AspNetAutoBogus.Tests.Model;
using Xunit;

namespace AspNetAutoBogus.Tests
{
   public class FromListAttributeSamplerTests
   {
      [Theory]
      [InlineData(typeof(List<Response>), nameof(MockApiController.DecoratedTaskResponse))]
      [InlineData(typeof(List<Response>), nameof(MockApiController.DecoratedTaskListResponse))]
      [InlineData(typeof(List<Body>), nameof(MockApiController.DecoratedTaskRequest))]
      [InlineData(typeof(List<Body>), nameof(MockApiController.DecoratedTaskListRequest))]
      public void CanGetResponseSample(Type expected, string method)
      {
         var action = MockApiController.ExtractAction(
            method);

         var target = new FromListAttributeSampler();
         var actual = target.TryGetSample(action, out var sample);

         Assert.True(actual);
         Assert.IsType(expected, sample);
      }
   }
}
