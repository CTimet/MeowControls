using System;
using System.Collections.Generic;
using System.Linq;

namespace MeowControls.Controls.Terminal.Core.Buffer;

/// <summary>
/// 一个同时具有LinkedList高效随机插入，同时具有维持一定容量功能的类，当元素过多时可以删除头部元素或者尾部元素。
/// 主要用于为TextBuffer储存渲染行使用。因为终端经常需要随机插入删除，
/// 同时也需要容量控制以实现超出容量时丢弃行。遂编写此类
/// </summary>
public class RowBuffer<T>
{
    private readonly LinkedList<T> _buffer;

    public int Count => _buffer.Count;

    //全局指针
    private LinkedListNode<T>? _pointer;

    private readonly int _capacity;

    public bool IsPointerAtFirst => Equals(_pointer, _buffer.First);

    public bool IsPointerAtLast => Equals(_pointer, _buffer.Last);

    public RowBuffer(int capacity)
    {
        _buffer = new();
        //在这里，_buffer还是空的，_pointer先不赋值
        _capacity = capacity;
    }

    /// <summary>
    /// 将元素添加到末尾，如果添加后元素总数超过构造时传入的capacity，则删除头部元素
    /// </summary>
    /// <param name="t">元素</param>
    public void Enqueue(T t)
    {
        _buffer.AddLast(t);
        CheckCapacityMaintain();

        if (Count is 1)
        {
            //这是第一个元素，把_pointer设置为它
            _pointer = _buffer.First!;
        }
    }

    /// <summary>
    /// 获取第一个元素，同时移除它。如果队列为空，则抛出InvalidOperationException
    /// </summary>
    /// <returns></returns>
    public T Dequeue()
    {
        if (_buffer.First is null)
        {
            throw new InvalidOperationException("Buffer is empty when trying to invoke #Dequeue");
        }

        if (Equals(_pointer, _buffer.First))
        {
            //一并修改_pointer
            _pointer = null;
        }
        var t = _buffer.First.Value;
        _buffer.RemoveFirst();
        return t;
    }

    /// <summary>
    /// 获取第一个元素，不移除它。如果队列为空，则抛出InvalidOperationException
    /// </summary>
    /// <returns></returns>
    public T Peek()
    {
        if (_buffer.First is null)
        {
            throw new InvalidOperationException("Buffer is empty when trying to invoke #Peek");
        }

        return _buffer.First.Value;
    }

    /// <summary>
    /// 得到指针指的元素，如果指针为null，则抛出InvalidOperationException
    /// </summary>
    public T Get()
    {
        if (_pointer is null)
        {
            throw new InvalidOperationException("Pointer is null. #Get");
        }

        return _pointer.Value;
    }

    /// <summary>
    /// 在指针所指的位置后面插入一个新元素。如果插入后Count>传入的capacity，则删除头部元素。
    /// 如果指针为null，则抛出InvalidOperationException。
    /// 该操作不改变指针位置。
    /// </summary>
    public void InsertAfter(T t)
    {
        if (_pointer is null)
        {
            throw new InvalidOperationException("Pointer is null. #InsertAfter");
        }

        _buffer.AddAfter(_pointer, new LinkedListNode<T>(t));
        CheckCapacityMaintain();
    }

    /// <summary>
    /// 在指针所指的位置后面插入一个新元素。如果插入后Count>传入的capacity，则删除头部元素。
    /// 如果指针为null，则抛出InvalidOperationException。
    /// 该操作将指针向后移动到插入的位置
    /// </summary>
    public void InsertAfterAndNext(T t)
    {
        InsertAfter(t);
        _pointer = _pointer!.Next;
    }

    /// <summary>
    /// 在指针所指的位置前面插入一个新元素。如果插入后Count>传入的capacity，则删除尾部元素。
    /// 如果指针为null，则抛出InvalidOperationException。
    /// 该操作不改变指针位置。
    /// </summary>
    public void InsertBefore(T t)
    {
        if (_pointer is null)
        {
            throw new InvalidOperationException("Pointer is null. #InsertBefore");
        }

        _buffer.AddBefore(_pointer, new LinkedListNode<T>(t));
        CheckCapacityMaintain(true);
    }

    /// <summary>
    /// 在指针所指的位置前面插入一个新元素。如果插入后Count>传入的capacity，则删除尾部元素。
    /// 如果指针为null，则抛出InvalidOperationException。
    /// 该操作将指针向前移动到插入的位置
    /// </summary>
    public void InsertBeforeAndPrev(T t)
    {
        InsertBefore(t);
        _pointer = _pointer!.Previous;
    }

    /// <summary>
    /// 将指针向后移动。如果移动到最后了，则操作此方法无任何效果。如果指针为null，则抛出InvalidOperationException
    /// </summary>
    public void NextPointer()
    {
        if (_pointer is null)
        {
            throw new InvalidOperationException("Pointer is null. #NextPointer");
        }

        if (_pointer.Next is not null)
        {
            _pointer = _pointer.Next;
        }
    }

    /// <summary>
    /// 将指针向后移动。如果移动到最前了，则操作此方法无任何效果。如果指针为null，则抛出InvalidOperationException
    /// </summary>
    public void PrevPointer()
    {
        if (_pointer is null)
        {
            throw new InvalidOperationException("Pointer is null. #PrevPointer");
        }

        if (_pointer.Previous is not null)
        {
            _pointer = _pointer.Previous;
        }
    }

    /// <summary>
    /// 将指针重置到头部位置。队列为空时，指针将为null
    /// </summary>
    public void ResetPointerToFirst()
    {
        _pointer = _buffer.First;
    }

    /// <summary>
    /// 将指针重置到尾部位置。队列为空时，指针将为null
    /// </summary>
    public void ResetPointerToLast()
    {
        _pointer = _buffer.Last;
    }

    private void CheckCapacityMaintain(bool deleteLast = false)
    {
        if (Count <= _capacity)
        {
            return;
        }
        
        if (deleteLast)
        {
            if (Equals(_pointer, _buffer.Last))
            {
                _pointer = _pointer?.Previous;
            }
            
            _buffer.RemoveLast();
            return;
        }

        if (Equals(_pointer, _buffer.First))
        {
            _pointer = _pointer?.Next;
        }
        _buffer.RemoveFirst();
    }
    
    //public bool Contains(T t)
    //本类不需要此方法。设计此类的初衷是为了给TextBuffer使用。没有任何需求需要用到此方法

    /// <summary>
    /// 清空队列中元素
    /// </summary>
    public void Clear()
    {
        _buffer.Clear();
    }
    
    //public T[] ToArray()
    //不需要，用不上
    
    //public void TrimExcess()
    //不需要，用不上

    public void Foreach(Action<T> action)
    {
        foreach (var row in _buffer)
        {
            action.Invoke(row);
        }
    }
}