using System;
using System.Collections.Generic;
using AspNetAutoBogus.Sampling;
using AspNetAutoBogus.Tests.Model;
using Xunit;

namespace AspNetAutoBogus.Tests
{
   public class FromMethodInfoSamplerTests
   {
      [Theory]
      [InlineData(typeof(Response), nameof(MockApiController.InferentialResponse))]
      [InlineData(typeof(Response), nameof(MockApiController.InferentialTaskResponse))]
      [InlineData(typeof(Response), nameof(MockApiController.InferentialActionResultTaskResponse))]
      [InlineData(typeof(List<Response>), nameof(MockApiController.InferentialTaskListResponse))]
      [InlineData(typeof(Body), nameof(MockApiController.InferentialTaskRequest))]
      [InlineData(typeof(List<Body>), nameof(MockApiController.InferentialTaskListRequest))]
      public void CanGetResponseSample(Type expected, string method)
      {
         var action = MockApiController.ExtractAction(
            method);

         var target = new FromMethodInfoSampler();
         var actual = target.TryGetSample(action, out var sample);

         Assert.True(actual);
         Assert.IsType(expected, sample);
      }
   }
}
