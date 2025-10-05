using MeowControls.Terminal.Options;

namespace MeowControls.Terminal.Core.Buffer;

public class TextBuffer(TerminalOptions options, Components components) : ConfigurableComponent(options)
{
    private RowBuffer<Row> _buffer = new(options.MaxHistoryRows);
}