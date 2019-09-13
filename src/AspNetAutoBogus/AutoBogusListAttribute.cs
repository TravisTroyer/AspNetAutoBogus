using System;
using JetBrains.Annotations;

namespace AspNetAutoBogus
{
   [PublicAPI]
   [AttributeUsage(AttributeTargets.Method)]
   public class AutoBogusListAttribute : Attribute
   {
      public AutoBogusListAttribute(Type bogusType, int count = 3)
      {
         BogusType = bogusType;
         Count = count;
      }
      public Type BogusType { get; }
      public int Count { get; }
   }
}
