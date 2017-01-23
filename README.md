E5R .NET Utilities
==================

E5R Development Team .NET Utilities.

## NuGet packages
* [E5R.DotNet.Utilities.AspNetCore](https://www.nuget.org/packages/E5R.DotNet.Utilities.AspNetCore)

## Functionalities

### SPA `AngularJS routes`

```
NuGet: Install-Package E5R.DotNet.Utilities.AspNetCore
```

```cs
public class Startup
{
    public void Configure(IApplicationBuilder app)
    {
        app.UseSPA();
    }
}
```