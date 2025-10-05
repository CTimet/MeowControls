using System.Globalization;
using Avalonia;
using Avalonia.Media;

namespace MeowControls.Controls.Terminal0.Render.Engine;

/// <summary>
/// 用于渲染非等宽字体的渲染引擎。由于Terminal渲染的特殊，非等宽字体只能划分成一个一个的小格渲染
/// </summary>
public class NonMonoRowRenderEngine(
    Typeface typeface, 
    double fontSize, 
    IBrush defaultForeground,
    IBrush selectedBackground,
    IBrush selectedForeground,
    double cellWidth,
    double cellHeight
) : IRowRenderEngine
{
    private FormattedTextCache _cache = new FormattedTextCache(typeface, fontSize, defaultForeground);

    public void Render(RenderRow row, Point origin, DrawingContext context)
    {
        
    }
}

/// <summary>
/// 用于储存常用字符（A-Z，a-z，0-9），以节省内存空间，避免new太多重复的FormattedText
/// </summary>
internal class FormattedTextCache
{
    private Typeface _typeface;
    public Typeface Typeface
    {
        get => _typeface;
        set
        {
            //不加，可能会在别的什么地方出现问题，但Renderer中的确做了处理
            //还是加一下吧。也整齐一点
            if (Equals(value, _typeface))
            {
                return;
            }
            _typeface = value;
            //通知更改FormattedText
            ChangeFormattedTextsTypeface();
        }
    }

    private double _fontSize;
    /// <summary>
    /// EM Size
    /// </summary>
    public double FontSize
    {
        get => _fontSize;
        set
        {
            //这个if判断不要删。否则在Renderer中可能会重复引起ChangeFormattedTextsXXX
            if (Equals(value, _fontSize))
            {
                return;
            }
            
            _fontSize = value;
            //通知更改FormattedText
            ChangeFormattedTextsFontSize();
        }
    }

    private IBrush _defaultForeground;
    
    /// <param name="typeface">默认字形</param>
    /// <param name="defaultFontSize">默认大小</param>
    /// <param name="defaultForeground">默认前景色</param>
    public FormattedTextCache(Typeface typeface, double defaultFontSize, IBrush defaultForeground)
    {
        // 不使用 Typeface = defaultTypeface等直接对属性进行赋值的方式，是因为各个属性在这个时候还是null。对属性赋值会调用ChangeFormattedTextXXX，会空指针的
        _typeface = typeface;
        _fontSize = defaultFontSize;
        _defaultForeground = defaultForeground;
        
        // 给各个属性 new FormattedText
        #region New FormattedText

        Empty = new FormattedText(" ", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        
        A = new FormattedText("A", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        B = new FormattedText("B", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        C = new FormattedText("C", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        D = new FormattedText("D", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        E = new FormattedText("E", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        F = new FormattedText("F", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        G = new FormattedText("G", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        H = new FormattedText("H", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        I = new FormattedText("I", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        J = new FormattedText("J", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        K = new FormattedText("K", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        L = new FormattedText("L", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        M = new FormattedText("M", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        N = new FormattedText("N", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        O = new FormattedText("O", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        P = new FormattedText("P", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        Q = new FormattedText("Q", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        R = new FormattedText("R", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        S = new FormattedText("S", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        T = new FormattedText("T", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        U = new FormattedText("U", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        V = new FormattedText("V", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        W = new FormattedText("W", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        X = new FormattedText("X", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        Y = new FormattedText("Y", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        Z = new FormattedText("Z", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);

        a = new FormattedText("a", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        b = new FormattedText("b", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        c = new FormattedText("c", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        d = new FormattedText("d", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        e = new FormattedText("e", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        f = new FormattedText("f", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        g = new FormattedText("g", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        h = new FormattedText("h", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        i = new FormattedText("i", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        j = new FormattedText("j", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        k = new FormattedText("k", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        l = new FormattedText("l", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        m = new FormattedText("m", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        n = new FormattedText("n", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        o = new FormattedText("o", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        p = new FormattedText("p", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        q = new FormattedText("q", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        r = new FormattedText("r", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        s = new FormattedText("s", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        t = new FormattedText("t", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        u = new FormattedText("u", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        v = new FormattedText("v", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        w = new FormattedText("w", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        x = new FormattedText("x", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        y = new FormattedText("y", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        z = new FormattedText("z", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        
        Num0 = new FormattedText("0", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        Num1 = new FormattedText("1", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        Num2 = new FormattedText("2", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        Num3 = new FormattedText("3", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        Num4 = new FormattedText("4", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        Num5 = new FormattedText("5", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        Num6 = new FormattedText("6", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        Num7 = new FormattedText("7", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        Num8 = new FormattedText("8", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        Num9 = new FormattedText("9", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, defaultForeground);
        #endregion
    }

    public FormattedText GetFormattedText(char charC)
    {
        return charC switch
        {
            '\0' => Empty,
            // Uppercase A-Z
            'A' => A,
            'B' => B,
            'C' => C,
            'D' => D,
            'E' => E,
            'F' => F,
            'G' => G,
            'H' => H,
            'I' => I,
            'J' => J,
            'K' => K,
            'L' => L,
            'M' => M,
            'N' => N,
            'O' => O,
            'P' => P,
            'Q' => Q,
            'R' => R,
            'S' => S,
            'T' => T,
            'U' => U,
            'V' => V,
            'W' => W,
            'X' => X,
            'Y' => Y,
            'Z' => Z,
            // Lowercase a-z
            'a' => a,
            'b' => b,
            'c' => c,
            'd' => d,
            'e' => e,
            'f' => f,
            'g' => g,
            'h' => h,
            'i' => i,
            'j' => j,
            'k' => k,
            'l' => l,
            'm' => m,
            'n' => n,
            'o' => o,
            'p' => p,
            'q' => q,
            'r' => r,
            's' => s,
            't' => t,
            'u' => u,
            'v' => v,
            'w' => w,
            'x' => x,
            'y' => y,
            'z' => z,
            // Digits 0-9
            '0' => Num0,
            '1' => Num1,
            '2' => Num2,
            '3' => Num3,
            '4' => Num4,
            '5' => Num5,
            '6' => Num6,
            '7' => Num7,
            '8' => Num8,
            '9' => Num9,
            _ => new FormattedText(charC.ToString(), CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface,
                FontSize, _defaultForeground)
        };
    }


    /// <summary>
    /// 当Typeface被更改时，该方法会被调用。该方法会更改所有FormattedText的Typeface
    /// </summary>
    private void ChangeFormattedTextsTypeface()
    {
        Empty.SetFontTypeface(Typeface);
        
        A.SetFontTypeface(Typeface);
        B.SetFontTypeface(Typeface);
        C.SetFontTypeface(Typeface);
        D.SetFontTypeface(Typeface);
        E.SetFontTypeface(Typeface);
        F.SetFontTypeface(Typeface);
        G.SetFontTypeface(Typeface);
        H.SetFontTypeface(Typeface);
        I.SetFontTypeface(Typeface);
        J.SetFontTypeface(Typeface);
        K.SetFontTypeface(Typeface);
        L.SetFontTypeface(Typeface);
        M.SetFontTypeface(Typeface);
        N.SetFontTypeface(Typeface);
        O.SetFontTypeface(Typeface);
        P.SetFontTypeface(Typeface);
        Q.SetFontTypeface(Typeface);
        R.SetFontTypeface(Typeface);
        S.SetFontTypeface(Typeface);
        T.SetFontTypeface(Typeface);
        U.SetFontTypeface(Typeface);
        V.SetFontTypeface(Typeface);
        W.SetFontTypeface(Typeface);
        X.SetFontTypeface(Typeface);
        Y.SetFontTypeface(Typeface);
        Z.SetFontTypeface(Typeface);
        
        a.SetFontTypeface(Typeface);
        b.SetFontTypeface(Typeface);
        c.SetFontTypeface(Typeface);
        d.SetFontTypeface(Typeface);
        e.SetFontTypeface(Typeface);
        f.SetFontTypeface(Typeface);
        g.SetFontTypeface(Typeface);
        h.SetFontTypeface(Typeface);
        i.SetFontTypeface(Typeface);
        j.SetFontTypeface(Typeface);
        k.SetFontTypeface(Typeface);
        l.SetFontTypeface(Typeface);
        m.SetFontTypeface(Typeface);
        n.SetFontTypeface(Typeface);
        o.SetFontTypeface(Typeface);
        p.SetFontTypeface(Typeface);
        q.SetFontTypeface(Typeface);
        r.SetFontTypeface(Typeface);
        s.SetFontTypeface(Typeface);
        t.SetFontTypeface(Typeface);
        u.SetFontTypeface(Typeface);
        v.SetFontTypeface(Typeface);
        w.SetFontTypeface(Typeface);
        x.SetFontTypeface(Typeface);
        y.SetFontTypeface(Typeface);
        z.SetFontTypeface(Typeface);

        Num0.SetFontTypeface(Typeface);
        Num1.SetFontTypeface(Typeface);
        Num2.SetFontTypeface(Typeface);
        Num3.SetFontTypeface(Typeface);
        Num4.SetFontTypeface(Typeface);
        Num5.SetFontTypeface(Typeface);
        Num6.SetFontTypeface(Typeface);
        Num7.SetFontTypeface(Typeface);
        Num8.SetFontTypeface(Typeface);
        Num9.SetFontTypeface(Typeface);
    }

    /// <summary>
    /// 当FontSize被更改时触发，该方法会更改所有FormattedText的FontSize
    /// </summary>
    private void ChangeFormattedTextsFontSize()
    {
        Empty.SetFontSize(FontSize);
        
        A.SetFontSize(FontSize);
        B.SetFontSize(FontSize);
        C.SetFontSize(FontSize);
        D.SetFontSize(FontSize);
        E.SetFontSize(FontSize);
        F.SetFontSize(FontSize);
        G.SetFontSize(FontSize);
        H.SetFontSize(FontSize);
        I.SetFontSize(FontSize);
        J.SetFontSize(FontSize);
        K.SetFontSize(FontSize);
        L.SetFontSize(FontSize);
        M.SetFontSize(FontSize);
        N.SetFontSize(FontSize);
        O.SetFontSize(FontSize);
        P.SetFontSize(FontSize);
        Q.SetFontSize(FontSize);
        R.SetFontSize(FontSize);
        S.SetFontSize(FontSize);
        T.SetFontSize(FontSize);
        U.SetFontSize(FontSize);
        V.SetFontSize(FontSize);
        W.SetFontSize(FontSize);
        X.SetFontSize(FontSize);
        Y.SetFontSize(FontSize);
        Z.SetFontSize(FontSize);
        
        a.SetFontSize(FontSize);
        b.SetFontSize(FontSize);
        c.SetFontSize(FontSize);
        d.SetFontSize(FontSize);
        e.SetFontSize(FontSize);
        f.SetFontSize(FontSize);
        g.SetFontSize(FontSize);
        h.SetFontSize(FontSize);
        i.SetFontSize(FontSize);
        j.SetFontSize(FontSize);
        k.SetFontSize(FontSize);
        l.SetFontSize(FontSize);
        m.SetFontSize(FontSize);
        n.SetFontSize(FontSize);
        o.SetFontSize(FontSize);
        p.SetFontSize(FontSize);
        q.SetFontSize(FontSize);
        r.SetFontSize(FontSize);
        s.SetFontSize(FontSize);
        t.SetFontSize(FontSize);
        u.SetFontSize(FontSize);
        v.SetFontSize(FontSize);
        w.SetFontSize(FontSize);
        x.SetFontSize(FontSize);
        y.SetFontSize(FontSize);
        z.SetFontSize(FontSize);

        Num0.SetFontSize(FontSize);
        Num1.SetFontSize(FontSize);
        Num2.SetFontSize(FontSize);
        Num3.SetFontSize(FontSize);
        Num4.SetFontSize(FontSize);
        Num5.SetFontSize(FontSize);
        Num6.SetFontSize(FontSize);
        Num7.SetFontSize(FontSize);
        Num8.SetFontSize(FontSize);
        Num9.SetFontSize(FontSize);
    }

    // 缓存好的字形。避免重复new多个FormattedText
    public FormattedText Empty { get; }
    
    public FormattedText A { get; }
    public FormattedText B { get; }
    public FormattedText C { get; }
    public FormattedText D { get; }
    public FormattedText E { get; }
    public FormattedText F { get; }
    public FormattedText G { get; }
    public FormattedText H { get; }
    public FormattedText I { get; }
    public FormattedText J { get; }
    public FormattedText K { get; }
    public FormattedText L { get; }
    public FormattedText M { get; }
    public FormattedText N { get; }
    public FormattedText O { get; }
    public FormattedText P { get; }
    public FormattedText Q { get; }
    public FormattedText R { get; }
    public FormattedText S { get; }
    public FormattedText T { get; }
    public FormattedText U { get; }
    public FormattedText V { get; }
    public FormattedText W { get; }
    public FormattedText X { get; }
    public FormattedText Y { get; }
    public FormattedText Z { get; }
    
    
    public FormattedText a { get; }
    public FormattedText b { get; }
    public FormattedText c { get; }
    public FormattedText d { get; }
    public FormattedText e { get; }
    public FormattedText f { get; }
    public FormattedText g { get; }
    public FormattedText h { get; }
    public FormattedText i { get; }
    public FormattedText j { get; }
    public FormattedText k { get; }
    public FormattedText l { get; }
    public FormattedText m { get; }
    public FormattedText n { get; }
    public FormattedText o { get; }
    public FormattedText p { get; }
    public FormattedText q { get; }
    public FormattedText r { get; }
    public FormattedText s { get; }
    public FormattedText t { get; }
    public FormattedText u { get; }
    public FormattedText v { get; }
    public FormattedText w { get; }
    public FormattedText x { get; }
    public FormattedText y { get; }
    public FormattedText z { get; }
    
    public FormattedText Num0 { get; }
    public FormattedText Num1 { get; }
    public FormattedText Num2 { get; }
    public FormattedText Num3 { get; }
    public FormattedText Num4 { get; }
    public FormattedText Num5 { get; }
    public FormattedText Num6 { get; }
    public FormattedText Num7 { get; }
    public FormattedText Num8 { get; }
    public FormattedText Num9 { get; }
}