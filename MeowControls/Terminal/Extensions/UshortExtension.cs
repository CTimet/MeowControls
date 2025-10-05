using System;
using Avalonia.Media;

namespace MeowControls.Terminal.Extensions;

/// <summary>
///     RenderRow 中使用一个ushort数组，利用ushort的前8位与后8位储存字符前景色与背景色。为方便计算颜色遂编写此扩展类
/// </summary>
public static class UshortExtension
{
    public static IBrush GetForegroundBrush(this ushort? brushInfo, IBrush defaultBrush)
    {
        if (brushInfo is null) return defaultBrush;

        //ushort的前8bit保留的是字符前景色。我们取其前8位。
        switch (brushInfo & 0xFF00)
        {
            //TODO
        }

        throw new NotImplementedException();
    }

    public static IBrush GetBackgroundBrush(this ushort? brushInfo, IBrush defaultBrush)
    {
        if (brushInfo is null) return defaultBrush;

        //ushort的后8bit保留的是字符背景色。我们取其后8位
        switch (brushInfo & 0x00FF)
        {
            //TODO 
        }

        throw new NotImplementedException();
    }
}