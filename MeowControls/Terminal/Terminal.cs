using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using MeowControls.Terminal.Core;
using MeowControls.Terminal.Options;

namespace MeowControls.Terminal;

/*
                   _ooOoo_
                  o8888888o
                  88" . "88
                  (| -_- |)
                  O\  =  /O
               ____/`---'\____
             .'  \\|     |//  `.
            /  \\|||  :  |||//  \
           /  _||||| -:- |||||-  \
           |   | \\\  -  /// |   |
           | \_|  ''\---/''  |   |
           \  .-\__  `-`  ___/-. /
         ___`. .'  /--.--\  `. . __
      ."" '<  `.___\_<|>_/___.'  >'"".
     | | :  `- \`.;`\ _ /`;.`/ - ` : | |
     \  \ `-.   \_ __\ /__ _/   .-` /  /
======`-.____`-.___\_____/___.-`____.-'======
                   `=---='
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            佛祖保佑       永无BUG
       Hope Buddha Wish You (& Your Code)
*/

//
// 警告
// 如果你看不懂某些地方为什么要这么做一件“看似无意义”或者“多此一举”的事。那么你最好不要改。
//
public class Terminal : Control
{
    //核心组件。这个Terminal类只是个壳。把一些UI层面的事转发到TerminalCore上
    private readonly TerminalCore _core;

    //这个TerminalOptions储存了上面所有Property的值。引入该对象是因为我不想在TerminalCore里也写一堆Property，这太不优雅了
    //TerminalOptions还提供了诸多方法，比如OnXXXPropertyChanged，等方法，用来提供setter之类的
    private readonly TerminalOptions _options;

    public Terminal()
    {
        _options = new TerminalOptions();
        _core = new TerminalCore(_options);
    }

    public override void Render(DrawingContext context)
    {
        //只能在Render里拿Bounds
        _options.Bounds = Bounds;

        //调用渲染器渲染此控件
        _core.Components.Renderer.Render(context);

        base.Render(context);
    }

    //在OnAttachedToVisualTree中，所有我们需要的属性，除了Bounds，都已被确定。在此时初始化TerminalOptions
    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);

        _options.MaxHistoryRows = MaxHistoryRows;
        _options.FontFamily = FontFamily;
        _options.FontStyle = FontStyle;
        _options.FontWeight = FontWeight;
        _options.FontStretch = FontStretch;
        _options.FontSize = FontSize;
        _options.DefaultForeground = DefaultForeground;
        _options.DefaultBackground = DefaultBackground;
        _options.SelectedForeground = SelectedForeground;
        _options.SelectedBackground = SelectedBackground;
        _options.BackgroundImage = BackgroundImage;
        _options.BackgroundImgAlignment = BackgroundImgAlignment;
        _options.LeftPadding = LeftPadding;
        _options.TopPadding = TopPadding;
        _options.AutoLineWrap = AutoLineWrap;
        _options.CursorShape = CursorShape;
        _options.BackgroundImgOpacity = BackgroundImgOpacity;
        _options.EmphasizeTextStyle = EmphasizeTextStyle;
        _options.ForbidTitleChange = ForbidTitleChange;
        _options.AllowDECRQCRA = AllowDECRQCRA;
        _options.AllowOSC52ToClipboard = AllowOSC52ToClipboard;
        _options.ENQResponse = ENQResponse;
        _options.ScrollToInput = ScrollToInput;
        _options.BellNotificationBehavior = BellNotificationBehavior;
        _options.BellNotificationCustomBehavior = BellNotificationCustomBehavior;
        _options.ShowFlyoutAtRightClick = ShowFlyoutAtRightClick;
        _options.CustomFlyoutAtRightClick = CustomFlyoutAtRightClick;
        _options.ShowMarkOnScrollBar = ShowMarkOnScrollBar;
        _options.UseSearch = UseSearch;
    }

    #region Property 不要乱动里面的Setter。尤其是你看不懂为什么要这么做的时候

    public static readonly StyledProperty<int> MaxHistoryRowsProperty = AvaloniaProperty.Register<Terminal, int>(
        nameof(MaxHistoryRows), 9999);

    public static readonly StyledProperty<FontFamily> FontFamilyProperty =
        AvaloniaProperty.Register<Terminal, FontFamily>(
            nameof(FontFamily), FontFamily.Default);

    public static readonly StyledProperty<FontStyle> FontStyleProperty = AvaloniaProperty.Register<Terminal, FontStyle>(
        nameof(FontStyle));

    public static readonly StyledProperty<FontWeight> FontWeightProperty =
        AvaloniaProperty.Register<Terminal, FontWeight>(
            nameof(FontWeight), FontWeight.Normal);

    public static readonly StyledProperty<FontStretch> FontStretchProperty =
        AvaloniaProperty.Register<Terminal, FontStretch>(
            nameof(FontStretch), FontStretch.Normal);

    public static readonly StyledProperty<double> FontSizeProperty = AvaloniaProperty.Register<Terminal, double>(
        nameof(FontSize), 12.0);

    public static readonly StyledProperty<IBrush> DefaultForegroundProperty =
        AvaloniaProperty.Register<Terminal, IBrush>(
            nameof(DefaultForeground), Brushes.Black);

    public static readonly StyledProperty<IBrush> DefaultBackgroundProperty =
        AvaloniaProperty.Register<Terminal, IBrush>(
            nameof(DefaultBackground), Brushes.Transparent);

    public static readonly StyledProperty<IBrush> SelectedForegroundProperty =
        AvaloniaProperty.Register<Terminal, IBrush>(
            nameof(SelectedForeground), Brushes.Black);

    public static readonly StyledProperty<IBrush> SelectedBackgroundProperty =
        AvaloniaProperty.Register<Terminal, IBrush>(
            nameof(SelectedBackground), Brushes.SkyBlue);

    public static readonly StyledProperty<IImage?> BackgroundImageProperty =
        AvaloniaProperty.Register<Terminal, IImage?>(
            nameof(BackgroundImage));

    public static readonly StyledProperty<ImageAlignment> BackgroundImgAlignmentProperty =
        AvaloniaProperty.Register<Terminal, ImageAlignment>(
            nameof(BackgroundImgAlignment));

    public static readonly StyledProperty<double> LeftPaddingProperty = AvaloniaProperty.Register<Terminal, double>(
        nameof(LeftPadding), 5.0);

    public static readonly StyledProperty<double> TopPaddingProperty = AvaloniaProperty.Register<Terminal, double>(
        nameof(TopPadding), 5.0);

    public static readonly StyledProperty<bool> AutoLineWrapProperty = AvaloniaProperty.Register<Terminal, bool>(
        nameof(AutoLineWrap), true);

    public static readonly StyledProperty<CursorShape> CursorShapeProperty =
        AvaloniaProperty.Register<Terminal, CursorShape>(
            nameof(CursorShape));

    public static readonly StyledProperty<double> BackgroundImgOpacityProperty =
        AvaloniaProperty.Register<Terminal, double>(
            nameof(BackgroundImgOpacity), 1.0);

    public static readonly StyledProperty<EmphasizeTextStyle> EmphasizeTextStyleProperty =
        AvaloniaProperty.Register<Terminal, EmphasizeTextStyle>(
            nameof(EmphasizeTextStyle), EmphasizeTextStyle.BOLD);

    public static readonly StyledProperty<bool> ForbidTitleChangeProperty = AvaloniaProperty.Register<Terminal, bool>(
        nameof(ForbidTitleChange));

    public static readonly StyledProperty<bool> AllowDECRQCRAProperty = AvaloniaProperty.Register<Terminal, bool>(
        nameof(AllowDECRQCRA));

    public static readonly StyledProperty<bool> AllowOSC52ToClipboardProperty =
        AvaloniaProperty.Register<Terminal, bool>(
            nameof(AllowOSC52ToClipboard));

    public static readonly StyledProperty<string?> ENQResponseProperty = AvaloniaProperty.Register<Terminal, string?>(
        nameof(ENQResponse));

    public static readonly StyledProperty<bool> ScrollToInputProperty = AvaloniaProperty.Register<Terminal, bool>(
        nameof(ScrollToInput), true);

    public static readonly StyledProperty<BellNotificationBehavior> BellNotificationBehaviorProperty =
        AvaloniaProperty.Register<Terminal, BellNotificationBehavior>(
            nameof(BellNotificationBehavior), BellNotificationBehavior.NONE);

    public static readonly StyledProperty<IBellNotificationCustomBehavior?> BellNotificationCustomBehaviorProperty =
        AvaloniaProperty.Register<Terminal, IBellNotificationCustomBehavior?>(
            nameof(BellNotificationCustomBehavior));

    public static readonly StyledProperty<bool> ShowFlyoutAtRightClickProperty =
        AvaloniaProperty.Register<Terminal, bool>(
            nameof(ShowFlyoutAtRightClick));

    public static readonly StyledProperty<Flyout?> CustomFlyoutAtRightClickProperty =
        AvaloniaProperty.Register<Terminal, Flyout?>(
            nameof(CustomFlyoutAtRightClick));

    public static readonly StyledProperty<bool> ShowMarkOnScrollBarProperty = AvaloniaProperty.Register<Terminal, bool>(
        nameof(ShowMarkOnScrollBar));

    public static readonly StyledProperty<bool> UseSearchProperty = AvaloniaProperty.Register<Terminal, bool>(
        nameof(UseSearch));

    /// <summary>
    ///     启用搜索功能。默认值 true
    /// </summary>
    public bool UseSearch
    {
        get => GetValue(UseSearchProperty);
        set
        {
            //这里之所以要先对_options进行赋值，然后再给property赋值_options的值，是因为options里带有对赋值的值检查。对options赋值，其值不一定会改变
            //为了避免在此处重新写一遍赋值检查，所以SetValue时使用的是options的值。
            _options.UseSearch = value;
            SetValue(UseSearchProperty, _options.UseSearch);
        }
    }

    /// <summary>
    ///     启用后，终端将在使用文本搜索时，在滚动条位置显示标记。默认值 false
    /// </summary>
    public bool ShowMarkOnScrollBar
    {
        get => GetValue(ShowMarkOnScrollBarProperty);
        set
        {
            _options.ShowMarkOnScrollBar = value;
            SetValue(ShowMarkOnScrollBarProperty, _options.ShowMarkOnScrollBar);
        }
    }

    /// <summary>
    ///     用户右键显示的 Flyout 菜单。该值仅当 ShowFlyoutAtRightClick = true 时被使用。若该值为null，则使用默认菜单。<br />
    ///     默认值 null
    /// </summary>
    public Flyout? CustomFlyoutAtRightClick
    {
        get => GetValue(CustomFlyoutAtRightClickProperty);
        set
        {
            _options.CustomFlyoutAtRightClick = value;
            SetValue(CustomFlyoutAtRightClickProperty, _options.CustomFlyoutAtRightClick);
        }
    }

    /// <summary>
    ///     是否在右键时显示 Flyout 菜单。启用后，用户右键将显示 Flyout 菜单，如果 CustomFlyoutAtRightClick = null，则显示默认菜单。
    ///     默认包括 Copy，Cut和 Paste 三个简单的选项。支持中文和英文（根据 CultureInfo.CurrentCulture 自动切换）。 <br />
    ///     未启用时，用户右键将复制选择的文本（如果有的话）至剪贴板。<br />
    ///     默认值 false
    /// </summary>
    public bool ShowFlyoutAtRightClick
    {
        get => GetValue(ShowFlyoutAtRightClickProperty);
        set
        {
            _options.ShowFlyoutAtRightClick = value;
            SetValue(ShowFlyoutAtRightClickProperty, _options.ShowFlyoutAtRightClick);
        }
    }

    /// <summary>
    ///     IBellNotificationCustomBehavior接口的对象。该接口声明了一个 Notify 方法。
    ///     当收到 BEL 控制序列，且使用 BellNotificationBehavior.Customize 时，将调用此对象的 Notify 方法。
    ///     Notify 方法不会在 UI 线程上调用，而是异步调用。您可以选择播放一个音频，收到 BEL 序列时就毕~一声。
    ///     或者选择闪烁任务栏图标，等等。<br />
    ///     默认值 null
    /// </summary>
    public IBellNotificationCustomBehavior? BellNotificationCustomBehavior
    {
        get => GetValue(BellNotificationCustomBehaviorProperty);
        set
        {
            _options.BellNotificationCustomBehavior = value;
            SetValue(BellNotificationCustomBehaviorProperty, _options.BellNotificationCustomBehavior);
        }
    }

    /// <summary>
    ///     当应用程序发出 BEL 控制序列时执行的操作。默认值 BellNotificationBehavior.NONE，即 无。
    /// </summary>
    public BellNotificationBehavior BellNotificationBehavior
    {
        get => GetValue(BellNotificationBehaviorProperty);
        set
        {
            _options.BellNotificationBehavior = value;
            SetValue(BellNotificationBehaviorProperty, _options.BellNotificationBehavior);
        }
    }

    /// <summary>
    ///     当在控制台输入新内容时，自动将窗口滚动到正在输入内容的区域。默认值 true
    /// </summary>
    public bool ScrollToInput
    {
        get => GetValue(ScrollToInputProperty);
        set
        {
            _options.ScrollToInput = value;
            SetValue(ScrollToInputProperty, _options.ScrollToInput);
        }
    }

    /// <summary>
    ///     收到 ENQ 控制序列时的响应内容。有关 ENQ 控制序列，参见 https://vt100.net/docs/vt102-ug/chapter5.html，转到 Control Characters ->
    ///     Table 5-2 Control Characters Recognized by VT102。<br />
    ///     默认值 null
    /// </summary>
    public string? ENQResponse
    {
        get => GetValue(ENQResponseProperty);
        set
        {
            _options.ENQResponse = value;
            SetValue(ENQResponseProperty, _options.ENQResponse);
        }
    }

    /// <summary>
    ///     是否允许 OSC 52 写入剪贴板。OSC 52 是一个转义序列(\e]52)，其能够让终端与剪切板交互。使得终端上的程序能够操控机器的剪切板。
    ///     通常情况下，终端软件（譬如 Windows Terminal）都会禁用该控制序列。对于本控件来说也不例外。<br />
    ///     当该值为false，即禁用 OSC 52 控制序列时，该Terminal将会把收到的 OSC 52 序列抛弃。不处理，不响应，不提示。<br />
    ///     默认值 false
    /// </summary>
    public bool AllowOSC52ToClipboard
    {
        get => GetValue(AllowOSC52ToClipboardProperty);
        set
        {
            _options.AllowOSC52ToClipboard = value;
            SetValue(AllowOSC52ToClipboardProperty, _options.AllowOSC52ToClipboard);
        }
    }

    /// <summary>
    ///     是否允许 DECRQCRA。关于 DECRQCRA，参见 https://vt100.net/docs/vt510-rm/DECRQCRA.html <br />
    ///     默认值 false
    /// </summary>
    public bool AllowDECRQCRA
    {
        get => GetValue(AllowDECRQCRAProperty);
        set
        {
            _options.AllowDECRQCRA = value;
            SetValue(AllowDECRQCRAProperty, _options.AllowDECRQCRA);
        }
    }

    /// <summary>
    ///     禁止更改控件标题。默认值 false
    /// </summary>
    public bool ForbidTitleChange
    {
        get => GetValue(ForbidTitleChangeProperty);
        set
        {
            _options.ForbidTitleChange = value;
            SetValue(ForbidTitleChangeProperty, _options.ForbidTitleChange);
        }
    }

    /// <summary>
    ///     强调文本样式。默认值 EmphasizeTextStyle.BOLD，即 加粗。
    /// </summary>
    public EmphasizeTextStyle EmphasizeTextStyle
    {
        get => GetValue(EmphasizeTextStyleProperty);
        set
        {
            _options.EmphasizeTextStyle = value;
            SetValue(EmphasizeTextStyleProperty, _options.EmphasizeTextStyle);
        }
    }

    /// <summary>
    ///     背景图像不透明度。double值。0.0 代表 0%，0.57 代表 57%，1.0代表100%，以此类推。当尝试赋值小于0或者大于1的数时，
    ///     将抛出 InvalidDataException。<br />
    ///     默认值 1.0
    /// </summary>
    public double BackgroundImgOpacity
    {
        get => GetValue(BackgroundImgOpacityProperty);
        set
        {
            if (value is < 0 or > 1)
                throw new InvalidDataException("BackgroundImgOpacity CANNOT bigger than 1 or less than 0! Meow");
            _options.BackgroundImgOpacity = value;
            SetValue(BackgroundImgOpacityProperty, _options.BackgroundImgOpacity);
        }
    }

    /// <summary>
    ///     光标形状。默认值 CursorShape.BAR，即 条形。
    /// </summary>
    public CursorShape CursorShape
    {
        get => GetValue(CursorShapeProperty);
        set
        {
            _options.CursorShape = value;
            SetValue(CursorShapeProperty, _options.CursorShape);
        }
    }

    /// <summary>
    ///     是否自动换行。默认值 true
    /// </summary>
    public bool AutoLineWrap
    {
        get => GetValue(AutoLineWrapProperty);
        set
        {
            _options.AutoLineWrap = value;
            SetValue(AutoLineWrapProperty, _options.AutoLineWrap);
        }
    }

    /// <summary>
    ///     顶部的Padding。该值决定了终端文本渲染起始区域的Y坐标。<br />
    ///     默认值 5.0
    /// </summary>
    public double TopPadding
    {
        get => GetValue(TopPaddingProperty);
        set
        {
            _options.TopPadding = value;
            SetValue(TopPaddingProperty, _options.TopPadding);
        }
    }

    /// <summary>
    ///     左侧的Padding。该值决定了终端文本渲染起始区域的X坐标。之所以把该参数独立出来而不是用个统一的Padding是因为受Terminal渲染机制的影响，
    ///     右边的Padding是在控件大小改变时实时计算的。其结果不会超过一个字符宽。如果你需要Padding，请考虑套一个Border。<br />
    ///     默认值 5.0
    /// </summary>
    public double LeftPadding
    {
        get => GetValue(LeftPaddingProperty);
        set
        {
            _options.LeftPadding = value;
            SetValue(LeftPaddingProperty, _options.LeftPadding);
        }
    }

    /// <summary>
    ///     背景图像对齐方式。默认值 Image.Alignment.COVER，即 覆盖。
    /// </summary>
    public ImageAlignment BackgroundImgAlignment
    {
        get => GetValue(BackgroundImgAlignmentProperty);
        set
        {
            _options.BackgroundImgAlignment = value;
            SetValue(BackgroundImgAlignmentProperty, _options.BackgroundImgAlignment);
        }
    }

    /// <summary>
    ///     背景图片。默认值 null
    /// </summary>
    public IImage? BackgroundImage
    {
        get => GetValue(BackgroundImageProperty);
        set
        {
            _options.BackgroundImage = value;
            SetValue(BackgroundImageProperty, _options.BackgroundImage);
        }
    }

    /// <summary>
    ///     选中字符的背景色。默认值 Brushes.SkyBlue
    /// </summary>
    public IBrush SelectedBackground
    {
        get => GetValue(SelectedBackgroundProperty);
        set
        {
            _options.SelectedBackground = value;
            SetValue(SelectedBackgroundProperty, _options.SelectedBackground);
        }
    }

    /// <summary>
    ///     选中字符的前景色。默认值 Brushes.Black
    /// </summary>
    public IBrush SelectedForeground
    {
        get => GetValue(SelectedForegroundProperty);
        set
        {
            _options.SelectedForeground = value;
            SetValue(SelectedForegroundProperty, _options.SelectedForeground);
        }
    }

    /// <summary>
    ///     默认字体背景色。默认值 Brushes.Transparent
    /// </summary>
    public IBrush DefaultBackground
    {
        get => GetValue(DefaultBackgroundProperty);
        set
        {
            _options.DefaultBackground = value;
            SetValue(DefaultBackgroundProperty, _options.DefaultBackground);
        }
    }

    /// <summary>
    ///     默认字体前景色。默认值 Brushes.Black 黑色
    /// </summary>
    public IBrush DefaultForeground
    {
        get => GetValue(DefaultForegroundProperty);
        set
        {
            _options.DefaultForeground = value;
            SetValue(DefaultForegroundProperty, _options.DefaultForeground);
        }
    }

    /// <summary>
    ///     FontSize (em size)。默认值 12.0
    /// </summary>
    public double FontSize
    {
        get => GetValue(FontSizeProperty);
        set
        {
            _options.FontSize = value;
            SetValue(FontSizeProperty, _options.FontSize);
        }
    }

    /// <summary>
    ///     FontStretch。默认值 FontStretch.Normal
    /// </summary>
    public FontStretch FontStretch
    {
        get => GetValue(FontStretchProperty);
        set
        {
            _options.FontStretch = value;
            SetValue(FontStretchProperty, _options.FontStretch);
        }
    }

    /// <summary>
    ///     FontWeight。默认值 FontWeight.Normal
    /// </summary>
    public FontWeight FontWeight
    {
        get => GetValue(FontWeightProperty);
        set
        {
            _options.FontWeight = value;
            SetValue(FontWeightProperty, _options.FontWeight);
        }
    }

    /// <summary>
    ///     FontStyle。默认值 FontStyle.Normal
    /// </summary>
    public FontStyle FontStyle
    {
        get => GetValue(FontStyleProperty);
        set
        {
            _options.FontStyle = value;
            SetValue(FontStyleProperty, _options.FontStyle);
        }
    }

    /// <summary>
    ///     FontFamily。默认值 FontFamily.Default
    /// </summary>
    public FontFamily FontFamily
    {
        get => GetValue(FontFamilyProperty);
        set
        {
            _options.FontFamily = value;
            SetValue(FontFamilyProperty, _options.FontFamily);
        }
    }

    /// <summary>
    ///     最大能保存的历史行数。int类型。可用最大值int.MaxValue。可用最小值 1。当传参小于1时，将抛出InvalidDataException。<br />
    ///     默认值 9999
    /// </summary>
    public int MaxHistoryRows
    {
        get => GetValue(MaxHistoryRowsProperty);
        set
        {
            if (value < 1) throw new InvalidDataException("MaxHistoryRows CANNOT less than 1.");
            _options.MaxHistoryRows = value;
            SetValue(MaxHistoryRowsProperty, _options.MaxHistoryRows);
        }
    }

    #endregion
}