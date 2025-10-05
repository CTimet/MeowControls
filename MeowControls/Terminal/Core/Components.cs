using MeowControls.Terminal.Core.Buffer;
using MeowControls.Terminal.Core.Dispatch;
using MeowControls.Terminal.Core.Render;
using MeowControls.Terminal.Options;

namespace MeowControls.Terminal.Core;

public class Components : ConfigurableComponent
{
    public Components(TerminalOptions options) : base(options)
    {
        Renderer = new Renderer(options, this);
        TextBuffer = new TextBuffer(options, this);
        VTDispatcher = new VTDispatcher(options, this);
    }

    public Renderer Renderer { get; private set; }

    public TextBuffer TextBuffer { get; private set; }

    public VTDispatcher VTDispatcher { get; private set; }
}