using Avalonia;
using Avalonia.Media;

namespace MeowControls.Controls.Terminal0.Render.Engine;

/// <summary>
/// 行渲染引擎的统一接口
/// </summary>
public interface IRowRenderEngine
{
    public void Render(RenderRow row, Point origin, DrawingContext context);
}