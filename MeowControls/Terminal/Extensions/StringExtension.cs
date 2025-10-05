using System.Globalization;
using Avalonia.Media;

namespace MeowControls.Terminal.Extensions;

public static class StringExtension
{
    public static FormattedText ToFormattedText(this string content, Typeface typeface, double emSize, IBrush? brush)
    {
        return new FormattedText(
            content,
            CultureInfo.CurrentCulture,
            FlowDirection.LeftToRight,
            typeface,
            emSize,
            brush
        );
    }
}