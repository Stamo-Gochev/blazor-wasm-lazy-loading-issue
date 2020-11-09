# blazor-wasm-lazy-loading-issue

## Issue https://github.com/dotnet/aspnetcore/issues/27637
### Describe the bug
Using [lazy loading of assemblies](https://docs.microsoft.com/en-us/aspnet/core/blazor/webassembly-lazy-load-assemblies?view=aspnetcore-5.0) throws an error when navigating between pages.

### Additional context
A blazor wasm [project](https://github.com/Stamo-Gochev/blazor-wasm-lazy-loading-issue/tree/master/BlazorWasmLazyLoading) is configured to use lazy loading for a [class library project](https://github.com/Stamo-Gochev/blazor-wasm-lazy-loading-issue/tree/master/BlazorWasmLazyLoading/MyComponents) that has some [dependencies](https://github.com/Stamo-Gochev/blazor-wasm-lazy-loading-issue/blob/171e24ba8046ad48809893d6ff25e658882c8fc2/BlazorWasmLazyLoading/MyComponents/MyComponents.csproj#L13-L16). The app is inspired by the [example from Dan Roth](https://github.com/danroth27/BlazorNet5Samples/blob/3ad3f531330d10754fe7cce3ad063b7f6b86da63/Client/BlazorNet5Samples.Client.csproj#L22) and the [MyComponents](https://github.com/danroth27/BlazorNet5Samples/tree/master/MyComponents) lib. The [Counter.razor](https://github.com/Stamo-Gochev/blazor-wasm-lazy-loading-issue/blob/c6e3875754849d0cadb3ec037b49832b41e2084a/BlazorWasmLazyLoading/BlazorWasmLazyLoading/Client/Pages/Counter.razor#L1) page is intentionally implemented to load a separate [layout page](https://github.com/Stamo-Gochev/blazor-wasm-lazy-loading-issue/blob/master/BlazorWasmLazyLoading/BlazorWasmLazyLoading/Client/Shared/LazyLoadedMainLayout.razor), so that the required assemblies are loaded only if this page is requested.


### To Reproduce
1. Clone https://github.com/Stamo-Gochev/blazor-wasm-lazy-loading-issue
2. Set the [server project](https://github.com/Stamo-Gochev/blazor-wasm-lazy-loading-issue/tree/master/BlazorWasmLazyLoading/BlazorWasmLazyLoading/Server) as a startup project
3. Run the app by pressing `Ctrl + F5`
4. Navigate between the "Index" and "Lazy loading" tab a few times.

![lazy-loading-renderer-error-components](https://user-images.githubusercontent.com/1857705/98511207-0ecc9400-226d-11eb-85b4-02c7e575e786.gif)

**Note:** The exact number of navigations depends on the number of components (lowering the number of components requires more navigation clicks for the error to be thrown). A more real-world scenario might be for a page to contain multiple grid components with a decent number of rows and columns, e.g. 5 grids with 20x20 cells on the same page.

#### Expected
No error is thrown

#### Actual
An exception is thrown and the app crashes

### Exceptions (if any)
AN exception is thrown in the console
> crit: Microsoft.AspNetCore.Components.WebAssembly.Rendering.WebAssemblyRenderer[100]
      Unhandled exception rendering component: Non-static method requires a target.
System.Reflection.TargetException: Non-static method requires a target.
   at System.Reflection.RuntimeConstructorInfo.InternalInvoke(Object obj, Object[] parameters, Boolean wrapExceptions)
   at System.RuntimeType.CreateInstanceMono(Boolean nonPublic, Boolean wrapExceptions)
   at System.RuntimeType.CreateInstanceSlow(Boolean publicOnly, Boolean wrapExceptions, Boolean skipCheckThis, Boolean fillCache)
   at System.RuntimeType.CreateInstanceDefaultCtor(Boolean publicOnly, Boolean skipCheckThis, Boolean fillCache, Boolean wrapExceptions)
   at System.Activator.CreateInstance(Type type, Boolean nonPublic, Boolean wrapExceptions)
   at System.Activator.CreateInstance(Type type, Boolean nonPublic)
   at System.Activator.CreateInstance(Type type)
   at Microsoft.AspNetCore.Components.DefaultComponentActivator.CreateInstance(Type componentType)
   at Microsoft.AspNetCore.Components.ComponentFactory.InstantiateComponent(IServiceProvider serviceProvider, Type componentType)
   at Microsoft.AspNetCore.Components.RenderTree.Renderer.InstantiateComponent(Type componentType)
   at Microsoft.AspNetCore.Components.RenderTree.Renderer.InstantiateChildComponentOnFrame(RenderTreeFrame& frame, Int32 parentComponentId)
   at Microsoft.AspNetCore.Components.RenderTree.RenderTreeDiffBuilder.InitializeNewComponentFrame(DiffContext& diffContext, Int32 frameIndex)
   at Microsoft.AspNetCore.Components.RenderTree.RenderTreeDiffBuilder.InitializeNewSubtree(DiffContext& diffContext, Int32 frameIndex)
   at Microsoft.AspNetCore.Components.RenderTree.RenderTreeDiffBuilder.InsertNewFrame(DiffContext& diffContext, Int32 newFrameIndex)
   at Microsoft.AspNetCore.Components.RenderTree.RenderTreeDiffBuilder.AppendDiffEntriesForRange(DiffContext& diffContext, Int32 oldStartIndex, Int32 oldEndIndexExcl, Int32 newStartIndex, Int32 newEndIndexExcl)
   at Microsoft.AspNetCore.Components.RenderTree.RenderTreeDiffBuilder.ComputeDiff(Renderer renderer, RenderBatchBuilder batchBuilder, Int32 componentId, ArrayRange`1 oldTree, ArrayRange`1 newTree)
   at Microsoft.AspNetCore.Components.Rendering.ComponentState.RenderIntoBatch(RenderBatchBuilder batchBuilder, RenderFragment renderFragment)
   at Microsoft.AspNetCore.Components.RenderTree.Renderer.RenderInExistingBatch(RenderQueueEntry renderQueueEntry)
   at Microsoft.AspNetCore.Components.RenderTree.Renderer.ProcessRenderQueue()

### Further technical details
- ASP.NET Core version 5.0 RC2
- Include the output of `dotnet --info` 
- The IDE (VS / VS Code/ VS4Mac) latest

---

## Issue https://github.com/dotnet/aspnetcore/issues/27331
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
