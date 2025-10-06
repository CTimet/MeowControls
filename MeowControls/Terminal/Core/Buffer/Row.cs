using System;

namespace MeowControls.Terminal.Core.Buffer;

/// <summary>
///     一行渲染行，渲染行，渲染行，不是物理行！一个Row可能不以LF结尾
/// </summary>
public class Row
{
    public char[] Chars { get; }

    /// <summary>
    /// 各个字符的颜色属性值
    /// </summary>
    public ushort[] Attributes { get; }
    
    /// <summary>
    /// 构造一行虚拟行。 initialCapacity为行初始能容纳字符数，该值应由Renderer计算出并传参。
    /// initialCapacity不可小于等于0。否则会抛出InvalidOperationException
    /// </summary>
    public Row(int initialCapacity)
    {
        if (initialCapacity <= 0)
        {
            throw new InvalidOperationException($"Cannot build a row whose length = {initialCapacity}");
        }
        
        Chars = new char[initialCapacity];
        Attributes = new ushort[initialCapacity];
    }

    /// <summary>
    ///     表示该行是否为强制换行行。一个Row对象为一个渲染行，有的渲染行并不以LF结尾，是因为自动换行才存在的。如果该行是因为自动换行才存在的，则该标记为true
    /// </summary>
    public bool IsForceWrap { get; set; } = false;

    //指针，默认指向第1个字符，也就是第0个位置
    private int _pointerIndex = 0;

    /// <summary>
    /// 尝试将指针往后移动。成功则返回true，失败false。
    /// </summary>
    public bool NextPointer()
    {
        if (_pointerIndex + 1 == Chars.Length)
        {
            return false;
        }

        _pointerIndex++;
        return true;
    }

    /// <summary>
    /// 尝试将指针往前移动。成功则返回true，失败false
    /// </summary>
    public bool PrevPointer()
    {
        if (_pointerIndex == 0)
        {
            return false;
        }

        _pointerIndex--;
        return true;
    }
}