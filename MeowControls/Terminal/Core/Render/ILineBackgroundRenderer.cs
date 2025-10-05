using Avalonia;
using Avalonia.Media;
using MeowControls.Avalonia.Terminal.Core.Buffer;
using MeowControls.Avalonia.Terminal.Core.Buffer;
using MeowControls.Avalonia.Terminal.Options;

namespace MeowControls.Avalonia.Terminal.Core.Render;

public abstract class LineBackgroundRenderer(TerminalOptions options, double lineHeight)
{
    protected Point BeginRenderPoint;

    /// <summary>
    /// 指定应当从何位置开始该行的渲染。每次使用行渲染器渲染该行时，都应该重新指定该位置
    /// </summary>
    /// <param name="beginRenderPoint">指定的渲染位置，位于该行渲染位置的左上角的点</param>
    public void Init(Point beginRenderPoint)
    {
        BeginRenderPoint = beginRenderPoint;
    }

    /// <summary>
    /// 渲染当前行
    /// </summary>
    /// <param name="context">DrawingContext</param>
    /// <param name="row">当前行</param>
    public abstract void Render(DrawingContext context, Row row);
}