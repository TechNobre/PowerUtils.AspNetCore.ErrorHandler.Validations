# PowerUtils.AspNetCore.ErrorHandler.Validations
Add middleware in AspNetCore pipeline to standardize validation responses

![Tests](https://github.com/TechNobre/PowerUtils.AspNetCore.ErrorHandler.Validations/actions/workflows/test-project.yml/badge.svg)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=TechNobre_PowerUtils.AspNetCore.ErrorHandler.Validations&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=TechNobre_PowerUtils.AspNetCore.ErrorHandler.Validations)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=TechNobre_PowerUtils.AspNetCore.ErrorHandler.Validations&metric=coverage)](https://sonarcloud.io/summary/new_code?id=TechNobre_PowerUtils.AspNetCore.ErrorHandler.Validations)

[![NuGet](https://img.shields.io/nuget/v/PowerUtils.AspNetCore.ErrorHandler.Validations.svg)](https://www.nuget.org/packages/PowerUtils.AspNetCore.ErrorHandler.Validations)
[![Nuget](https://img.shields.io/nuget/dt/PowerUtils.AspNetCore.ErrorHandler.Validations.svg)](https://www.nuget.org/packages/PowerUtils.AspNetCore.ErrorHandler.Validations)
[![License: MIT](https://img.shields.io/github/license/TechNobre/PowerUtils.AspNetCore.ErrorHandler.Validations.svg)](https://github.com/TechNobre/PowerUtils.AspNetCore.ErrorHandler.Validations/blob/main/LICENSE)



## Support to
- .NET 5.0
- .NET 6.0



## Features

- [Installation](#Installation)
- [ValidationNotificationsMiddleware](#ValidationNotificationsMiddleware)


## Documentation

### Dependencies

- Microsoft.AspNetCore.Mvc [NuGet](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc/)
- PowerUtils.AspNetCore.ErrorHandler [NuGet](https://www.nuget.org/packages/PowerUtils.AspNetCore.ErrorHandler/)
- PowerUtils.Validations [NuGet](https://www.nuget.org/packages/PowerUtils.Validations/)


### How to use

#### Install NuGet package <a name="Installation"></a>
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



## Contribution

*Help me to help others*




## LICENSE

[MIT](https://github.com/TechNobre/PowerUtils.AspNetCore.ErrorHandler.Validations/blob/main/LICENSE)




## Changelog

[Here](./CHANGELOG.md)