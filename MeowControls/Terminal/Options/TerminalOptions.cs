using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace MeowControls.Terminal.Options;

public class TerminalOptions
{
    private bool _allowDECRQCRA;
    private IPropertyChangeHandler<bool>? _allowDECRQCRAChangeHandler;

    private bool _allowOSC52ToClipboard;
    private IPropertyChangeHandler<bool>? _allowOSC52ToClipboardChangeHandler;

    private bool _autoLineWrap = true;
    private IPropertyChangeHandler<bool>? _autoLineWrapChangeHandler;

    private IImage? _backgroundImage;
    private IPropertyChangeHandler<IImage?>? _backgroundImageChangeHandler;

    private ImageAlignment _backgroundImgAlignment = ImageAlignment.COVER;
    private IPropertyChangeHandler<ImageAlignment>? _backgroundImgAlignmentChangeHandler;

    private double _backgroundImgOpacity = 1.0;
    private IPropertyChangeHandler<double>? _backgroundImgOpacityChangeHandler;

    private BellNotificationBehavior _bellNotificationBehavior;
    private IPropertyChangeHandler<BellNotificationBehavior>? _bellNotificationBehaviorChangeHandler;

    private IBellNotificationCustomBehavior? _bellNotificationCustomBehavior;
    private IPropertyChangeHandler<IBellNotificationCustomBehavior?>? _bellNotificationCustomBehaviorChangeHandler;
    private Rect _bounds;
    private IPropertyChangeHandler<Rect>? _boundsChangeHandler;

    private CursorShape _cursorShape = CursorShape.BAR;
    private IPropertyChangeHandler<CursorShape>? _cursorShapeChangeHandler;

    private Flyout? _customFlyoutAtRightClick;
    private IPropertyChangeHandler<Flyout?>? _customFlyoutAtRightClickChangeHandler;

    private IBrush _defaultBackground = Brushes.Transparent;
    private IPropertyChangeHandler<IBrush>? _defaultBackgroundChangeHandler;

    private IBrush _defaultForeground = Brushes.Black;
    private IPropertyChangeHandler<IBrush>? _defaultForegroundChangeHandler;

    private EmphasizeTextStyle _emphasizeTextStyle = EmphasizeTextStyle.HIGHLIGHT;
    private IPropertyChangeHandler<EmphasizeTextStyle>? _emphasizeTextStyleChangeHandler;

    private string? _enqResponse;
    private IPropertyChangeHandler<string?>? _enqResponseChangeHandler;

    private FontFamily _fontFamily = FontFamily.Default;
    private IPropertyChangeHandler<FontFamily>? _fontFamilyChangeHandler;

    private double _fontSize = 12.0;
    private IPropertyChangeHandler<double>? _fontSizeChangeHandler;

    private FontStretch _fontStretch = FontStretch.Normal;
    private IPropertyChangeHandler<FontStretch>? _fontStretchChangeHandler;

    private FontStyle _fontStyle = FontStyle.Normal;
    private IPropertyChangeHandler<FontStyle>? _fontStyleChangeHandler;

    private FontWeight _fontWeight = FontWeight.Normal;
    private IPropertyChangeHandler<FontWeight>? _fontWeightChangeHandler;

    private bool _forbidTitleChange;
    private IPropertyChangeHandler<bool>? _forbidTitleChangeChangeHandler;

    private double _leftPadding = 5.0;
    private IPropertyChangeHandler<double>? _leftPaddingChangeHandler;

    private int _maxHistoryRows = 9999;
    private IPropertyChangeHandler<int>? _maxHistoryRowsChangeHandler;

    private bool _scrollToInput = true;
    private IPropertyChangeHandler<bool>? _scrollToInputChangeHandler;

    private IBrush _selectedBackground = Brushes.SkyBlue;
    private IPropertyChangeHandler<IBrush>? _selectedBackgroundChangeHandler;

    private IBrush _selectedForeground = Brushes.Black;
    private IPropertyChangeHandler<IBrush>? _selectedForegroundChangeHandler;

    private bool _showFlyoutAtRightClick;
    private IPropertyChangeHandler<bool>? _showFlyoutAtRightClickChangeHandler;

    private bool _showMarkOnScrollBar;
    private IPropertyChangeHandler<bool>? _showMarkOnScrollBarChangeHandler;

    private double _topPadding = 5.0;
    private IPropertyChangeHandler<double>? _topPaddingChangeHandler;

    private bool _useSearch;
    private IPropertyChangeHandler<bool>? _useSearchChangeHandler;

    public Rect Bounds
    {
        get => _bounds;
        set
        {
            if (Equals(value, _bounds)) return;

            if (_boundsChangeHandler?.Handle(value) is null or true) _bounds = value;
        }
    }

    public int MaxHistoryRows
    {
        get => _maxHistoryRows;
        set
        {
            if (Equals(value, _maxHistoryRows)) return;

            if (_maxHistoryRowsChangeHandler?.Handle(value) is null or true) _maxHistoryRows = value;
        }
    }

    public FontFamily FontFamily
    {
        get => _fontFamily;
        set
        {
            if (Equals(value, _fontFamily)) return;

            if (_fontFamilyChangeHandler?.Handle(value) is null or true) _fontFamily = value;
        }
    }

    public FontStyle FontStyle
    {
        get => _fontStyle;
        set
        {
            if (Equals(value, _fontStyle)) return;

            if (_fontStyleChangeHandler?.Handle(value) is null or true) _fontStyle = value;
        }
    }

    public FontWeight FontWeight
    {
        get => _fontWeight;
        set
        {
            if (Equals(value, _fontWeight)) return;

            if (_fontWeightChangeHandler?.Handle(value) is null or true) _fontWeight = value;
        }
    }

    public FontStretch FontStretch
    {
        get => _fontStretch;
        set
        {
            if (Equals(value, _fontStretch)) return;

            if (_fontStretchChangeHandler?.Handle(value) is null or true) _fontStretch = value;
        }
    }

    public double FontSize
    {
        get => _fontSize;
        set
        {
            if (Equals(value, _fontSize)) return;

            if (_fontSizeChangeHandler?.Handle(value) is null or true) _fontSize = value;
        }
    }

    public IBrush DefaultForeground
    {
        get => _defaultForeground;
        set
        {
            if (Equals(value, _defaultForeground)) return;

            if (_defaultForegroundChangeHandler?.Handle(value) is null or true) _defaultForeground = value;
        }
    }

    public IBrush DefaultBackground
    {
        get => _defaultBackground;
        set
        {
            if (Equals(value, _defaultBackground)) return;

            if (_defaultBackgroundChangeHandler?.Handle(value) is null or true) _defaultBackground = value;
        }
    }

    public IBrush SelectedForeground
    {
        get => _selectedForeground;
        set
        {
            if (Equals(value, _selectedForeground)) return;

            if (_selectedForegroundChangeHandler?.Handle(value) is null or true) _selectedForeground = value;
        }
    }

    public IBrush SelectedBackground
    {
        get => _selectedBackground;
        set
        {
            if (Equals(value, _selectedBackground)) return;

            if (_selectedBackgroundChangeHandler?.Handle(value) is null or true) _selectedBackground = value;
        }
    }

    public IImage? BackgroundImage
    {
        get => _backgroundImage;
        set
        {
            if (Equals(value, _backgroundImage)) return;

            if (_backgroundImageChangeHandler?.Handle(value) is null or true) _backgroundImage = value;
        }
    }

    public ImageAlignment BackgroundImgAlignment
    {
        get => _backgroundImgAlignment;
        set
        {
            if (Equals(value, _backgroundImgAlignment)) return;

            if (_backgroundImgAlignmentChangeHandler?.Handle(value) is null or true) _backgroundImgAlignment = value;
        }
    }

    public double LeftPadding
    {
        get => _leftPadding;
        set
        {
            if (Equals(value, _leftPadding)) return;

            if (_leftPaddingChangeHandler?.Handle(value) is null or true) _leftPadding = value;
        }
    }

    public double TopPadding
    {
        get => _topPadding;
        set
        {
            if (Equals(value, _topPadding)) return;

            if (_topPaddingChangeHandler?.Handle(value) is null or true) _topPadding = value;
        }
    }

    public bool AutoLineWrap
    {
        get => _autoLineWrap;
        set
        {
            if (Equals(value, _autoLineWrap)) return;

            if (_autoLineWrapChangeHandler?.Handle(value) is null or true) _autoLineWrap = value;
        }
    }

    public CursorShape CursorShape
    {
        get => _cursorShape;
        set
        {
            if (Equals(value, _cursorShape)) return;

            if (_cursorShapeChangeHandler?.Handle(value) is null or true) _cursorShape = value;
        }
    }

    public double BackgroundImgOpacity
    {
        get => _backgroundImgOpacity;
        set
        {
            if (Equals(value, _backgroundImgOpacity)) return;

            if (_backgroundImgOpacityChangeHandler?.Handle(value) is null or true) _backgroundImgOpacity = value;
        }
    }

    public EmphasizeTextStyle EmphasizeTextStyle
    {
        get => _emphasizeTextStyle;
        set
        {
            if (Equals(value, _emphasizeTextStyle)) return;

            if (_emphasizeTextStyleChangeHandler?.Handle(value) is null or true) _emphasizeTextStyle = value;
        }
    }

    public bool ForbidTitleChange
    {
        get => _forbidTitleChange;
        set
        {
            if (Equals(value, _forbidTitleChange)) return;

            if (_forbidTitleChangeChangeHandler?.Handle(value) is null or true) _forbidTitleChange = value;
        }
    }

    public bool AllowDECRQCRA
    {
        get => _allowDECRQCRA;
        set
        {
            if (Equals(value, _allowDECRQCRA)) return;

            if (_allowDECRQCRAChangeHandler?.Handle(value) is null or true) _allowDECRQCRA = value;
        }
    }

    public bool AllowOSC52ToClipboard
    {
        get => _allowOSC52ToClipboard;
        set
        {
            if (Equals(value, _allowOSC52ToClipboard)) return;

            if (_allowOSC52ToClipboardChangeHandler?.Handle(value) is null or true) _allowOSC52ToClipboard = value;
        }
    }

    public string? ENQResponse
    {
        get => _enqResponse;
        set
        {
            if (Equals(value, _enqResponse)) return;

            if (_enqResponseChangeHandler?.Handle(value) is null or true) _enqResponse = value;
        }
    }

    public bool ScrollToInput
    {
        get => _scrollToInput;
        set
        {
            if (Equals(value, _scrollToInput)) return;

            if (_scrollToInputChangeHandler?.Handle(value) is null or true) _scrollToInput = value;
        }
    }

    public BellNotificationBehavior BellNotificationBehavior
    {
        get => _bellNotificationBehavior;
        set
        {
            if (Equals(value, _bellNotificationBehavior)) return;

            if (_bellNotificationBehaviorChangeHandler?.Handle(value) is null or true)
                _bellNotificationBehavior = value;
        }
    }

    public IBellNotificationCustomBehavior? BellNotificationCustomBehavior
    {
        get => _bellNotificationCustomBehavior;
        set
        {
            if (Equals(value, _bellNotificationCustomBehavior)) return;

            if (_bellNotificationCustomBehaviorChangeHandler?.Handle(value) is null or true)
                _bellNotificationCustomBehavior = value;
        }
    }

    public bool ShowFlyoutAtRightClick
    {
        get => _showFlyoutAtRightClick;
        set
        {
            if (Equals(value, _showFlyoutAtRightClick)) return;

            if (_showFlyoutAtRightClickChangeHandler?.Handle(value) is null or true) _showFlyoutAtRightClick = value;
        }
    }

    public Flyout? CustomFlyoutAtRightClick
    {
        get => _customFlyoutAtRightClick;
        set
        {
            if (Equals(value, _customFlyoutAtRightClick)) return;

            if (_customFlyoutAtRightClickChangeHandler?.Handle(value) is null or true)
                _customFlyoutAtRightClick = value;
        }
    }

    public bool ShowMarkOnScrollBar
    {
        get => _showMarkOnScrollBar;
        set
        {
            if (Equals(value, _showMarkOnScrollBar)) return;

            if (_showMarkOnScrollBarChangeHandler?.Handle(value) is null or true) _showMarkOnScrollBar = value;
        }
    }

    public bool UseSearch
    {
        get => _useSearch;
        set
        {
            if (Equals(value, _useSearch)) return;

            if (_useSearchChangeHandler?.Handle(value) is null or true) _useSearch = value;
        }
    }

    public void OnBoundsChanged(IPropertyChangeHandler<Rect> boundsChangeHandler)
    {
        _boundsChangeHandler = boundsChangeHandler;
    }

    public void OnMaxHistoryRowsChanged(IPropertyChangeHandler<int> maxHistoryRowsChangeHandler)
    {
        _maxHistoryRowsChangeHandler = maxHistoryRowsChangeHandler;
    }

    public void OnFontFamilyChanged(IPropertyChangeHandler<FontFamily> fontFamilyChangeHandler)
    {
        _fontFamilyChangeHandler = fontFamilyChangeHandler;
    }

    public void OnFontStyleChanged(IPropertyChangeHandler<FontStyle> fontStyleChangeHandler)
    {
        _fontStyleChangeHandler = fontStyleChangeHandler;
    }

    public void OnFontWeightChanged(IPropertyChangeHandler<FontWeight> fontWeightChangeHandler)
    {
        _fontWeightChangeHandler = fontWeightChangeHandler;
    }

    public void OnFontStretchChanged(IPropertyChangeHandler<FontStretch> fontStretchChangeHandler)
    {
        _fontStretchChangeHandler = fontStretchChangeHandler;
    }

    public void OnFontSizeChanged(IPropertyChangeHandler<double> fontSizeChangeHandler)
    {
        _fontSizeChangeHandler = fontSizeChangeHandler;
    }

    public void OnDefaultForegroundChanged(IPropertyChangeHandler<IBrush> defaultForegroundChangeHandler)
    {
        _defaultForegroundChangeHandler = defaultForegroundChangeHandler;
    }

    public void OnDefaultBackgroundChanged(IPropertyChangeHandler<IBrush> defaultBackgroundChangeHandler)
    {
        _defaultBackgroundChangeHandler = defaultBackgroundChangeHandler;
    }

    public void OnSelectedForegroundChanged(IPropertyChangeHandler<IBrush> selectedForegroundChangeHandler)
    {
        _selectedForegroundChangeHandler = selectedForegroundChangeHandler;
    }

    public void OnSelectedBackgroundChanged(IPropertyChangeHandler<IBrush> selectedBackgroundChangeHandler)
    {
        _selectedBackgroundChangeHandler = selectedBackgroundChangeHandler;
    }

    public void OnBackgroundImageChanged(IPropertyChangeHandler<IImage?> backgroundImageChangeHandler)
    {
        _backgroundImageChangeHandler = backgroundImageChangeHandler;
    }

    public void OnBackgroundImgAlignmentChanged(
        IPropertyChangeHandler<ImageAlignment> backgroundImgAlignmentChangeHandler)
    {
        _backgroundImgAlignmentChangeHandler = backgroundImgAlignmentChangeHandler;
    }

    public void OnLeftPaddingChanged(IPropertyChangeHandler<double> leftPaddingChangeHandler)
    {
        _leftPaddingChangeHandler = leftPaddingChangeHandler;
    }

    public void OnTopPaddingChanged(IPropertyChangeHandler<double> topPaddingChangeHandler)
    {
        _topPaddingChangeHandler = topPaddingChangeHandler;
    }

    public void OnAutoLineWrapChanged(IPropertyChangeHandler<bool> autoLineWrapChangeHandler)
    {
        _autoLineWrapChangeHandler = autoLineWrapChangeHandler;
    }

    public void OnCursorShapeChanged(IPropertyChangeHandler<CursorShape> cursorShapeChangeHandler)
    {
        _cursorShapeChangeHandler = cursorShapeChangeHandler;
    }

    public void OnBackgroundImgOpacityChanged(IPropertyChangeHandler<double> backgroundImgOpacityChangeHandler)
    {
        _backgroundImgOpacityChangeHandler = backgroundImgOpacityChangeHandler;
    }

    public void OnEmphasizeTextStyleChanged(IPropertyChangeHandler<EmphasizeTextStyle> emphasizeTextStyleChangeHandler)
    {
        _emphasizeTextStyleChangeHandler = emphasizeTextStyleChangeHandler;
    }

    public void OnForbidTitleChangeChanged(IPropertyChangeHandler<bool> forbidTitleChangeChangeHandler)
    {
        _forbidTitleChangeChangeHandler = forbidTitleChangeChangeHandler;
    }

    public void OnAllowDECRQCRAChanged(IPropertyChangeHandler<bool> allowDECRQCRAChangeHandler)
    {
        _allowDECRQCRAChangeHandler = allowDECRQCRAChangeHandler;
    }

    public void OnAllowOSC52ToClipboardChanged(IPropertyChangeHandler<bool> allowOSC52ToClipboardChangeHandler)
    {
        _allowOSC52ToClipboardChangeHandler = allowOSC52ToClipboardChangeHandler;
    }

    public void OnENQResponseChanged(IPropertyChangeHandler<string?> enqResponseChangeHandler)
    {
        _enqResponseChangeHandler = enqResponseChangeHandler;
    }

    public void OnScrollToInputChanged(IPropertyChangeHandler<bool> scrollToInputChangeHandler)
    {
        _scrollToInputChangeHandler = scrollToInputChangeHandler;
    }

    public void OnBellNotificationBehaviorChanged(
        IPropertyChangeHandler<BellNotificationBehavior> bellNotificationBehaviorChangeHandler)
    {
        _bellNotificationBehaviorChangeHandler = bellNotificationBehaviorChangeHandler;
    }

    public void OnBellNotificationCustomBehaviorChanged(
        IPropertyChangeHandler<IBellNotificationCustomBehavior?> bellNotificationCustomBehaviorChangeHandler)
    {
        _bellNotificationCustomBehaviorChangeHandler = bellNotificationCustomBehaviorChangeHandler;
    }

    public void OnShowFlyoutAtRightClickChanged(IPropertyChangeHandler<bool> showFlyoutAtRightClickChangeHandler)
    {
        _showFlyoutAtRightClickChangeHandler = showFlyoutAtRightClickChangeHandler;
    }

    public void OnCustomFlyoutAtRightClickChanged(IPropertyChangeHandler<Flyout?> customFlyoutAtRightClickChangeHandler)
    {
        _customFlyoutAtRightClickChangeHandler = customFlyoutAtRightClickChangeHandler;
    }

    public void OnShowMarkOnScrollBarChanged(IPropertyChangeHandler<bool> showMarkOnScrollBarChangeHandler)
    {
        _showMarkOnScrollBarChangeHandler = showMarkOnScrollBarChangeHandler;
    }

    public void OnUseSearchChanged(IPropertyChangeHandler<bool> useSearchChangeHandler)
    {
        _useSearchChangeHandler = useSearchChangeHandler;
    }
}