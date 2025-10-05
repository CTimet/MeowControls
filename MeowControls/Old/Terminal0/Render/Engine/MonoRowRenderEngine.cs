using System;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using Avalonia;
using Avalonia.Media;
using MeowControls.Avalonia.Terminal.Extensions;

namespace MeowControls.Controls.Terminal0.Render.Engine;

/// <summary>
/// 用于渲染等宽字体的行渲染引擎。
/// 该渲染引擎能够将多个字符在同一个FormattedText对象中构造。从而减轻CPU运算量
/// </summary>
public class MonoRowRenderEngine(
    Typeface typeface, 
    double fontSize, 
    IBrush defaultForeground,
    IBrush selectedBackground,
    IBrush selectedForeground,
    double cellWidth,
    double cellHeight
    ) : IRowRenderEngine
{
    public void Render(RenderRow row, Point origin, DrawingContext context)
    {
        #region 先进行背景色的渲染
        
        //该算法是，先取出第一个字符位置的背景色，以该背景色为基础背景色，然后不断的读取后面的字符的颜色
        //如果后面字符的颜色，也同样等同于基础背景色，则继续往后读取
        //如果后面字符的颜色，不是基础背景色，则读取结束，先把前面的部分渲染出来
        //然后更改基础背景色，再往后读，直到读到行末尾
        //如果遇到被选中的字符，也同样改变背景色
        var basicBackground = GetBackground(row, 0);
        var drawBackgroundFrom = origin;
        for (var i = 1; i < row.Content.Length; i++)
        {
            if (GetBackground(row, i).Equals(basicBackground))
            {
                continue;
            }

            //颜色发生了改变。把前面的颜色渲染出来
            context.DrawRectangle(basicBackground, new Pen(), new Rect(drawBackgroundFrom, new Size(i * cellWidth - origin.Y, cellHeight)));
            //然后改变基础背景色
            basicBackground = GetBackground(row, i);
            //再把渲染起点往后移
            drawBackgroundFrom = drawBackgroundFrom.WithY(i * cellWidth - drawBackgroundFrom.Y);
        }
        //我们最后还得把行末尾的颜色渲染出来
        context.DrawRectangle(basicBackground, new Pen(), new Rect(drawBackgroundFrom, new Size(row.Content.Length * cellWidth, cellHeight)));

        #endregion

        #region 再进行字符的渲染

        //该算法与前面的算法类似
        var basicForeground = GetForeground(row, 0);
        var drawForegroundFrom = origin;
        var copySourceIndex = 0;
        for (var i = 1; i < row.Content.Length; i++)
        {
            if (GetForeground(row, i).Equals(basicForeground))
            {
                continue;
            }
            
            //TODO
            //这段渲染逻辑是有问题的
            //字符前景色发生了改变。渲染
            var content = new char[i];
            CopyContent(row.Content, content, copySourceIndex, i, i-copySourceIndex);
            //渲染字符
            context.DrawText(new string(content).ToFormattedText(typeface, fontSize, basicForeground), drawForegroundFrom);
            //然后改变基础颜色
            basicForeground = GetForeground(row, i);
            //再把渲染起点往后移
            drawForegroundFrom = drawForegroundFrom.WithY(i * cellWidth - drawForegroundFrom.Y);
        }

        var rowChars = new char[row.Content.Length];
        CopyContent(row.Content, rowChars, copySourceIndex, 0, row.Content.Length);

        #endregion
    }
//TODO
//这个方法是有问题的
    private void CopyContent(char?[] originContent, char[] destinationContent, int from, int to, int length)
    {
        if (from >= originContent.Length
            || to >= destinationContent.Length
            || to + length > destinationContent.Length)
        {
            throw new IndexOutOfRangeException("CopyContent");
        }

        for (var i = 0; i < length; i++)
        {
            destinationContent[to + i] = originContent[from + i] is null ? '\0' : (char)originContent[i]!;
        }
    }

    private IBrush GetForeground(RenderRow row, int index)
    {
        if (row.IsSomeCharSelected
            && index >= row.SelectedFromIndex && index <= row.SelectedToIndex)
        {
            return selectedForeground;
        }

        return row.Attribute[index].GetForegroundBrush(defaultForeground);
    }

    private IBrush GetBackground(RenderRow row, int index)
    {
        if (row.IsSomeCharSelected
            && index >= row.SelectedFromIndex && index <= row.SelectedToIndex)
        {
            return selectedBackground;
        }

        return row.Attribute[index].GetBackgroundBrush(Brushes.Transparent);
    }
    

    private FormattedText GetFormattedText(string str, IBrush? foreground)
    {
        return new FormattedText(
            str,
            CultureInfo.CurrentCulture,
            FlowDirection.LeftToRight,
            typeface,
            fontSize,
            foreground
        );
    }
}