using Avalonia.Media;
using MeowControls.Controls.Terminal.Core.Buffer;
using MeowControls.Controls.Terminal.Options;

namespace MeowControls.Controls.Terminal.Core.Render;

// ReSharper disable once InconsistentNaming
public class NonMonoLBRenderer(TerminalOptions options, double lineHeight) : LineBackgroundRenderer(options, lineHeight)
{
    public override void Render(DrawingContext context, Row row)
    {
        throw new System.NotImplementedException();
    }
}