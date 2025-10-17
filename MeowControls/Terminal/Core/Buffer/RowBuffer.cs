using System;
using MeowControls.Terminal.Options;

namespace MeowControls.Terminal.Core.Buffer;

public class RowBuffer
{
    //缓冲区。如果某个index位置是空，则代表该位置行不存在。即便是空行也不会是null
    private Row?[] _buffer;
    //启动子。从这个位置开始代表第1行
    private int _bufferStartIndex = 0;
    //写行编号。这个就是普通的行编号，从1开始，一直到options.MaxHistoryRows。该值不会超过options.MaxHistoryRows
    private int _rowWritePosition = 1;
    //读行编号。普通的行编号，从1开始。
    private int _rowReadPosition = 1;
    //最大行编号。它代表了当前buffer中最大能操作的行的位置
    private int _rowMaxPosition = 1;

    public RowBuffer(TerminalOptions options)
    {
        _buffer = new Row[options.MaxHistoryRows];
        options.OnMaxHistoryRowsChanged(maxHistoryRows =>
        {
            //TODO
            //处理_buffer的并发问题
            //走到这里的数都是经过Terminal类里setter的检查的。因此我们不需要再次检查
            //由于maxHistory更改。我们也要更改当前的buffer大小
            ReArrangeBuffer(maxHistoryRows);
            return true;
        });
    }

    private void ReArrangeBuffer(int maxHistoryRows)
    {
        //不需要再对maxHistoryRows校验。前面已经校验过了。并且这个数和当前的buffer.Length一定不同
        var newBuffer = new Row?[maxHistoryRows];
        //首先校验新的maxHistory是更大了还是更小了
        if (maxHistoryRows > _buffer.Length)
        {
            //更大了。这个很好说。
            //如果start为0，那么就原样拷贝就行了。不需要做任何修改
            if (_bufferStartIndex is 0)
            {
                Array.Copy(_buffer, newBuffer, _buffer.Length);
            }
            else
            {
                //如果不为0，就得费点工夫了。此时说明buffer已经被环形写入了。这时候需要两次拷贝
                Array.Copy(_buffer, _bufferStartIndex, newBuffer, 0, _buffer.Length - _bufferStartIndex + 1); //这是length所以+1
                Array.Copy(_buffer, 0, newBuffer, _buffer.Length - _bufferStartIndex + 1, _bufferStartIndex);
            }
        }
        else
        {
            //maxHistory变小了。这意味着我们需要丢掉一些内容
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 判断是否存在下一可接触行。所谓可接触行就是能通过GetRow得到的，不为null的行。一般为null就是该位置未被填充，
    /// 表现在terminal上就是鼠标下箭头按了没法再下移光标。此时，IsHasNextAccessibleLine返回false。如果通过
    /// 下箭头能成功切换行，此方法也应返回true。<br/>
    /// 即使该方法返回false，也并不意味着下一个位置一定为null。如果_buffer被填满也可能出现这种情况。该方法的返回
    /// 与“通过下箭头能否成功下移光标”一致。
    /// </summary>
    public bool IsHasNextAccessibleLine()
    {
        //如果已经是最后一行了，就直接返回false
        if (_rowReadPosition == _buffer.Length)
        {
            return false;
        }
        
        //判断下一行是不是null。不是null那下一行就能拿
        return GetWriteRowWithOffset(1) is not null;
    }

    /// <summary>
    /// 判断是否存在上一可接触行。具体解释参见IsHasNextAccessibleLine，这俩的逻辑都差不多，只不过一个上一个下。
    /// </summary>
    public bool IsHasPrevAccessibleLine()
    {
        //如果已经是最前面一行了，就直接返回false
        //如果不是，则返回true。这是因为，如果不是第一行，则前面行一定不为null
        //因为无法在行与行之间插入一个null行。null行的存在是因为有可能terminal窗口里没有足够数量的行，但数组长度又是固定的，
        //那些没有用到的数组位置就是null行。而插入行，即使是插入一段空行，也是有Row对象的。因此，
        //当行位置为已存在行时，前面的行一定存在。
        return _rowReadPosition is not 1;
    }

    /// <summary>
    /// 获得当前写行指针指向的行对象。
    /// </summary>
    /// <returns></returns>
    public Row? GetWriteRow()
    {
        return GetWriteRowWithOffset(0);
    }

    public Row? GetReadRow()
    {
        return GetReadRowWithOffset(0);
    }

    /// <summary>
    /// 获得当前写行指针指向的行对象。可选参数 offset，即偏移量，offset=1就拿当前行+1行，也就是下一行的位置，
    /// offset=2就拿再下一行。offset=-1就拿上一行。<br/>
    /// 如果你真的想要拿上一行或者下一行，建议通过NextRowPosition或者PrevRowPosition操作，然后调用GetRow方法
    /// ，而不是传递offset，这里的offset只是为了给IsHasNextAccessibleLine用的。
    /// </summary>
    private Row? GetWriteRowWithOffset(int offset)
    {
        return _buffer[GetWriteRowIndex(offset)];
    }

    /// <summary>
    /// 详见GetWriteRowWithOffset。只不过这个操作的是读行
    /// </summary>
    private Row? GetReadRowWithOffset(int offset)
    {
        return _buffer[GetReadRowIndex(offset)];
    }
    
    /// <summary>
    /// 将写行号+1，如果+1后大于最大可写行号，则返回false，操作失败，否则操作成功，行号+1，同时返回true
    /// </summary>
    public bool NextWritePosition()
    {
        return _rowWritePosition + 1 <= _rowMaxPosition && ++_rowWritePosition == _rowWritePosition;
    }
    
    /// <summary>
    /// 将读行号+1，如果+1后大于最大可读行号，则返回false，操作失败，否则操作成功，行号+1，同时返回true
    /// </summary>
    public bool NextReadPosition()
    {
        return _rowReadPosition + 1 <= _rowMaxPosition && ++_rowReadPosition == _rowReadPosition;
    }

    /// <summary>
    /// 在当前行号位置插入一个新行。并将行号挪动到新行的位置
    /// </summary>
    public void NewRow(int initialCapacity)
    {
        //如果当前行号已经是最大位置了，也就是说，再插入新行就得覆盖旧的了
        if (_rowWritePosition == _buffer.Length)
        {
            //此时要做的就简单了。把startIndex往后挪一下就行了.然后把原本startIndex的位置赋值成新行
            _bufferStartIndex++;
            goto Finally;
        }
        
        //获得下一行行号位置映射后的数组下标。这里的下标就是我们修改的开始
        var currentIndex = GetWriteRowIndex(1);
        //将后面的元素全部都挪一位
        //先准备两个副本
        // ReSharper disable once JoinDeclarationAndInitializer
        Row? temp1;
        Row? temp2;
        
        //挪动前，先把原有的元素放入副本1
        temp1 = _buffer[currentIndex];
        
        //计算一下初步停止位置
        var stopIndex = currentIndex > _bufferStartIndex ? _buffer.Length : _bufferStartIndex;
        //准备一个循环，循环挪动元素
        while (currentIndex < stopIndex -1) //这里减1是因为，循环中要访问currentIndex的下一个位置
        {
            //把下一个元素放入副本2
            temp2 = _buffer[currentIndex + 1];
            //挪动指针，然后将副本1中的元素放入现在的位置，也就是上面temp2原本待的位置
            _buffer[++currentIndex] = temp1;
            //如果下一个元素，也就是temp2为null，那么就没必要继续循环了。按照正常情况下，一个null行后面跟的所有只能是null行
            if (temp2 is null)
            {
                goto Finally;
            }
            //将副本2中的元素挪到副本1中
            temp1 = temp2;
        }
        //走到这里，没有通过goto走Finally的，说明一直循环到末尾，都没有碰上null行
        //我们继续处理，首先判断stopIndex是不是_buffer.Length。如果是就说明上面的代码在startIndex前循环，那么就直接跳到Finally就行了
        //否则，则意味着上面的代码循环到buffer末尾了，就有必要进行下面的操作
        if (stopIndex == _bufferStartIndex)
        {
            goto Finally;
        }
        //判断是否这个startIndex是否0.是0就说明这个_buffer没有被循环复写
        //是0就好说了，既然没有被复写，直接把temp1，2丢弃。这就相当于最后一行由于maxHistory的限制被丢弃了
        //如果不是0.那就要继续。
        if (_bufferStartIndex is not 0)
        {
            //首先把指针挪到最前面，还要-1，因为首次访问的位置是currentIndex+1，要使得这个值为0，就得-1
            currentIndex = -1;
            while (currentIndex < _bufferStartIndex -1) //这里也要减1。因为循环中要访问currentIndex++
            {
                temp2 = _buffer[currentIndex + 1];
                _buffer[++currentIndex] = temp1;
                if (temp2 is null)
                {
                    goto Finally;
                }

                temp1 = temp2;
            }
            
            //走到这个位置就说明已经彻底完成了。可以走Finally做善后了
        }
        
        Finally:
        //如果是用goto走到这个位置就说明后面全是null了。
        //如果是正常走到这个位置就说明已经完成了元素的移动
        //总之。在这里，我们要做最后的善后工作了
        //首先是把GetRowIndex(1)位置的元素改成新行
        _buffer[GetWriteRowIndex(1)] = new Row(initialCapacity);
        //然后我们改maxRowPosition。这里这么写是为了防止rowMaxPosition大于buffer.Length。其实如果这里返回buffer.Length，其实变相说明上面的操作中抛弃了最后一行
        _rowMaxPosition = Math.Min(_rowMaxPosition + 1, _buffer.Length);
        //改完maxPosition我们再改rowPosition。改到新行。下面的代码防止了rowPosition超过maxPosition，或者=0
        _rowWritePosition = _rowWritePosition + 1 >= _rowMaxPosition ? _rowMaxPosition : _rowWritePosition + 1;
        //大功告成
    }

    /// <summary>
    /// 切换到指定行号。如果指定行号不存在，或者指定行号不在可写范围内，则抛出InvalidOperationException
    /// </summary>
    public void MoveWriteTo(int rowPos)
    {
        if (rowPos <= 0 || rowPos > _buffer.Length || rowPos > _rowMaxPosition)
        {
            throw new InvalidOperationException("Invalid row position.");
        }

        _rowWritePosition = rowPos;
    }
    
    /// <summary>
    /// 切换到指定行号。如果指定行号不存在，或者指定行号不在可读范围内，则抛出InvalidOperationException
    /// </summary>
    public void MoveReadTo(int rowPos)
    {
        if (rowPos <= 0 || rowPos > _buffer.Length || rowPos > _rowMaxPosition)
        {
            throw new InvalidOperationException("Invalid row position.");
        }

        _rowReadPosition = rowPos;
    }

    /// <summary>
    /// 将行编号映射成实际的数组下标。该方法保证下标不溢出。可选参数offset，即偏移量。例如，offset=1，
    /// 则返回下一行的数组下标。offset=-2，则返回往前数第2行的数组下标。默认offset=0，即只映射当前行的行号。
    /// </summary>
    private int GetWriteRowIndex(int offset = 0)
    {
        return (_bufferStartIndex + _rowWritePosition - 1 + offset) % _buffer.Length;
    }

    private int GetReadRowIndex(int offset = 0)
    {
        return (_bufferStartIndex + _rowReadPosition - 1 + offset) % _buffer.Length;
    }
}