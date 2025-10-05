using System.Globalization;
using Avalonia.Media;

namespace MeowControls.Terminal.Extensions;

public static class FontFamilyExtension
{
    public static bool IsMonospaceFont(this FontFamily fontFamily)
    {
        var m = new FormattedText("M",
            CultureInfo.CurrentCulture,
            FlowDirection.LeftToRight,
            new Typeface(fontFamily),
            10, Brushes.Aqua);
        var i = new FormattedText("i",
            CultureInfo.CurrentCulture,
            FlowDirection.LeftToRight,
            new Typeface(fontFamily),
            10, Brushes.Aqua);
        //对于非等宽字体，该方法将返回null
        return m.Width.Equals(i.Width);
    }

    /// <summary>
    ///     得到 M 字符的宽度。该宽度被用作Render Cell的宽
    /// </summary>
    public static double GetMWidth(this FontFamily fontFamily, double emSize)
    {
        return "M".ToFormattedText(new Typeface(fontFamily), emSize, Brushes.Aqua).Width;
    }

    /// <summary>
    ///     得到 f 字符的高度。该高度被用作Render Cell的高
    /// </summary>
    public static double GetFHeight(this FontFamily fontFamily, double emSize)
    {
        return "f".ToFormattedText(new Typeface(fontFamily), emSize, Brushes.Aqua).Height;
    }
}