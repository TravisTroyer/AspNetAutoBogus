# AspNetAutoBogus
An ASP.NET Core 3 filter for injecting [AutoBogus](https://github.com/nickdodd79/AutoBogus) into your request processing pipeline.

[AutoBogus](https://github.com/nickdodd79/AutoBogus) is a C# library complementing the [Bogus](https://github.com/bchavez/Bogus) generator by adding auto creation and population capabilities.

# Usage

Enabling is something like this:

```c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc(options => 
    {
        options.Filters.Add(typeof(AutoBogusFilter);
    });
}
```

To get an AutoBogused API response, include an **x-sample-please** header or a **sample-please** query parameter with your request.