using MeowControls.Avalonia.Terminal.Core.Buffer;
using MeowControls.Avalonia.Terminal.Core.Dispatch;
using MeowControls.Avalonia.Terminal.Core.Render;
using MeowControls.Avalonia.Terminal.Options;

namespace MeowControls.Avalonia.Terminal.Core;

public class Components : ConfigurableComponent
{
    public Renderer Renderer { get; private set; }

    public TextBuffer TextBuffer { get; private set; }
    
    public VTDispatcher VTDispatcher { get; private set; }

    public Components(TerminalOptions options) : base(options)
    {
        Renderer = new Renderer(options, this);
        TextBuffer = new TextBuffer(options, this);
        VTDispatcher = new VTDispatcher(options, this);
    }
}