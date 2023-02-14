# PowerUtils.AspNetCore.ErrorHandler.Validations

![Logo](https://raw.githubusercontent.com/TechNobre/PowerUtils.AspNetCore.ErrorHandler.Validations/main/assets/logo/logo_128x128.png)

***Add middleware in AspNetCore pipeline to standardize validation responses***

![Tests](https://github.com/TechNobre/PowerUtils.AspNetCore.ErrorHandler.Validations/actions/workflows/tests.yml/badge.svg)
[![Mutation tests](https://img.shields.io/endpoint?style=flat&url=https%3A%2F%2Fbadge-api.stryker-mutator.io%2Fgithub.com%2FTechNobre%2FPowerUtils.AspNetCore.ErrorHandler.Validations%2Fmain)](https://dashboard.stryker-mutator.io/reports/github.com/TechNobrePowerUtils.AspNetCore.ErrorHandler.Validations/main)

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=TechNobre_PowerUtils.AspNetCore.ErrorHandler.Validations&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=TechNobre_PowerUtils.AspNetCore.ErrorHandler.Validations)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=TechNobre_PowerUtils.AspNetCore.ErrorHandler.Validations&metric=coverage)](https://sonarcloud.io/summary/new_code?id=TechNobre_PowerUtils.AspNetCore.ErrorHandler.Validations)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=TechNobre_PowerUtils.AspNetCore.ErrorHandler.Validations&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=TechNobre_PowerUtils.AspNetCore.ErrorHandler.Validations)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=TechNobre_PowerUtils.AspNetCore.ErrorHandler.Validations&metric=bugs)](https://sonarcloud.io/summary/new_code?id=TechNobre_PowerUtils.AspNetCore.ErrorHandler.Validations)

[![NuGet](https://img.shields.io/nuget/v/PowerUtils.AspNetCore.ErrorHandler.Validations.svg)](https://www.nuget.org/packages/PowerUtils.AspNetCore.ErrorHandler.Validations)
[![Nuget](https://img.shields.io/nuget/dt/PowerUtils.AspNetCore.ErrorHandler.Validations.svg)](https://www.nuget.org/packages/PowerUtils.AspNetCore.ErrorHandler.Validations)
[![License: MIT](https://img.shields.io/github/license/TechNobre/PowerUtils.AspNetCore.ErrorHandler.Validations.svg)](https://github.com/TechNobre/PowerUtils.AspNetCore.ErrorHandler.Validations/blob/main/LICENSE)


- [Support](#support-to)
- [Dependencies](#dependencies)
- [How to use](#how-to-use)
  - [Install NuGet package](#Installation)
  - [ValidationNotificationsMiddleware](#ValidationNotificationsMiddleware)
- [Contribution](#contribution)
- [License](./LICENSE)
- [Changelog](./CHANGELOG.md)



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