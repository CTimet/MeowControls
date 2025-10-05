using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using MeowControls.Controls.Terminal0.Render;

namespace MeowControls.Controls.Terminal0;

public class Terminal : Control
{
    private readonly Renderer _renderer = new();

    public override void Render(DrawingContext context)
    {
        //必须在调用Render之前调用Initialize方法
        _renderer.Initialize(Bounds);

        //由渲染器渲染
        _renderer.Render(context, 0);

        base.Render(context);
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        //加载到视觉树上。初始化渲染器参数
        //虽然那些属性的Setter上都有赋值语句。但是，如果使用Terminal控件时不为这些属性赋值，那么StyledProperty的defaultValue是传不进去的。所以这里要赋值一次
        //那些属性的setter也不能删。如果Terminal控件的这些值是Binding的，那么这些setter就用上了
        _renderer.TopSpaceRemain = TopSpaceRemain;
        _renderer.LeftSpaceRemain = LeftSpaceRemain;
        _renderer.BackgroundImage = BackgroundImage;
        _renderer.MaxSaveRenderRows = MaxSaveRenderRows;
        _renderer.FontSize = FontSize;
        _renderer.NormalForeground = NormalForeground;
        _renderer.SelectedBackground = SelectedBackground;
        _renderer.SelectedForeground = SelectedForeground;
        _renderer.Typeface = new Typeface(FontFamily, FontStyle, FontWeight, FontStretch);

        //计算RenderCell的宽高
        _renderer.ReCalculateRenderCellBounds();

        base.OnAttachedToVisualTree(e);
    }

    protected override void OnDetachedFromVisualTree(VisualTreeAttachmentEventArgs e)
    {
        //从视觉树上卸载。释放可能存在的资源
        _renderer.Dispose();

        base.OnDetachedFromVisualTree(e);
    }

    #region Property

    public static readonly StyledProperty<int> MaxSaveRenderRowsProperty = AvaloniaProperty.Register<Terminal, int>(
        nameof(MaxSaveRenderRows), 9999);

    public static readonly StyledProperty<FontFamily> FontFamilyProperty =
        AvaloniaProperty.Register<Terminal, FontFamily>(
            nameof(FontFamily), FontFamily.Default);

    public static readonly StyledProperty<FontStyle> FontStyleProperty = AvaloniaProperty.Register<Terminal, FontStyle>(
        nameof(FontStyle), FontStyle.Normal);

    public static readonly StyledProperty<FontWeight> FontWeightProperty =
        AvaloniaProperty.Register<Terminal, FontWeight>(
            nameof(FontWeight), FontWeight.Normal);

    public static readonly StyledProperty<FontStretch> FontStretchProperty =
        AvaloniaProperty.Register<Terminal, FontStretch>(
            nameof(FontStretch), FontStretch.Normal);

    public static readonly StyledProperty<double> FontSizeProperty = AvaloniaProperty.Register<Terminal, double>(
        nameof(FontSize), 12.0);

    public static readonly StyledProperty<IImmutableSolidColorBrush> NormalForegroundProperty =
        AvaloniaProperty.Register<Terminal, IImmutableSolidColorBrush>(
            nameof(NormalForeground), Brushes.Black);

    public static readonly StyledProperty<IImmutableSolidColorBrush> SelectedForegroundProperty =
        AvaloniaProperty.Register<Terminal, IImmutableSolidColorBrush>(
            nameof(SelectedForeground), Brushes.Black);

    public static readonly StyledProperty<IImmutableSolidColorBrush> SelectedBackgroundProperty =
        AvaloniaProperty.Register<Terminal, IImmutableSolidColorBrush>(
            nameof(SelectedBackground), Brushes.LightSkyBlue);

    public static readonly StyledProperty<IImage?> BackgroundImageProperty =
        AvaloniaProperty.Register<Terminal, IImage?>(
            nameof(BackgroundImage), null);

    public static readonly StyledProperty<double> LeftSpaceRemainProperty = AvaloniaProperty.Register<Terminal, double>(
        nameof(LeftSpaceRemain), 5.0);

    public static readonly StyledProperty<double> TopSpaceRemainProperty = AvaloniaProperty.Register<Terminal, double>(
        nameof(TopSpaceRemain), 5.0);

    public static readonly StyledProperty<bool> AutoNewLineProperty = AvaloniaProperty.Register<Terminal, bool>(
        nameof(AutoNewLine));

    /// <summary>
    ///     自动换行
    /// </summary>
    public bool AutoNewLine
    {
        get => GetValue(AutoNewLineProperty);
        set => SetValue(AutoNewLineProperty, value);
    }

    /// <summary>
    ///     渲染区域距离上边界的距离。默认 5.0
    /// </summary>
    public double TopSpaceRemain
    {
        get => GetValue(TopSpaceRemainProperty);
        set
        {
            SetValue(TopSpaceRemainProperty, value);
            _renderer.TopSpaceRemain = value;
        }
    }

    /// <summary>
    ///     渲染区域距离左边界的距离。默认 5.0
    /// </summary>
    public double LeftSpaceRemain
    {
        get => GetValue(LeftSpaceRemainProperty);
        set
        {
            SetValue(LeftSpaceRemainProperty, value);
            _renderer.LeftSpaceRemain = value;
        }
    }

    /// <summary>
    ///     背景图像。默认为空（null）。
    /// </summary>
    public IImage? BackgroundImage
    {
        get => GetValue(BackgroundImageProperty);
        set
        {
            SetValue(BackgroundImageProperty, value);
            _renderer.BackgroundImage = value;
        }
    }

    /// <summary>
    ///     字符选中（Selected）时，显示的背景色。默认 Brushes.LightSkyBlue
    /// </summary>
    public IImmutableSolidColorBrush SelectedBackground
    {
        get => GetValue(SelectedBackgroundProperty);
        set
        {
            SetValue(SelectedBackgroundProperty, value);
            _renderer.SelectedBackground = value;
        }
    }

    /// <summary>
    ///     字符选中（Selected）时，显示的前景色。默认 Brushes.Black
    /// </summary>
    public IImmutableSolidColorBrush SelectedForeground
    {
        get => GetValue(SelectedForegroundProperty);
        set
        {
            SetValue(SelectedForegroundProperty, value);
            _renderer.SelectedForeground = value;
        }
    }

    /// <summary>
    ///     字符未选中（Not Selected）时，显示的前景色。默认 Brushes.Black
    /// </summary>
    public IImmutableSolidColorBrush NormalForeground
    {
        get => GetValue(NormalForegroundProperty);
        set
        {
            SetValue(NormalForegroundProperty, value);
            _renderer.NormalForeground = value;
            _renderer.SwitchRowRenderEngine(); //Typeface以及FontSize改变时要切换渲染引擎
        }
    }

    /// <summary>
    ///     此Terminal控件最多可以保存多少历史渲染行。默认 9999
    /// </summary>
    public int MaxSaveRenderRows
    {
        get => GetValue(MaxSaveRenderRowsProperty);
        set
        {
            SetValue(MaxSaveRenderRowsProperty, value);
            _renderer.MaxSaveRenderRows = value;
        }
    }

    /// <summary>
    ///     渲染字体的FontSize。默认12.0
    /// </summary>
    public double FontSize
    {
        get => GetValue(FontSizeProperty);
        set
        {
            if (GetValue(FontSizeProperty).Equals(value)) return;

            SetValue(FontSizeProperty, value);
            _renderer.FontSize = value;
            _renderer.ReCalculateRenderCellBounds();
            _renderer.SwitchRowRenderEngine(); //Typeface以及FontSize改变时要切换渲染引擎
        }
    }

    /// <summary>
    ///     渲染字体的FontStretch。默认Normal
    /// </summary>
    public FontStretch FontStretch
    {
        get => GetValue(FontStretchProperty);
        set
        {
            if (GetValue(FontStretchProperty).Equals(value)) return;

            SetValue(FontStretchProperty, value);
            _renderer.Typeface = new Typeface(FontFamily, FontStyle, FontWeight, FontStretch);
            _renderer.ReCalculateRenderCellBounds();
            _renderer.SwitchRowRenderEngine(); //Typeface以及FontSize改变时要切换渲染引擎
        }
    }

    /// <summary>
    ///     渲染字体的FontWeight。默认Normal
    /// </summary>
    public FontWeight FontWeight
    {
        get => GetValue(FontWeightProperty);
        set
        {
            if (GetValue(FontWeightProperty).Equals(value)) return;

            SetValue(FontWeightProperty, value);
            _renderer.Typeface = new Typeface(FontFamily, FontStyle, FontWeight, FontStretch);
            _renderer.ReCalculateRenderCellBounds();
            _renderer.SwitchRowRenderEngine(); //Typeface以及FontSize改变时要切换渲染引擎
        }
    }

    /// <summary>
    ///     渲染字体的FontStyle。默认Normal
    /// </summary>
    public FontStyle FontStyle
    {
        get => GetValue(FontStyleProperty);
        set
        {
            if (GetValue(FontStyleProperty).Equals(value)) return;

            SetValue(FontStyleProperty, value);
            _renderer.Typeface = new Typeface(FontFamily, FontStyle, FontWeight, FontStretch);
            _renderer.ReCalculateRenderCellBounds();
            _renderer.SwitchRowRenderEngine(); //Typeface以及FontSize改变时要切换渲染引擎
        }
    }

    /// <summary>
    ///     渲染字体
    /// </summary>
    public FontFamily FontFamily
    {
        get => GetValue(FontFamilyProperty);
        set
        {
            if (GetValue(FontFamilyProperty).Equals(value)) return;

            SetValue(FontFamilyProperty, value);
            _renderer.Typeface = new Typeface(FontFamily, FontStyle, FontWeight, FontStretch);
            _renderer.ReCalculateRenderCellBounds();
            _renderer.SwitchRowRenderEngine(); //Typeface以及FontSize改变时要切换渲染引擎
        }
    }

    #endregion
}