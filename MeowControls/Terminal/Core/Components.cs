using MeowControls.Controls.Terminal.Core.Buffer;
using MeowControls.Controls.Terminal.Core.Dispatch;
using MeowControls.Controls.Terminal.Core.Render;
using MeowControls.Controls.Terminal.Options;

namespace MeowControls.Controls.Terminal.Core;

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