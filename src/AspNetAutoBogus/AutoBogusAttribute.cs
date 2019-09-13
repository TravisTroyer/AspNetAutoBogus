using System;
using JetBrains.Annotations;

namespace AspNetAutoBogus
{
   [PublicAPI]
   [AttributeUsage(AttributeTargets.Method)]
   public class AutoBogusAttribute : Attribute
   {
      public AutoBogusAttribute(Type bogusType)
      {
         BogusType = bogusType;
      }

      public Type BogusType { get; }
   }
}
