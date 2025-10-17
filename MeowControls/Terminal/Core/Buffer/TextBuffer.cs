using MeowControls.Terminal.Options;

namespace MeowControls.Terminal.Core.Buffer;

public class TextBuffer(TerminalOptions options, Components components) : ConfigurableComponent(options)
{
    private readonly RowBuffer _rowBuffer = new RowBuffer(options);
    
    public void Insert(char c)
    {
        if (c is '\n')
        {
            //换行处理
        }
        else
        {
            //正常处理
        }
    }

    public void Replace(char c)
    {
        
    }

    public void Del()
    {
        
    }

    public void Backspace()
    {
        
    }

    public void RemoveRow()
    {
        
    }

    public void CursorUp()
    {
        
    }

    public void CursorDown()
    {
        
    }

    public void CursorLeft()
    {
        
    }

    public void CursorRight()
    {
        
    }

    public bool IsHasNextAccessibleLine()
    {
        return _rowBuffer.IsHasNextAccessibleLine();
    }

    public Row? GetRow()
    {
        return _rowBuffer.GetWriteRow();
    }
}