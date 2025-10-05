using System;
using Avalonia.Media;
using MeowControls.Terminal.Core.Buffer;
using MeowControls.Terminal.Options;

namespace MeowControls.Terminal.Core.Render;

// ReSharper disable once InconsistentNaming
/// <summary>
///     等宽字符 行背景渲染器。LB=LineBackground
/// </summary>
/// <param name="options">终端参数</param>
/// <param name="lineHeight">行高</param>
public class MonoLBRenderer(TerminalOptions options, double lineHeight)
    : LineBackgroundRenderer(options, lineHeight)
{
    public override void Render(DrawingContext context, Row row)
    {
        throw new NotImplementedException();
    }
}