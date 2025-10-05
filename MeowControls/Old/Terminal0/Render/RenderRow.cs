using System;

namespace MeowControls.Controls.Terminal0.Render;

public class RenderRow(int renderCellLength)
{
    /// <summary>
    ///     该行是否是因自动换行而强制换行
    /// </summary>
    public bool ForceWrap { get; set; }

    /// <summary>
    ///     是否启用自动换行
    /// </summary>
    public bool AutoNewLine { get; set; } = true;

    /// <summary>
    ///     实际的字符内容
    /// </summary>
    public char?[] Content { get; private set; } = new char?[renderCellLength];

    /// <summary>
    ///     这些字符的颜色啊什么的，都用一个ushort存储，通过位运算得到对应的颜色。如果对应的值是null则代表使用默认颜色
    /// </summary>
    public ushort?[] Attribute { get; private set; } = new ushort?[renderCellLength];

    /// <summary>
    ///     如果该行中的部分字符被选中，则选中从索引=SelectedFromIndex的字符开始。如果没有字符被选中，则该值为-1
    /// </summary>
    public int SelectedFromIndex { get; set; } = -1;

    /// <summary>
    ///     如果该行中的部分字符被选中，则选中到索引=SelectedToIndex的字符结束。如果没有字符被选中，则该值为-1
    /// </summary>
    public int SelectedToIndex { get; set; } = -1;

    /// <summary>
    ///     用于确认该行中是否有字符被选中。如果有，则返回true，否则返回false。
    /// </summary>
    public bool IsSomeCharSelected => SelectedFromIndex != -1;

    /// <summary>
    ///     该值代表光标的位置。譬如，光标在第3个字符处，第3个字符的数组索引为2，则此值为2。
    ///     在渲染的时候，先把文字渲染出来，然后再渲染光标，光标在哪个字符的位置，如果该位置有字符，则渲染在字符的最后，
    ///     如果该位置没有字符，则渲染在最前。因此此offset不会大于等于Content.Length。当offset=Content.Length -1 时，应当酌情考虑是否需要渲染
    /// </summary>
    public int CursorOffset { get; set; }

    /// <summary>
    ///     重置本行内容
    /// </summary>
    public void ResetContent()
    {
        Content = new char?[renderCellLength];
        CursorOffset = 0; //重置光标位置
    }

    /// <summary>
    ///     在光标位置写入指定字符
    /// </summary>
    /// <param name="c">指定字符</param>
    public void Write(char? c)
    {
        Content[CursorOffset] = c;
    }

    /// <summary>
    ///     将光标位置往前移动。如果已经到当前行最前面，则返回false。否则返回true
    /// </summary>
    public bool PrevCursor()
    {
        if (CursorOffset is 0) return false;

        CursorOffset--;
        return true;
    }

    /// <summary>
    ///     将光标位置后移。如果启用了自动换行，那么在光标到达最后时返回false。如果未启用自动换行，则该方法永远返回true
    /// </summary>
    /// <returns>true - 后移成功或该行已经被扩展<br />false - 后移失败，由于启用了自动换行，该行无法扩展</returns>
    public bool NextCursor()
    {
        //光标位置移动
        if (++CursorOffset < Content.Length) return true;

        //光标位置移动过头了。检查是否需要自动换行
        if (AutoNewLine)
        {
            ForceWrap = true; //该行被标记为自动换行的行
            //不能再继续在该渲染行移动光标了。你该进入下一渲染行了
            return false;
        }

        //自动换行未启用，扩展该行
        var newContent = new char?[Content.Length + renderCellLength];
        //拷贝原数据
        Array.Copy(Content, newContent, Content.Length);
        //覆盖数据
        Content = newContent;
        return true;
    }

    /// <summary>
    ///     删除光标之前的内容，并把后面的内容向前推进1个位置。该方法的作用类似于键盘上的Backspace键。
    ///     无论是Insert模式还是Override模式，backspace键的行为都是类似的
    /// </summary>
    public void Backspace()
    {
        //将光标往前移动
        if (!PrevCursor())
            //前移光标失败了，直接return就好
            return;

        ;
        //删除光标位置的字符。其实就是写入null
        Write(null);
        //然后将后面的字符全部往前移动一个单位。由于保留指定位置的字符，因此我们 CursorOffset + 1
        MoveCharsForward(CursorOffset + 1);
    }

    /// <summary>
    ///     删除光标所处位置的内容，并把后面的内容向前推进一个位置。该方法的作用类似于键盘上的Del键。
    ///     无论是Insert模式还是Override模式，del键的行为都是类似的。
    /// </summary>
    public void Delete()
    {
        //删除光标所在位置的字符
        Write(null);
        //然后将后面的字符全部往前移动一个单位
        MoveCharsForward(CursorOffset + 1);
    }

    /// <summary>
    ///     该方法将从指定位置索引的字符开始，将其及其后面的字符全部前移一个位置，并将最后一个位置用null填充。<br />
    ///     譬如，对于一个字符数组 [a, b, c, d] 调用此方法 MoveCharsForward(2)，此处索引为2的位置是c，则将c和d前移一个位置，数组变成
    ///     [a, c, d, null]。<br />
    ///     若前面没有更多位置了，或者给出的索引超出范围，则抛出InvalidOperationException异常。<br />
    /// </summary>
    private void MoveCharsForward(int fromIndex)
    {
        if (fromIndex <= 0 || fromIndex >= Content.Length) throw new InvalidOperationException();

        //从给定的位置开始复制字符到前面
        for (var i = fromIndex; i < Content.Length; i++) Content[i - 1] = Content[i];
        //将最后一个位置标记为null
        Content[^1] = null;
        //这里只需要将最后一个位置标记为null就好了。如果后面的位置都是null，譬如下面的情况
        // a b c null null
        //从b位置开始覆盖，则后面的两个null也会被前移，原来c的位置会被后面的null覆盖，最后一个位置还是null
        // b c null null null
        //此时Content[^1] = null;其实是多余的，但这里的性能开销很小。但如果最后一个位置不是null，譬如
        // a b c d e
        //从b位置开始覆盖，假如去掉Content[^1] = null;则结果应该是
        // b c d e e
        //因此需要这一行Content[^1] = null;
    }
}