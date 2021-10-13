using System;
using System.Collections.Generic;
using AspNetAutoBogus.Sampling;
using AspNetAutoBogus.Tests.Model;
using Xunit;

namespace AspNetAutoBogus.Tests
{
   public class FromProducesResponseTypeTests
   {
      [Theory]
      [InlineData(typeof(Response), nameof(MockApiController.ResponseTypeResponse))]
      [InlineData(typeof(List<Response>), nameof(MockApiController.ResponseTypeListResponse))]
      [InlineData(typeof(Response), nameof(MockApiController.ResponseTypeTaskResponse))]
      [InlineData(typeof(List<Response>), nameof(MockApiController.ResponseTypeTaskListResponse))]
      public void CanGetResponseSample(Type expected, string method)
      {
         var action = MockApiController.ExtractAction(
            method);

         var target = new FromProducesResponseTypeSampler();
         var actual = target.TryGetSample(action, out var sample);

         Assert.True(actual);
         Assert.IsType(expected, sample);
      }
   }
}
