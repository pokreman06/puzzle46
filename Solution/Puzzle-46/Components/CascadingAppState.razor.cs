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
