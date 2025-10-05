using MeowControls.Avalonia.Terminal.Core.Buffer;
using MeowControls.Avalonia.Terminal.Options;

namespace MeowControls.Avalonia.Terminal.Core.Buffer;

public class TextBuffer(TerminalOptions options, Components components) : ConfigurableComponent(options: options)
{
    private RowBuffer<Row> _buffer = new(options.MaxHistoryRows);
    
    

}