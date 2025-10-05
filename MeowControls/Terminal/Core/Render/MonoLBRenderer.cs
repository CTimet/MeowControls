using Avalonia.Media;
using MeowControls.Controls.Terminal.Core.Buffer;
using MeowControls.Controls.Terminal.Options;

namespace MeowControls.Controls.Terminal.Core.Render;

// ReSharper disable once InconsistentNaming
/// <summary>
/// 等宽字符 行背景渲染器。LB=LineBackground
/// </summary>
/// <param name="options">终端参数</param>
/// <param name="lineHeight">行高</param>
public class MonoLBRenderer(TerminalOptions options, double lineHeight)
    : LineBackgroundRenderer(options, lineHeight)
{
    public override void Render(DrawingContext context, Row row)
    {
        
        
        throw new System.NotImplementedException();
    }
}