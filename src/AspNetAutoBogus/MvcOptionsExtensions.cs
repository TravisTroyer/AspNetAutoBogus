using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace AspNetAutoBogus
{
   public static class MvcOptionsExtensions
   {
      [PublicAPI]
      public static void AddAutoBogusFilter(this MvcOptions options)
      {
         options.Filters.Add<AutoBogusFilter>();
      }
   }
}
