using System;
using Avalonia.Media;
using MeowControls.Terminal.Core.Buffer;
using MeowControls.Terminal.Options;

namespace MeowControls.Terminal.Core.Render;

// ReSharper disable once InconsistentNaming
public class NonMonoLBRenderer(TerminalOptions options, double lineHeight) : LineBackgroundRenderer(options, lineHeight)
{
    public override void Render(DrawingContext context, Row row)
    {
        throw new NotImplementedException();
    }
}