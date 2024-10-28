using Puzzle_46.Components;

namespace Puzzle_46;

public class StorageService
{
    public string Message { get; set; } = "Hello from my service";
    private CascadingAppState _cascadingAppState;

    public void initialize(CascadingAppState cascadingAppState)
    {
        _cascadingAppState = cascadingAppState;
    }

    public void SetMessage(string message)
    {
        Message = message;
    }

    public string GetMessage()
    {
        // How can we access the CascadingAppState from here?
        if (_cascadingAppState != null)
            return _cascadingAppState.Message;
        else return Message;

    }
}
