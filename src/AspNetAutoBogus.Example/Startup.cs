using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetAutoBogus.Example
{
   [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
   public class Startup
   {
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddControllers(o => o.EnableEndpointRouting = false);

         services.AddMvc(o => o.AddAutoBogusFilter());
      }

      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();

         app.UseMvc();
         app.UseDefaultFiles();
         app.UseStaticFiles();
      }
   }
}
