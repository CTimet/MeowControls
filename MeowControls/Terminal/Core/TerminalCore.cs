using MeowControls.Controls.Terminal.Options;

namespace MeowControls.Controls.Terminal.Core;

public class TerminalCore(TerminalOptions options) : ConfigurableComponent(options)
{
    public Components Components { get; private set; } = new(options);
}