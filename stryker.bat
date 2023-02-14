dotnet tool restore
dotnet restore
dotnet build --no-restore
dotnet stryker -tp tests/PowerUtils.AspNetCore.ErrorHandler.Validations.Tests/PowerUtils.AspNetCore.ErrorHandler.Validations.Tests.csproj -p PowerUtils.AspNetCore.ErrorHandler.Validations.csproj --reporter cleartext --reporter html -o