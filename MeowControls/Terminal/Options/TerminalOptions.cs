using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace MeowControls.Terminal.Options;

public class TerminalOptions
{
    private bool _allowDECRQCRA;
    private Func<bool, bool>? _allowDECRQCRAChangeHandler;

    private bool _allowOSC52ToClipboard;
    private Func<bool, bool>? _allowOSC52ToClipboardChangeHandler;

    private bool _autoLineWrap = true;
    private Func<bool, bool>? _autoLineWrapChangeHandler;

    private IImage? _backgroundImage;
    private Func<IImage?, bool>? _backgroundImageChangeHandler;

    private ImageAlignment _backgroundImgAlignment = ImageAlignment.COVER;
    private Func<ImageAlignment, bool>? _backgroundImgAlignmentChangeHandler;

    private double _backgroundImgOpacity = 1.0;
    private Func<double, bool>? _backgroundImgOpacityChangeHandler;

    private BellNotificationBehavior _bellNotificationBehavior;
    private Func<BellNotificationBehavior, bool>? _bellNotificationBehaviorChangeHandler;

    private IBellNotificationCustomBehavior? _bellNotificationCustomBehavior;
    private Func<IBellNotificationCustomBehavior?, bool>? _bellNotificationCustomBehaviorChangeHandler;
    private Rect _bounds;
    private Func<Rect, bool>? _boundsChangeHandler;

    private CursorShape _cursorShape = CursorShape.BAR;
    private Func<CursorShape, bool>? _cursorShapeChangeHandler;

    private Flyout? _customFlyoutAtRightClick;
    private Func<Flyout?, bool>? _customFlyoutAtRightClickChangeHandler;

    private IBrush _defaultBackground = Brushes.Transparent;
    private Func<IBrush, bool>? _defaultBackgroundChangeHandler;

    private IBrush _defaultForeground = Brushes.Black;
    private Func<IBrush, bool>? _defaultForegroundChangeHandler;

    private EmphasizeTextStyle _emphasizeTextStyle = EmphasizeTextStyle.HIGHLIGHT;
    private Func<EmphasizeTextStyle, bool>? _emphasizeTextStyleChangeHandler;

    private string? _enqResponse;
    private Func<string?, bool>? _enqResponseChangeHandler;

    private FontFamily _fontFamily = FontFamily.Default;
    private Func<FontFamily, bool>? _fontFamilyChangeHandler;

    private double _fontSize = 12.0;
    private Func<double, bool>? _fontSizeChangeHandler;

    private FontStretch _fontStretch = FontStretch.Normal;
    private Func<FontStretch, bool>? _fontStretchChangeHandler;

    private FontStyle _fontStyle = FontStyle.Normal;
    private Func<FontStyle, bool>? _fontStyleChangeHandler;

    private FontWeight _fontWeight = FontWeight.Normal;
    private Func<FontWeight, bool>? _fontWeightChangeHandler;

    private bool _forbidTitleChange;
    private Func<bool, bool>? _forbidTitleChangeChangeHandler;

    private double _leftPadding = 5.0;
    private Func<double, bool>? _leftPaddingChangeHandler;

    private int _maxHistoryRows = 9999;
    private Func<int, bool>? _maxHistoryRowsChangeHandler;

    private bool _scrollToInput = true;
    private Func<bool, bool>? _scrollToInputChangeHandler;

    private IBrush _selectedBackground = Brushes.SkyBlue;
    private Func<IBrush, bool>? _selectedBackgroundChangeHandler;

    private IBrush _selectedForeground = Brushes.Black;
    private Func<IBrush, bool>? _selectedForegroundChangeHandler;

    private bool _showFlyoutAtRightClick;
    private Func<bool, bool>? _showFlyoutAtRightClickChangeHandler;

    private bool _showMarkOnScrollBar;
    private Func<bool, bool>? _showMarkOnScrollBarChangeHandler;

    private double _topPadding = 5.0;
    private Func<double, bool>? _topPaddingChangeHandler;

    private bool _useSearch;
    private Func<bool, bool>? _useSearchChangeHandler;

    public Rect Bounds
    {
        get => _bounds;
        set
        {
            if (Equals(value, _bounds)) return;

            if (_boundsChangeHandler?.Invoke(value) is null or true) _bounds = value;
        }
    }

    public int MaxHistoryRows
    {
        get => _maxHistoryRows;
        set
        {
            if (Equals(value, _maxHistoryRows)) return;

            if (_maxHistoryRowsChangeHandler?.Invoke(value) is null or true) _maxHistoryRows = value;
        }
    }

    public FontFamily FontFamily
    {
        get => _fontFamily;
        set
        {
            if (Equals(value, _fontFamily)) return;

            if (_fontFamilyChangeHandler?.Invoke(value) is null or true) _fontFamily = value;
        }
    }

    public FontStyle FontStyle
    {
        get => _fontStyle;
        set
        {
            if (Equals(value, _fontStyle)) return;

            if (_fontStyleChangeHandler?.Invoke(value) is null or true) _fontStyle = value;
        }
    }

    public FontWeight FontWeight
    {
        get => _fontWeight;
        set
        {
            if (Equals(value, _fontWeight)) return;

            if (_fontWeightChangeHandler?.Invoke(value) is null or true) _fontWeight = value;
        }
    }

    public FontStretch FontStretch
    {
        get => _fontStretch;
        set
        {
            if (Equals(value, _fontStretch)) return;

            if (_fontStretchChangeHandler?.Invoke(value) is null or true) _fontStretch = value;
        }
    }

    public double FontSize
    {
        get => _fontSize;
        set
        {
            if (Equals(value, _fontSize)) return;

            if (_fontSizeChangeHandler?.Invoke(value) is null or true) _fontSize = value;
        }
    }

    public IBrush DefaultForeground
    {
        get => _defaultForeground;
        set
        {
            if (Equals(value, _defaultForeground)) return;

            if (_defaultForegroundChangeHandler?.Invoke(value) is null or true) _defaultForeground = value;
        }
    }

    public IBrush DefaultBackground
    {
        get => _defaultBackground;
        set
        {
            if (Equals(value, _defaultBackground)) return;

            if (_defaultBackgroundChangeHandler?.Invoke(value) is null or true) _defaultBackground = value;
        }
    }

    public IBrush SelectedForeground
    {
        get => _selectedForeground;
        set
        {
            if (Equals(value, _selectedForeground)) return;

            if (_selectedForegroundChangeHandler?.Invoke(value) is null or true) _selectedForeground = value;
        }
    }

    public IBrush SelectedBackground
    {
        get => _selectedBackground;
        set
        {
            if (Equals(value, _selectedBackground)) return;

            if (_selectedBackgroundChangeHandler?.Invoke(value) is null or true) _selectedBackground = value;
        }
    }

    public IImage? BackgroundImage
    {
        get => _backgroundImage;
        set
        {
            if (Equals(value, _backgroundImage)) return;

            if (_backgroundImageChangeHandler?.Invoke(value) is null or true) _backgroundImage = value;
        }
    }

    public ImageAlignment BackgroundImgAlignment
    {
        get => _backgroundImgAlignment;
        set
        {
            if (Equals(value, _backgroundImgAlignment)) return;

            if (_backgroundImgAlignmentChangeHandler?.Invoke(value) is null or true) _backgroundImgAlignment = value;
        }
    }

    public double LeftPadding
    {
        get => _leftPadding;
        set
        {
            if (Equals(value, _leftPadding)) return;

            if (_leftPaddingChangeHandler?.Invoke(value) is null or true) _leftPadding = value;
        }
    }

    public double TopPadding
    {
        get => _topPadding;
        set
        {
            if (Equals(value, _topPadding)) return;

            if (_topPaddingChangeHandler?.Invoke(value) is null or true) _topPadding = value;
        }
    }

    public bool AutoLineWrap
    {
        get => _autoLineWrap;
        set
        {
            if (Equals(value, _autoLineWrap)) return;

            if (_autoLineWrapChangeHandler?.Invoke(value) is null or true) _autoLineWrap = value;
        }
    }

    public CursorShape CursorShape
    {
        get => _cursorShape;
        set
        {
            if (Equals(value, _cursorShape)) return;

            if (_cursorShapeChangeHandler?.Invoke(value) is null or true) _cursorShape = value;
        }
    }

    public double BackgroundImgOpacity
    {
        get => _backgroundImgOpacity;
        set
        {
            if (Equals(value, _backgroundImgOpacity)) return;

            if (_backgroundImgOpacityChangeHandler?.Invoke(value) is null or true) _backgroundImgOpacity = value;
        }
    }

    public EmphasizeTextStyle EmphasizeTextStyle
    {
        get => _emphasizeTextStyle;
        set
        {
            if (Equals(value, _emphasizeTextStyle)) return;

            if (_emphasizeTextStyleChangeHandler?.Invoke(value) is null or true) _emphasizeTextStyle = value;
        }
    }

    public bool ForbidTitleChange
    {
        get => _forbidTitleChange;
        set
        {
            if (Equals(value, _forbidTitleChange)) return;

            if (_forbidTitleChangeChangeHandler?.Invoke(value) is null or true) _forbidTitleChange = value;
        }
    }

    public bool AllowDECRQCRA
    {
        get => _allowDECRQCRA;
        set
        {
            if (Equals(value, _allowDECRQCRA)) return;

            if (_allowDECRQCRAChangeHandler?.Invoke(value) is null or true) _allowDECRQCRA = value;
        }
    }

    public bool AllowOSC52ToClipboard
    {
        get => _allowOSC52ToClipboard;
        set
        {
            if (Equals(value, _allowOSC52ToClipboard)) return;

            if (_allowOSC52ToClipboardChangeHandler?.Invoke(value) is null or true) _allowOSC52ToClipboard = value;
        }
    }

    public string? ENQResponse
    {
        get => _enqResponse;
        set
        {
            if (Equals(value, _enqResponse)) return;

            if (_enqResponseChangeHandler?.Invoke(value) is null or true) _enqResponse = value;
        }
    }

    public bool ScrollToInput
    {
        get => _scrollToInput;
        set
        {
            if (Equals(value, _scrollToInput)) return;

            if (_scrollToInputChangeHandler?.Invoke(value) is null or true) _scrollToInput = value;
        }
    }

    public BellNotificationBehavior BellNotificationBehavior
    {
        get => _bellNotificationBehavior;
        set
        {
            if (Equals(value, _bellNotificationBehavior)) return;

            if (_bellNotificationBehaviorChangeHandler?.Invoke(value) is null or true)
                _bellNotificationBehavior = value;
        }
    }

    public IBellNotificationCustomBehavior? BellNotificationCustomBehavior
    {
        get => _bellNotificationCustomBehavior;
        set
        {
            if (Equals(value, _bellNotificationCustomBehavior)) return;

            if (_bellNotificationCustomBehaviorChangeHandler?.Invoke(value) is null or true)
                _bellNotificationCustomBehavior = value;
        }
    }

    public bool ShowFlyoutAtRightClick
    {
        get => _showFlyoutAtRightClick;
        set
        {
            if (Equals(value, _showFlyoutAtRightClick)) return;

            if (_showFlyoutAtRightClickChangeHandler?.Invoke(value) is null or true) _showFlyoutAtRightClick = value;
        }
    }

    public Flyout? CustomFlyoutAtRightClick
    {
        get => _customFlyoutAtRightClick;
        set
        {
            if (Equals(value, _customFlyoutAtRightClick)) return;

            if (_customFlyoutAtRightClickChangeHandler?.Invoke(value) is null or true)
                _customFlyoutAtRightClick = value;
        }
    }

    public bool ShowMarkOnScrollBar
    {
        get => _showMarkOnScrollBar;
        set
        {
            if (Equals(value, _showMarkOnScrollBar)) return;

            if (_showMarkOnScrollBarChangeHandler?.Invoke(value) is null or true) _showMarkOnScrollBar = value;
        }
    }

    public bool UseSearch
    {
        get => _useSearch;
        set
        {
            if (Equals(value, _useSearch)) return;

            if (_useSearchChangeHandler?.Invoke(value) is null or true) _useSearch = value;
        }
    }

    public void OnBoundsChanged(Func<Rect, bool> boundsChangeHandler)
    {
        _boundsChangeHandler = boundsChangeHandler;
    }

    public void OnMaxHistoryRowsChanged(Func<int, bool> maxHistoryRowsChangeHandler)
    {
        _maxHistoryRowsChangeHandler = maxHistoryRowsChangeHandler;
    }

    public void OnFontFamilyChanged(Func<FontFamily, bool> fontFamilyChangeHandler)
    {
        _fontFamilyChangeHandler = fontFamilyChangeHandler;
    }

    public void OnFontStyleChanged(Func<FontStyle, bool> fontStyleChangeHandler)
    {
        _fontStyleChangeHandler = fontStyleChangeHandler;
    }

    public void OnFontWeightChanged(Func<FontWeight, bool> fontWeightChangeHandler)
    {
        _fontWeightChangeHandler = fontWeightChangeHandler;
    }

    public void OnFontStretchChanged(Func<FontStretch, bool> fontStretchChangeHandler)
    {
        _fontStretchChangeHandler = fontStretchChangeHandler;
    }

    public void OnFontSizeChanged(Func<double, bool> fontSizeChangeHandler)
    {
        _fontSizeChangeHandler = fontSizeChangeHandler;
    }

    public void OnDefaultForegroundChanged(Func<IBrush, bool> defaultForegroundChangeHandler)
    {
        _defaultForegroundChangeHandler = defaultForegroundChangeHandler;
    }

    public void OnDefaultBackgroundChanged(Func<IBrush, bool> defaultBackgroundChangeHandler)
    {
        _defaultBackgroundChangeHandler = defaultBackgroundChangeHandler;
    }

    public void OnSelectedForegroundChanged(Func<IBrush, bool> selectedForegroundChangeHandler)
    {
        _selectedForegroundChangeHandler = selectedForegroundChangeHandler;
    }

    public void OnSelectedBackgroundChanged(Func<IBrush, bool> selectedBackgroundChangeHandler)
    {
        _selectedBackgroundChangeHandler = selectedBackgroundChangeHandler;
    }

    public void OnBackgroundImageChanged(Func<IImage?, bool> backgroundImageChangeHandler)
    {
        _backgroundImageChangeHandler = backgroundImageChangeHandler;
    }

    public void OnBackgroundImgAlignmentChanged(
        Func<ImageAlignment, bool> backgroundImgAlignmentChangeHandler)
    {
        _backgroundImgAlignmentChangeHandler = backgroundImgAlignmentChangeHandler;
    }

    public void OnLeftPaddingChanged(Func<double, bool> leftPaddingChangeHandler)
    {
        _leftPaddingChangeHandler = leftPaddingChangeHandler;
    }

    public void OnTopPaddingChanged(Func<double, bool> topPaddingChangeHandler)
    {
        _topPaddingChangeHandler = topPaddingChangeHandler;
    }

    public void OnAutoLineWrapChanged(Func<bool, bool> autoLineWrapChangeHandler)
    {
        _autoLineWrapChangeHandler = autoLineWrapChangeHandler;
    }

    public void OnCursorShapeChanged(Func<CursorShape, bool> cursorShapeChangeHandler)
    {
        _cursorShapeChangeHandler = cursorShapeChangeHandler;
    }

    public void OnBackgroundImgOpacityChanged(Func<double, bool> backgroundImgOpacityChangeHandler)
    {
        _backgroundImgOpacityChangeHandler = backgroundImgOpacityChangeHandler;
    }

    public void OnEmphasizeTextStyleChanged(Func<EmphasizeTextStyle, bool> emphasizeTextStyleChangeHandler)
    {
        _emphasizeTextStyleChangeHandler = emphasizeTextStyleChangeHandler;
    }

    public void OnForbidTitleChangeChanged(Func<bool, bool> forbidTitleChangeChangeHandler)
    {
        _forbidTitleChangeChangeHandler = forbidTitleChangeChangeHandler;
    }

    public void OnAllowDECRQCRAChanged(Func<bool, bool> allowDECRQCRAChangeHandler)
    {
        _allowDECRQCRAChangeHandler = allowDECRQCRAChangeHandler;
    }

    public void OnAllowOSC52ToClipboardChanged(Func<bool, bool> allowOSC52ToClipboardChangeHandler)
    {
        _allowOSC52ToClipboardChangeHandler = allowOSC52ToClipboardChangeHandler;
    }

    public void OnENQResponseChanged(Func<string?, bool> enqResponseChangeHandler)
    {
        _enqResponseChangeHandler = enqResponseChangeHandler;
    }

    public void OnScrollToInputChanged(Func<bool, bool> scrollToInputChangeHandler)
    {
        _scrollToInputChangeHandler = scrollToInputChangeHandler;
    }

    public void OnBellNotificationBehaviorChanged(
        Func<BellNotificationBehavior, bool> bellNotificationBehaviorChangeHandler)
    {
        _bellNotificationBehaviorChangeHandler = bellNotificationBehaviorChangeHandler;
    }

    public void OnBellNotificationCustomBehaviorChanged(
        Func<IBellNotificationCustomBehavior?, bool> bellNotificationCustomBehaviorChangeHandler)
    {
        _bellNotificationCustomBehaviorChangeHandler = bellNotificationCustomBehaviorChangeHandler;
    }

    public void OnShowFlyoutAtRightClickChanged(Func<bool, bool> showFlyoutAtRightClickChangeHandler)
    {
        _showFlyoutAtRightClickChangeHandler = showFlyoutAtRightClickChangeHandler;
    }

    public void OnCustomFlyoutAtRightClickChanged(Func<Flyout?, bool> customFlyoutAtRightClickChangeHandler)
    {
        _customFlyoutAtRightClickChangeHandler = customFlyoutAtRightClickChangeHandler;
    }

    public void OnShowMarkOnScrollBarChanged(Func<bool, bool> showMarkOnScrollBarChangeHandler)
    {
        _showMarkOnScrollBarChangeHandler = showMarkOnScrollBarChangeHandler;
    }

    public void OnUseSearchChanged(Func<bool, bool> useSearchChangeHandler)
    {
        _useSearchChangeHandler = useSearchChangeHandler;
    }
}