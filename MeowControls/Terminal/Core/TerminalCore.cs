using MeowControls.Avalonia.Terminal.Options;

namespace MeowControls.Avalonia.Terminal.Core;

public class TerminalCore(TerminalOptions options) : ConfigurableComponent(options)
{
    public Components Components { get; private set; } = new(options);
}