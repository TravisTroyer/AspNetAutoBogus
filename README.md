# AspNetAutoBogus
Generates API response or request body examples with fake data by injecting [AutoBogus](https://github.com/nickdodd79/AutoBogus) into your ASP.Net Core 3 request processing pipeline.

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

You can control the sample type:

```c#
[AutoBogus(typeof(Response))]
public async Task<Response> GetAsync() { }

[AutoBogusList(typeof(Response))]
public async Task<IReadOnlyList<Response>> GetAsync() { }

[AutoBogusList(typeof(Body))]
public async Task<ActionResult> PostAsync([FromBody]Body body) { }
```

Or let the AutoBogusFilter work things out for you.  Assuming neither AutoBogus attribute is found, AutoBogusFilter picks the first parameter decorated with a **FromBody** attribute, falling back to the return type.

```c#
// AutoBogusFilter boguses up a Response
public async Task<Response> GetAsync() { }

// AutoBogusFilter boguses up a List<Response>
public async Task<IReadOnlyList<Response>> GetAsync() { }

// AutoBogusFilter boguses up a Body
public async Task<ActionResult> PostAsync([FromBody]Body body) { }
```

All options work with **ActionResult<>**.

```c#
// AutoBogusFilter boguses up a Response
public async Task<ActionResult<Response>> GetAsync() { }
```