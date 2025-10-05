using System.Globalization;
using Avalonia;
using Avalonia.Media;
using MeowControls.Controls.Terminal0.Render.Engine;
using MeowControls.Terminal.Extensions;

namespace MeowControls.Controls.Terminal0.Render;

public class Renderer
{
    private int _columnCount;

    //每个RenderCell高
    private double _renderCellHeight;

    //每个RenderCell宽
    private double _renderCellWidth;

    private int _rowCount;

    //行渲染引擎，根据字体是否等宽而更改
    private IRowRenderEngine? _rowRenderEngine;

    private TextBuffer? _textBuffer;

    /// <summary>
    ///     初始化该渲染器（包括初始化TextBuffer以及初始化行渲染器）。该方法必须在Render调用之前调用
    /// </summary>
    /// <param name="bounds">Terminal的Bounds</param>
    public void Initialize(Rect bounds)
    {
        //Bounds的setter中有TextBuffer的??=
        //最开始是没有这个Initialize方法的，直接在Terminal的Render中对Bounds赋值，然后调用Render
        //但是这样不容易让人意识到这里的Bounds必须先赋值才能使用Render
        //所以加入此Initialize方法
        Bounds = bounds;
        //初始化行渲染器
        //如果是等宽字体，则使用MonoRowRenderEngine渲染，如果是非等宽字体，则使用NonMonoRowRenderEngine渲染
        if (_rowRenderEngine is null) SwitchRowRenderEngine();
    }

    /// <summary>
    ///     切换渲染引擎。该方法应当在rowRenderEngine为null或者Typeface FontSize，NormalForeground改变时使用
    /// </summary>
    public void SwitchRowRenderEngine()
    {
        _rowRenderEngine = Typeface.FontFamily.IsMonospaceFont()
            ? new MonoRowRenderEngine(Typeface, FontSize, NormalForeground, SelectedBackground, SelectedForeground,
                _renderCellWidth, _renderCellHeight)
            : new NonMonoRowRenderEngine(Typeface, FontSize, NormalForeground, SelectedBackground, SelectedForeground,
                _renderCellWidth, _renderCellHeight);
    }

    //这个currentRow参数指的是当前页面最上方的渲染行行号
    public void Render(DrawingContext context, int currentRow)
    {
        #region 第一层渲染；渲染背景图像

        if (BackgroundImage is null)
            //没有背景图像。我们也要渲染一个透明背景。否则很多交互事件我们拿不到
            context.DrawRectangle(Brushes.Transparent, new Pen(), new Rect(Bounds.Position, Bounds.Size));
        else
            context.DrawImage(BackgroundImage, new Rect(Bounds.Position, Bounds.Size));

        #endregion

        #region 第二层渲染：渲染行

        //此处不可能出现空引用。因为TextBuffer的赋值在Bounds赋值时就已经完成。而Bounds赋值在Render调用之前
        _textBuffer!.MoveReadIndexTo(currentRow);
        var x = LeftSpaceRemain;
        var y = TopSpaceRemain;
        for (var row = currentRow; row < currentRow + _rowCount + 1; row++)
        {
            //使用渲染引擎渲染该行
            _rowRenderEngine!.Render(_textBuffer.GetRow(), new Point(x, y), context);
            if (!_textBuffer.NextReadLine()) break;

            x += _renderCellHeight;
        }

        #endregion
    }

    /// <summary>
    ///     重新计算渲染区域(行与列的个数)。该方法同时使得RenderBuffer重新排列数组
    /// </summary>
    private void ReCalculateRenderArea()
    {
        _rowCount = (int)(RenderHeight / _renderCellHeight);
        _columnCount = (int)(RenderWidth / _renderCellWidth);
    }

    /// <summary>
    ///     释放资源（如果有）。
    /// </summary>
    public void Dispose()
    {
    }

    //为什么这个方法不从Renderer内部Property的Setter中引发而是暴露给外部要外部手动引发呢？
    //这是因为，如果按上面那么做的话，那么在加载到视觉树时，这个方法会被调用很多次
    //虽然这个性能损失不大。但是能优化一点是一点。
    //而且在内部Setter中引发这个方法，就必须给每个需要引发这个方法的属性加一个用的变量。这样写起来不优雅。代码量也多
    //因此这个方法暴露给外部。由外部在合适的情况下触发。内部不应调用此方法。
    /// <summary>
    ///     重新计算每一个RenderCell的宽和高
    /// </summary>
    public void ReCalculateRenderCellBounds()
    {
        //因为EM Size就是拿这个M做框的嘛。所以我们也拿这个M算RenderCell的宽高
        var standardEm = new FormattedText(
            "M",
            CultureInfo.CurrentCulture,
            FlowDirection.LeftToRight,
            Typeface,
            FontSize,
            NormalForeground
        );

        _renderCellWidth = standardEm.Width;
        _renderCellHeight = standardEm.Height;
    }

    #region Property

    /// <summary>
    ///     渲染区域距离上边界的距离。默认 5.0
    /// </summary>
    public double TopSpaceRemain { get; set; } = 5.0;

    /// <summary>
    ///     渲染区域距离左边界的距离。默认 5.0
    /// </summary>
    public double LeftSpaceRemain { get; set; } = 5.0;


    /// <summary>
    ///     背景图像。默认为空（null）。
    /// </summary>
    public IImage? BackgroundImage { get; set; }

    /// <summary>
    ///     字符选中（Selected）时，显示的背景色。默认 Brushes.LightSkyBlue
    /// </summary>
    public IImmutableSolidColorBrush SelectedBackground { get; set; } = Brushes.LightSkyBlue;

    /// <summary>
    ///     字符选中（Selected）时，显示的前景色。默认 Brushes.Black
    /// </summary>
    public IImmutableSolidColorBrush SelectedForeground { get; set; } = Brushes.Black;

    /// <summary>
    ///     字符未选中（Not Selected）时，显示的前景色。默认 Brushes.Black
    /// </summary>
    public IImmutableSolidColorBrush NormalForeground { get; set; } = Brushes.Black;

    private int _maxSaveRenderRows = 9999;

    /// <summary>
    ///     此Terminal控件最多可以保存多少历史渲染行。默认 9999
    /// </summary>
    public int MaxSaveRenderRows
    {
        get => _maxSaveRenderRows;
        set
        {
            _maxSaveRenderRows = value;
            _textBuffer?.ResetMaxSaveRenderRows(value);
        }
    }

    /// <summary>
    ///     渲染字体的FontSize。默认12.0
    /// </summary>
    public double FontSize { get; set; } = 12.0;

    // 这个Typeface是由外部改FontFamily等影响到Typeface的值的时候改的
    // 把它暴露给外部去改。而不是在内部去改，是因为外部setter好做值重复判断。这个原因跟把ReCalculateRenderCellBounds暴露给外部的原因类似
    //详情见 ReCalculateRenderCellBounds 方法上的注释
    /// <summary>
    ///     字形
    /// </summary>
    public Typeface Typeface { get; set; }

    private double _renderHeight;

    /// <summary>
    ///     总的渲染区域高
    /// </summary>
    public double RenderHeight
    {
        get => _renderHeight;
        set
        {
            if (value.Equals(_renderHeight)) return;
            ;
            _renderHeight = value;
            ReCalculateRenderArea();
        }
    }

    private double _renderWidth;

    /// <summary>
    ///     总的渲染区域宽
    /// </summary>
    public double RenderWidth
    {
        get => _renderWidth;
        set
        {
            if (value.Equals(_renderWidth)) return;

            _renderWidth = value;
            ReCalculateRenderArea();
        }
    }

    private Rect _bounds;

    public Rect Bounds
    {
        get => _bounds;
        set
        {
            _bounds = value;
            RenderHeight = value.Height;
            RenderWidth = value.Width;
            _textBuffer ??= new TextBuffer(_columnCount, MaxSaveRenderRows);
        }
    }

    #endregion
}