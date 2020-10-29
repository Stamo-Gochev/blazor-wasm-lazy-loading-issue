# blazor-wasm-lazy-loading-issue

### Describe the bug
Using [lazy loading of assemblies](https://docs.microsoft.com/en-us/aspnet/core/blazor/webassembly-lazy-load-assemblies?view=aspnetcore-5.0) fails when a service extension method is used.

### Additional context
A blazor wasm [project](https://github.com/Stamo-Gochev/blazor-wasm-lazy-loading-issue/tree/master/BlazorWasmLazyLoading) is configured to use lazy loading for a [class library project](https://github.com/Stamo-Gochev/blazor-wasm-lazy-loading-issue/tree/master/BlazorWasmLazyLoading/MyComponents) that has some [dependencies](https://github.com/Stamo-Gochev/blazor-wasm-lazy-loading-issue/blob/171e24ba8046ad48809893d6ff25e658882c8fc2/BlazorWasmLazyLoading/MyComponents/MyComponents.csproj#L13-L16). The app is inspired by the [example from Dan Roth](https://github.com/danroth27/BlazorNet5Samples/blob/3ad3f531330d10754fe7cce3ad063b7f6b86da63/Client/BlazorNet5Samples.Client.csproj#L22) and the [MyComponents](https://github.com/danroth27/BlazorNet5Samples/tree/master/MyComponents) lib.

The problem occurs when a [service extension method](https://github.com/Stamo-Gochev/blazor-wasm-lazy-loading-issue/blob/171e24ba8046ad48809893d6ff25e658882c8fc2/BlazorWasmLazyLoading/BlazorWasmLazyLoading/Client/Program.cs#L25) is used, which is [empty](https://github.com/Stamo-Gochev/blazor-wasm-lazy-loading-issue/blob/171e24ba8046ad48809893d6ff25e658882c8fc2/BlazorWasmLazyLoading/MyComponents/ServiceExtensions/ServiceCollectionExtensions.cs#L7-L10). [Not using this method](https://github.com/Stamo-Gochev/blazor-wasm-lazy-loading-issue/blob/171e24ba8046ad48809893d6ff25e658882c8fc2/BlazorWasmLazyLoading/BlazorWasmLazyLoading/Client/Program.cs#L20-L22) works as expected and no errors are thrown.

### To Reproduce
1. Clone https://github.com/Stamo-Gochev/blazor-wasm-lazy-loading-issue
2. Set the [server project](https://github.com/Stamo-Gochev/blazor-wasm-lazy-loading-issue/tree/master/BlazorWasmLazyLoading/BlazorWasmLazyLoading/Server) as a startup project
3. Run the app by pressing `Ctrl + F5`
4. Click on the "Lazy loading" tab to open a page with lazy loading (the index page does not include this intentionally).

#### Expected
The dependency assemblies are loaded without errors.

#### Actual
An exception is thrown and the app crashes

### Exceptions (if any)
AN exception is thrown in the console
> System.IO.FileNotFoundException: Could not load file or assembly 'MyComponents, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies.

### Further technical details
- ASP.NET Core version 5.0 RC2
- Include the output of `dotnet --info` 
- The IDE (VS / VS Code/ VS4Mac) latest
