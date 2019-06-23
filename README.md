# Gengo.Client
C# client for the Gengo translation service API - https://gengo.com/

## Usage
You will need the NuGet package `Microsoft.Extensions.DependencyInjection`.
```csharp
IGengoConfigV2 config = new GengoConfigV2
{
    Key = "key",
    Secret = "secret"
};

ServiceCollection services = new ServiceCollection();

services.AddGengoClientV2(config, options => options.BaseAddress = new Uri("http://api.gengo.com/"));

IServiceProvider provider = services.BuildServiceProvider();

IGengoClientV2 client = provider.GetRequiredService<IGengoClientV2>();
```
