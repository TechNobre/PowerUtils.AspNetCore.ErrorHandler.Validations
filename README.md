# PowerUtils.AspNetCore.ErrorHandler.Validations

# :warning: DEPRECATED

This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.

![Logo](https://raw.githubusercontent.com/TechNobre/PowerUtils.AspNetCore.ErrorHandler.Validations/main/assets/logo/logo_128x128.png)

***Add middleware in AspNetCore pipeline to standardize validation responses***

[![License: MIT](https://img.shields.io/github/license/TechNobre/PowerUtils.AspNetCore.ErrorHandler.Validations.svg)](https://github.com/TechNobre/PowerUtils.AspNetCore.ErrorHandler.Validations/blob/main/LICENSE)


- [Support to ](#support-to-)
- [Dependencies ](#dependencies-)
- [How to use ](#how-to-use-)
  - [Install NuGet package ](#install-nuget-package-)
  - [Validation notifications middleware ](#validation-notifications-middleware-)
- [Contribution ](#contribution-)



## Support to <a name="support-to"></a>
- .NET 7.0
- .NET 6.0
- .NET 5.0



## Dependencies <a name="dependencies"></a>

- Microsoft.AspNetCore.Mvc [NuGet](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc/)
- PowerUtils.AspNetCore.ErrorHandler [NuGet](https://www.nuget.org/packages/PowerUtils.AspNetCore.ErrorHandler/)
- PowerUtils.Validations [NuGet](https://www.nuget.org/packages/PowerUtils.Validations/)



## How to use <a name="how-to-use"></a>

### Install NuGet package <a name="Installation"></a>
This package is available through Nuget Packages: https://www.nuget.org/packages/PowerUtils.AspNetCore.ErrorHandler.Validations

**Nuget**
```bash
Install-Package PowerUtils.AspNetCore.ErrorHandler.Validations
```

**.NET CLI**
```
dotnet add package PowerUtils.AspNetCore.ErrorHandler.Validations
```



### Validation notifications middleware <a name="ValidationNotificationsMiddleware"></a>
You need to add `services.AddErrorHandler();` for `services.AddValidationNotifications();` to work
```csharp
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        ...
        services.AddValidationNotifications();
        services.AddErrorHandler();
        ...
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseErrorHandler();
        ...
    }
}
```



## Contribution <a name="contribution"></a>

If you have any questions, comments, or suggestions, please open an [issue](https://github.com/TechNobre/PowerUtils.AspNetCore.ErrorHandler.Validations/issues/new/choose) or create a [pull request](https://github.com/TechNobre/PowerUtils.AspNetCore.ErrorHandler.Validations/compare)
