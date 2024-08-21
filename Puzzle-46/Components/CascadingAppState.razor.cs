using Microsoft.AspNetCore.Components;

namespace Puzzle_46.Components;

public partial class CascadingAppState : ComponentBase
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    private string message = "";
    public string Message
    {
        get => message;
        set
        {
            message = value;
            // Force a re-render
            StateHasChanged();
        }
    }
}
