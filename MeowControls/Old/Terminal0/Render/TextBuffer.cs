namespace MeowControls.Controls.Terminal0.Render;

public class TextBuffer(int columnCount, int maxSave)
{
    //每一行有多少列
    private int _columnCount = columnCount;

    //实际保存的内容
    private RenderRow?[] _rows = new RenderRow?[maxSave];
    
    //第一行 位置索引
    private int _firstRow = 0;

    #region 写 操作
    
    //行位置索引
    private int _writeRowIndex = 0;
    
    /// <summary>
    /// 插入新行。并将光标移动至新行
    /// </summary>
    public void InsertNewLine()
    {
        //将写指针后移
        MoveWriteIndexNext();
        //重置这一行内容
        GetRenderRow(_writeRowIndex).ResetContent();
    }
    
    /// <summary>
    /// 将行索引后移。该方法不会生成新行
    /// </summary>
    private void MoveWriteIndexNext()
    {
        _writeRowIndex = (_writeRowIndex + 1) % maxSave;
        //若写指针到顶了
        if (_writeRowIndex == _firstRow)
        {
            //满了。把第一行的位置后移
            MoveFirstRowNext();
        }
    }

    #endregion

    #region 读操作
    
    //行位置索引
    private int _readRowIndex = 0;

    /// <summary>
    /// 将行读取索引移动到指定行
    /// </summary>
    /// <param name="row">指定行行号, 从1开始的行号</param>
    public void MoveReadIndexTo(int row)
    {
        _readRowIndex = (row - 1) % maxSave;
    }

    /// <summary>
    /// 将行索引后移，该方法不会生成新行
    /// </summary>
    /// <returns>true - 移动读索引成功。后面还有行<br/>false - 移动读索引失败。后面没有更多行了</returns>
    public bool NextReadLine()
    {
        _readRowIndex = (_readRowIndex + 1) % maxSave;
        //若读索引到顶了。说明后面没有更多行了。读不了了。我们返回false
        return _readRowIndex != _firstRow;
    }

    /// <summary>
    /// 获取索引所在行的行。如果读索引指向的行为空，则返回新行
    /// </summary>
    /// <returns>读索引所在行的行</returns>
    public RenderRow GetRow()
    {
        return GetRenderRow(_readRowIndex);
    }
    
    
    #endregion

    /// <summary>
    /// 得到行内容。之所以不直接用_rows[index]而是要用GetRenderRow(index)是因为后者看起来更顺眼，更能一下子知道在干什么。<br/>
    /// 而且当该行为空时，该方法会自动插入并返回一个新行。
    /// </summary>
    private RenderRow GetRenderRow(int index)
    {
        return _rows[index] is null 
            ? _rows[index] = new RenderRow(_columnCount)
            : _rows[index]!; //rider 告诉我这里可能是null返回
    }

    /// <summary>
    /// 将第一行索引后移
    /// </summary>
    private void MoveFirstRowNext()
    {
        _firstRow = (_firstRow + 1) % maxSave;
    }

    //重置 最多可保存多少行
    public void ResetMaxSaveRenderRows(int ms)
    {
        
    }

    //重置 行长度
    public void ResetRowLength(int columnCount)
    {
        _columnCount = columnCount;
        
        Reflow();
    }

    //建立新buffer。将之前的值全部读到新的数组里
    private void Reflow()
    {
        
    }
}