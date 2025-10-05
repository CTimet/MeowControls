using System;
using Avalonia;
using Avalonia.Media;
using MeowControls.Terminal.Extensions;
using MeowControls.Terminal.Options;

namespace MeowControls.Terminal.Core.Render;

#pragma warning disable CS9107 // 参数捕获到封闭类型状态，其值也传递给基构造函数。该值也可能由基类捕获。
public class Renderer(TerminalOptions options, Components components) : ConfigurableComponent(options)
#pragma warning restore CS9107 // 参数捕获到封闭类型状态，其值也传递给基构造函数。该值也可能由基类捕获。
{
    public void Render(DrawingContext context)
    {
        //渲染终端界面

        #region STEP1 渲染背景图片

        if (options.BackgroundImage is not null)
        {
            context.DrawImage(options.BackgroundImage, new Rect()); //这个 Rect 记得换

            throw new NotImplementedException("等待实现 图片覆盖/填充等等拉伸方式，以及不透明度等");
        }

        #endregion

        #region STEP2 渲染字符背景

        var lineHeight = options.FontFamily.GetFHeight(options.FontSize);

        //创建行背景渲染器，根据字体是否为等宽字体赋值
        LineBackgroundRenderer lbRenderer = options.FontFamily.IsMonospaceFont()
            ? new MonoLBRenderer(options, lineHeight)
            : new NonMonoLBRenderer(options, lineHeight);

        //调用行背景渲染器。渲染每一行的字符背景

        #endregion
    }
}