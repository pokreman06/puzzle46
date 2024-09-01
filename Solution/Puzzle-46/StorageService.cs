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
