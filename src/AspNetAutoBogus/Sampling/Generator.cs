using System;
using System.Reflection;
using AutoBogus;

namespace AspNetAutoBogus.Sampling
{
   public static class Generator
   {
      public static bool Single(Type bogusType, out object sample) 
         => Generate(bogusType, null, out sample);

      public static bool List(Type bogusType, int listCount, out object sample)
         => Generate(bogusType, listCount, out sample);

      private static bool Generate(Type bogusType, int? listCount, out object sample)
      {
         sample = default;

         var argTypes = listCount.HasValue
            ? new[] { typeof(int), typeof(Action<IAutoGenerateConfigBuilder>) }
            : new[] { typeof(Action<IAutoGenerateConfigBuilder>) };

         var autoFaker = typeof(AutoFaker);

         // yeah, this is happening
         var flags = BindingFlags.Public | BindingFlags.Static;
         var method = autoFaker.GetMethod(nameof(AutoFaker.Generate), 
            flags, null, argTypes, null);

         if (method == null)
            return false;

         var generate = method.MakeGenericMethod(bogusType);

         sample = listCount.HasValue
            ? generate.Invoke(null, new object[] { listCount.Value, null })
            : generate.Invoke(null, new object[] { null });

         return true;
      }
   }
}
