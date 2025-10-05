using MeowControls.Controls.Terminal.Options;

namespace MeowControls.Controls.Terminal.Core.Buffer;

public class TextBuffer(TerminalOptions options, Components components) : ConfigurableComponent(options: options)
{
    private RowBuffer<Row> _buffer = new(options.MaxHistoryRows);
    
    

}