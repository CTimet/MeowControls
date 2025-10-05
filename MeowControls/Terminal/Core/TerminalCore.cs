using MeowControls.Terminal.Options;

namespace MeowControls.Terminal.Core;

public class TerminalCore(TerminalOptions options) : ConfigurableComponent(options)
{
    public Components Components { get; private set; } = new(options);
}