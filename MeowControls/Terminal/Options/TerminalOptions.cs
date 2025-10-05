using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace MeowControls.Controls.Terminal.Options;

public class TerminalOptions
{
    private Rect _bounds;
    private IPropertyChangeHandler<Rect>? _boundsChangeHandler;

    public Rect Bounds
    {
        get => _bounds;
        set
        {
            if (Equals(value, _bounds))
            {
                return;
            }
            
            if (_boundsChangeHandler?.Handle(value) is null or true)
            {
                _bounds = value;
            }
        }
    }

    public void OnBoundsChanged(IPropertyChangeHandler<Rect> boundsChangeHandler)
    {
        _boundsChangeHandler = boundsChangeHandler;
    }

    private int _maxHistoryRows = 9999;
    private IPropertyChangeHandler<int>? _maxHistoryRowsChangeHandler;

    public int MaxHistoryRows
    {
        get => _maxHistoryRows;
        set
        {
            if (Equals(value, _maxHistoryRows))
            {
                return;
            }
            
            if (_maxHistoryRowsChangeHandler?.Handle(value) is null or true)
            {
                _maxHistoryRows = value;
            }
        }
    }

    public void OnMaxHistoryRowsChanged(IPropertyChangeHandler<int> maxHistoryRowsChangeHandler)
    {
        _maxHistoryRowsChangeHandler = maxHistoryRowsChangeHandler;
    }

    private FontFamily _fontFamily = FontFamily.Default;
    private IPropertyChangeHandler<FontFamily>? _fontFamilyChangeHandler;

    public FontFamily FontFamily
    {
        get => _fontFamily;
        set
        {
            if (Equals(value, _fontFamily))
            {
                return;
            }
            
            if (_fontFamilyChangeHandler?.Handle(value) is null or true)
            {
                _fontFamily = value;
            }
        }
    }

    public void OnFontFamilyChanged(IPropertyChangeHandler<FontFamily> fontFamilyChangeHandler)
    {
        _fontFamilyChangeHandler = fontFamilyChangeHandler;
    }

    private FontStyle _fontStyle = FontStyle.Normal;
    private IPropertyChangeHandler<FontStyle>? _fontStyleChangeHandler;

    public FontStyle FontStyle
    {
        get => _fontStyle;
        set
        {
            if (Equals(value, _fontStyle))
            {
                return;
            }
            
            if (_fontStyleChangeHandler?.Handle(value) is null or true)
            {
                _fontStyle = value;
            }
        }
    }

    public void OnFontStyleChanged(IPropertyChangeHandler<FontStyle> fontStyleChangeHandler)
    {
        _fontStyleChangeHandler = fontStyleChangeHandler;
    }

    private FontWeight _fontWeight = FontWeight.Normal;
    private IPropertyChangeHandler<FontWeight>? _fontWeightChangeHandler;

    public FontWeight FontWeight
    {
        get => _fontWeight;
        set
        {
            if (Equals(value, _fontWeight))
            {
                return;
            }
            
            if (_fontWeightChangeHandler?.Handle(value) is null or true)
            {
                _fontWeight = value;
            }
        }
    }

    public void OnFontWeightChanged(IPropertyChangeHandler<FontWeight> fontWeightChangeHandler)
    {
        _fontWeightChangeHandler = fontWeightChangeHandler;
    }

    private FontStretch _fontStretch = FontStretch.Normal;
    private IPropertyChangeHandler<FontStretch>? _fontStretchChangeHandler;

    public FontStretch FontStretch
    {
        get => _fontStretch;
        set
        {
            if (Equals(value, _fontStretch))
            {
                return;
            }
            
            if (_fontStretchChangeHandler?.Handle(value) is null or true)
            {
                _fontStretch = value;
            }
        }
    }

    public void OnFontStretchChanged(IPropertyChangeHandler<FontStretch> fontStretchChangeHandler)
    {
        _fontStretchChangeHandler = fontStretchChangeHandler;
    }

    private double _fontSize = 12.0;
    private IPropertyChangeHandler<double>? _fontSizeChangeHandler;

    public double FontSize
    {
        get => _fontSize;
        set
        {
            if (Equals(value, _fontSize))
            {
                return;
            }
            
            if (_fontSizeChangeHandler?.Handle(value) is null or true)
            {
                _fontSize = value;
            }
        }
    }

    public void OnFontSizeChanged(IPropertyChangeHandler<double> fontSizeChangeHandler)
    {
        _fontSizeChangeHandler = fontSizeChangeHandler;
    }

    private IBrush _defaultForeground = Brushes.Black;
    private IPropertyChangeHandler<IBrush>? _defaultForegroundChangeHandler;

    public IBrush DefaultForeground
    {
        get => _defaultForeground;
        set
        {
            if (Equals(value, _defaultForeground))
            {
                return;
            }
            
            if (_defaultForegroundChangeHandler?.Handle(value) is null or true)
            {
                _defaultForeground = value;
            }
        }
    }

    public void OnDefaultForegroundChanged(IPropertyChangeHandler<IBrush> defaultForegroundChangeHandler)
    {
        _defaultForegroundChangeHandler = defaultForegroundChangeHandler;
    }

    private IBrush _defaultBackground = Brushes.Transparent;
    private IPropertyChangeHandler<IBrush>? _defaultBackgroundChangeHandler;

    public IBrush DefaultBackground
    {
        get => _defaultBackground;
        set
        {
            if (Equals(value, _defaultBackground))
            {
                return;
            }
            
            if (_defaultBackgroundChangeHandler?.Handle(value) is null or true)
            {
                _defaultBackground = value;
            }
        }
    }

    public void OnDefaultBackgroundChanged(IPropertyChangeHandler<IBrush> defaultBackgroundChangeHandler)
    {
        _defaultBackgroundChangeHandler = defaultBackgroundChangeHandler;
    }

    private IBrush _selectedForeground = Brushes.Black;
    private IPropertyChangeHandler<IBrush>? _selectedForegroundChangeHandler;

    public IBrush SelectedForeground
    {
        get => _selectedForeground;
        set
        {
            if (Equals(value, _selectedForeground))
            {
                return;
            }
            
            if (_selectedForegroundChangeHandler?.Handle(value) is null or true)
            {
                _selectedForeground = value;
            }
        }
    }

    public void OnSelectedForegroundChanged(IPropertyChangeHandler<IBrush> selectedForegroundChangeHandler)
    {
        _selectedForegroundChangeHandler = selectedForegroundChangeHandler;
    }

    private IBrush _selectedBackground = Brushes.SkyBlue;
    private IPropertyChangeHandler<IBrush>? _selectedBackgroundChangeHandler;

    public IBrush SelectedBackground
    {
        get => _selectedBackground;
        set
        {
            if (Equals(value, _selectedBackground))
            {
                return;
            }
            
            if (_selectedBackgroundChangeHandler?.Handle(value) is null or true)
            {
                _selectedBackground = value;
            }
        }
    }

    public void OnSelectedBackgroundChanged(IPropertyChangeHandler<IBrush> selectedBackgroundChangeHandler)
    {
        _selectedBackgroundChangeHandler = selectedBackgroundChangeHandler;
    }

    private IImage? _backgroundImage;
    private IPropertyChangeHandler<IImage?>? _backgroundImageChangeHandler;

    public IImage? BackgroundImage
    {
        get => _backgroundImage;
        set
        {
            if (Equals(value, _backgroundImage))
            {
                return;
            }
            
            if (_backgroundImageChangeHandler?.Handle(value) is null or true)
            {
                _backgroundImage = value;
            }
        }
    }

    public void OnBackgroundImageChanged(IPropertyChangeHandler<IImage?> backgroundImageChangeHandler)
    {
        _backgroundImageChangeHandler = backgroundImageChangeHandler;
    }

    private ImageAlignment _backgroundImgAlignment = ImageAlignment.COVER;
    private IPropertyChangeHandler<ImageAlignment>? _backgroundImgAlignmentChangeHandler;

    public ImageAlignment BackgroundImgAlignment
    {
        get => _backgroundImgAlignment;
        set
        {
            if (Equals(value, _backgroundImgAlignment))
            {
                return;
            }
            
            if (_backgroundImgAlignmentChangeHandler?.Handle(value) is null or true)
            {
                _backgroundImgAlignment = value;
            }
        }
    }

    public void OnBackgroundImgAlignmentChanged(
        IPropertyChangeHandler<ImageAlignment> backgroundImgAlignmentChangeHandler)
    {
        _backgroundImgAlignmentChangeHandler = backgroundImgAlignmentChangeHandler;
    }

    private double _leftPadding = 5.0;
    private IPropertyChangeHandler<double>? _leftPaddingChangeHandler;

    public double LeftPadding
    {
        get => _leftPadding;
        set
        {
            if (Equals(value, _leftPadding))
            {
                return;
            }
            
            if (_leftPaddingChangeHandler?.Handle(value) is null or true)
            {
                _leftPadding = value;
            }
        }
    }

    public void OnLeftPaddingChanged(IPropertyChangeHandler<double> leftPaddingChangeHandler)
    {
        _leftPaddingChangeHandler = leftPaddingChangeHandler;
    }

    private double _topPadding = 5.0;
    private IPropertyChangeHandler<double>? _topPaddingChangeHandler;

    public double TopPadding
    {
        get => _topPadding;
        set
        {
            if (Equals(value, _topPadding))
            {
                return;
            }
            
            if (_topPaddingChangeHandler?.Handle(value) is null or true)
            {
                _topPadding = value;
            }
        }
    }

    public void OnTopPaddingChanged(IPropertyChangeHandler<double> topPaddingChangeHandler)
    {
        _topPaddingChangeHandler = topPaddingChangeHandler;
    }

    private bool _autoLineWrap = true;
    private IPropertyChangeHandler<bool>? _autoLineWrapChangeHandler;

    public bool AutoLineWrap
    {
        get => _autoLineWrap;
        set
        {
            if (Equals(value, _autoLineWrap))
            {
                return;
            }
            
            if (_autoLineWrapChangeHandler?.Handle(value) is null or true)
            {
                _autoLineWrap = value;
            }
        }
    }

    public void OnAutoLineWrapChanged(IPropertyChangeHandler<bool> autoLineWrapChangeHandler)
    {
        _autoLineWrapChangeHandler = autoLineWrapChangeHandler;
    }

    private CursorShape _cursorShape = CursorShape.BAR;
    private IPropertyChangeHandler<CursorShape>? _cursorShapeChangeHandler;

    public CursorShape CursorShape
    {
        get => _cursorShape;
        set
        {
            if (Equals(value, _cursorShape))
            {
                return;
            }
            
            if (_cursorShapeChangeHandler?.Handle(value) is null or true)
            {
                _cursorShape = value;
            }
        }
    }

    public void OnCursorShapeChanged(IPropertyChangeHandler<CursorShape> cursorShapeChangeHandler)
    {
        _cursorShapeChangeHandler = cursorShapeChangeHandler;
    }

    private double _backgroundImgOpacity = 1.0;
    private IPropertyChangeHandler<double>? _backgroundImgOpacityChangeHandler;

    public double BackgroundImgOpacity
    {
        get => _backgroundImgOpacity;
        set
        {
            if (Equals(value, _backgroundImgOpacity))
            {
                return;
            }
            
            if (_backgroundImgOpacityChangeHandler?.Handle(value) is null or true)
            {
                _backgroundImgOpacity = value;
            }
        }
    }

    public void OnBackgroundImgOpacityChanged(IPropertyChangeHandler<double> backgroundImgOpacityChangeHandler)
    {
        _backgroundImgOpacityChangeHandler = backgroundImgOpacityChangeHandler;
    }

    private EmphasizeTextStyle _emphasizeTextStyle = EmphasizeTextStyle.HIGHLIGHT;
    private IPropertyChangeHandler<EmphasizeTextStyle>? _emphasizeTextStyleChangeHandler;

    public EmphasizeTextStyle EmphasizeTextStyle
    {
        get => _emphasizeTextStyle;
        set
        {
            if (Equals(value, _emphasizeTextStyle))
            {
                return;
            }
            
            if (_emphasizeTextStyleChangeHandler?.Handle(value) is null or true)
            {
                _emphasizeTextStyle = value;
            }
        }
    }

    public void OnEmphasizeTextStyleChanged(IPropertyChangeHandler<EmphasizeTextStyle> emphasizeTextStyleChangeHandler)
    {
        _emphasizeTextStyleChangeHandler = emphasizeTextStyleChangeHandler;
    }

    private bool _forbidTitleChange;
    private IPropertyChangeHandler<bool>? _forbidTitleChangeChangeHandler;

    public bool ForbidTitleChange
    {
        get => _forbidTitleChange;
        set
        {
            if (Equals(value, _forbidTitleChange))
            {
                return;
            }
            
            if (_forbidTitleChangeChangeHandler?.Handle(value) is null or true)
            {
                _forbidTitleChange = value;
            }
        }
    }

    public void OnForbidTitleChangeChanged(IPropertyChangeHandler<bool> forbidTitleChangeChangeHandler)
    {
        _forbidTitleChangeChangeHandler = forbidTitleChangeChangeHandler;
    }

    private bool _allowDECRQCRA;
    private IPropertyChangeHandler<bool>? _allowDECRQCRAChangeHandler;

    public bool AllowDECRQCRA
    {
        get => _allowDECRQCRA;
        set
        {
            if (Equals(value, _allowDECRQCRA))
            {
                return;
            }
            
            if (_allowDECRQCRAChangeHandler?.Handle(value) is null or true)
            {
                _allowDECRQCRA = value;
            }
        }
    }

    public void OnAllowDECRQCRAChanged(IPropertyChangeHandler<bool> allowDECRQCRAChangeHandler)
    {
        _allowDECRQCRAChangeHandler = allowDECRQCRAChangeHandler;
    }

    private bool _allowOSC52ToClipboard;
    private IPropertyChangeHandler<bool>? _allowOSC52ToClipboardChangeHandler;

    public bool AllowOSC52ToClipboard
    {
        get => _allowOSC52ToClipboard;
        set
        {
            if (Equals(value, _allowOSC52ToClipboard))
            {
                return;
            }
            
            if (_allowOSC52ToClipboardChangeHandler?.Handle(value) is null or true)
            {
                _allowOSC52ToClipboard = value;
            }
        }
    }

    public void OnAllowOSC52ToClipboardChanged(IPropertyChangeHandler<bool> allowOSC52ToClipboardChangeHandler)
    {
        _allowOSC52ToClipboardChangeHandler = allowOSC52ToClipboardChangeHandler;
    }

    private string? _enqResponse;
    private IPropertyChangeHandler<string?>? _enqResponseChangeHandler;

    public string? ENQResponse
    {
        get => _enqResponse;
        set
        {
            if (Equals(value, _enqResponse))
            {
                return;
            }
            
            if (_enqResponseChangeHandler?.Handle(value) is null or true)
            {
                _enqResponse = value;
            }
        }
    }

    public void OnENQResponseChanged(IPropertyChangeHandler<string?> enqResponseChangeHandler)
    {
        _enqResponseChangeHandler = enqResponseChangeHandler;
    }

    private bool _scrollToInput = true;
    private IPropertyChangeHandler<bool>? _scrollToInputChangeHandler;

    public bool ScrollToInput
    {
        get => _scrollToInput;
        set
        {
            if (Equals(value, _scrollToInput))
            {
                return;
            }
            
            if (_scrollToInputChangeHandler?.Handle(value) is null or true)
            {
                _scrollToInput = value;
            }
        }
    }

    public void OnScrollToInputChanged(IPropertyChangeHandler<bool> scrollToInputChangeHandler)
    {
        _scrollToInputChangeHandler = scrollToInputChangeHandler;
    }

    private BellNotificationBehavior _bellNotificationBehavior;
    private IPropertyChangeHandler<BellNotificationBehavior>? _bellNotificationBehaviorChangeHandler;

    public BellNotificationBehavior BellNotificationBehavior
    {
        get => _bellNotificationBehavior;
        set
        {
            if (Equals(value, _bellNotificationBehavior))
            {
                return;
            }
            
            if (_bellNotificationBehaviorChangeHandler?.Handle(value) is null or true)
            {
                _bellNotificationBehavior = value;
            }
        }
    }

    public void OnBellNotificationBehaviorChanged(
        IPropertyChangeHandler<BellNotificationBehavior> bellNotificationBehaviorChangeHandler)
    {
        _bellNotificationBehaviorChangeHandler = bellNotificationBehaviorChangeHandler;
    }

    private IBellNotificationCustomBehavior? _bellNotificationCustomBehavior;
    private IPropertyChangeHandler<IBellNotificationCustomBehavior?>? _bellNotificationCustomBehaviorChangeHandler;

    public IBellNotificationCustomBehavior? BellNotificationCustomBehavior
    {
        get => _bellNotificationCustomBehavior;
        set
        {
            if (Equals(value, _bellNotificationCustomBehavior))
            {
                return;
            }
            
            if (_bellNotificationCustomBehaviorChangeHandler?.Handle(value) is null or true)
            {
                _bellNotificationCustomBehavior = value;
            }
        }
    }

    public void OnBellNotificationCustomBehaviorChanged(
        IPropertyChangeHandler<IBellNotificationCustomBehavior?> bellNotificationCustomBehaviorChangeHandler)
    {
        _bellNotificationCustomBehaviorChangeHandler = bellNotificationCustomBehaviorChangeHandler;
    }

    private bool _showFlyoutAtRightClick;
    private IPropertyChangeHandler<bool>? _showFlyoutAtRightClickChangeHandler;

    public bool ShowFlyoutAtRightClick
    {
        get => _showFlyoutAtRightClick;
        set
        {
            if (Equals(value, _showFlyoutAtRightClick))
            {
                return;
            }
            
            if (_showFlyoutAtRightClickChangeHandler?.Handle(value) is null or true)
            {
                _showFlyoutAtRightClick = value;
            }
        }
    }

    public void OnShowFlyoutAtRightClickChanged(IPropertyChangeHandler<bool> showFlyoutAtRightClickChangeHandler)
    {
        _showFlyoutAtRightClickChangeHandler = showFlyoutAtRightClickChangeHandler;
    }

    private Flyout? _customFlyoutAtRightClick;
    private IPropertyChangeHandler<Flyout?>? _customFlyoutAtRightClickChangeHandler;

    public Flyout? CustomFlyoutAtRightClick
    {
        get => _customFlyoutAtRightClick;
        set
        {
            if (Equals(value, _customFlyoutAtRightClick))
            {
                return;
            }
            
            if (_customFlyoutAtRightClickChangeHandler?.Handle(value) is null or true)
            {
                _customFlyoutAtRightClick = value;
            }
        }
    }

    public void OnCustomFlyoutAtRightClickChanged(IPropertyChangeHandler<Flyout?> customFlyoutAtRightClickChangeHandler)
    {
        _customFlyoutAtRightClickChangeHandler = customFlyoutAtRightClickChangeHandler;
    }

    private bool _showMarkOnScrollBar;
    private IPropertyChangeHandler<bool>? _showMarkOnScrollBarChangeHandler;

    public bool ShowMarkOnScrollBar
    {
        get => _showMarkOnScrollBar;
        set
        {
            if (Equals(value, _showMarkOnScrollBar))
            {
                return;
            }
            
            if (_showMarkOnScrollBarChangeHandler?.Handle(value) is null or true)
            {
                _showMarkOnScrollBar = value;
            }
        }
    }

    public void OnShowMarkOnScrollBarChanged(IPropertyChangeHandler<bool> showMarkOnScrollBarChangeHandler)
    {
        _showMarkOnScrollBarChangeHandler = showMarkOnScrollBarChangeHandler;
    }

    private bool _useSearch;
    private IPropertyChangeHandler<bool>? _useSearchChangeHandler;

    public bool UseSearch
    {
        get => _useSearch;
        set
        {
            if (Equals(value, _useSearch))
            {
                return;
            }
            
            if (_useSearchChangeHandler?.Handle(value) is null or true)
            {
                _useSearch = value;
            }
        }
    }

    public void OnUseSearchChanged(IPropertyChangeHandler<bool> useSearchChangeHandler)
    {
        _useSearchChangeHandler = useSearchChangeHandler;
    }
}