using Avalonia.Media;
using MeowControls.Avalonia.Terminal.Core.Buffer;
using MeowControls.Avalonia.Terminal.Core.Buffer;
using MeowControls.Avalonia.Terminal.Options;

namespace MeowControls.Avalonia.Terminal.Core.Render;

// ReSharper disable once InconsistentNaming
public class NonMonoLBRenderer(TerminalOptions options, double lineHeight) : LineBackgroundRenderer(options, lineHeight)
{
    public override void Render(DrawingContext context, Row row)
    {
        throw new System.NotImplementedException();
    }
}