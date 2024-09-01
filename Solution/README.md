# Blazor Puzzle #46

## Injection Rejection!

YouTube Video: https://youtu.be/gHnFy9A58Zc

Blazor Puzzle Home Page: https://blazorpuzzle.com

### The Challenge:

This is a .NET 8 Blazor Web App with Global Server interactivity.

We have defined a CascadingAppState component and made it available to all components in the app.

We have also defined a scoped service called StorageService and injected it into Home.razor.

How can we access the CascadingAppState component INSIDE the StorageService?

See the commented code in StorageService to get an idea of what we want to do.

### The Solution:

There are multiple solutions to this problem. You could just inject the StorageService into the Page that needs to use it. Along with the CascadingAppState being available in the same page, the code would have access to the state data AND the storage service.

However, we kind of obfuscated the problem by implying that we SHOULD inject CascadingAppState into StorageService. You could do that by providing a public method that would accept a CascadingAppState. This would be a decent alternative to dependency injection, but there are issues.

1) If you do not call the method, it opens up the app for null reference exception runtime errors.
2) CascadingAppState is a component, which exists at a higher level than a simple C# class. It is therefore integrated into the Blazor Component Model. Those features (StateHasChanged, for example) are not available inside a C# class.

The answer we are looking for is to flip the script, and inject the StorageService into CascadingAppState. That way, the service can be easily called, and everyone is happy.

We would have also accepted the first idea, injecting the StorageService into a page, and making the calls from there, but nobody thought of that.

Here is the updated StorageService:

*StorageService.cs*:

```c#
using Puzzle_46.Components;

namespace Puzzle_46;

public class StorageService
{
    public string Message { get; set; } = "Hello from my service";

    public void SetMessage(string message)
    {
        Message = message;
    }

    public string GetMessage()
    {
        // How can we access the CascadingAppState from here?

        return Message;
    }
}
```

And the updated CascadingAppState:

*CascadingAppState.razor.cs*:

```c#
using Microsoft.AspNetCore.Components;

namespace Puzzle_46.Components;

public partial class CascadingAppState : ComponentBase
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Inject]
    public StorageService StorageService { get; set; }

    public string Message
    {
        get => StorageService.GetMessage();
        set
        {
            StorageService.SetMessage(value);
            // Force a re-render
            StateHasChanged();
        }
    }
}
```

Boom!
