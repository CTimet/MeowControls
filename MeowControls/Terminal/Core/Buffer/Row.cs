namespace MeowControls.Controls.Terminal.Core.Buffer;

/// <summary>
/// 一行渲染行，渲染行，渲染行，不是物理行！一个Row可能不以LF结尾
/// </summary>
public class Row
{
    //这个 new char[97] 可不是随便写的。如果这个值过小，就要频繁扩容，影响性能，虽然也问题不大
    //如果这个值过大，又会浪费空间。考虑到这个Terminal控件最初是为了写给我管理mc的软件用的，所以我让ai写了一个小程序，统计了一个简单的mc控制台log里
    //各行的行宽，然后取了75%分位数。计算的结果就是97.0。本来想取70%的，感觉太小了，而且不是整数，又改成80%，又想会不会太大了，也不是整数
    //而75%，不大不小，而且计算结果刚好是整数。所以这里行的默认初始化大小就是75个字符了
    public char[] Chars { get; private set; } = new char[97];

    /// <summary>
    /// 表示该行是否为强制换行行。一个Row对象为一个渲染行，有的渲染行并不以LF结尾，是因为自动换行才存在的。如果该行是因为自动换行才存在的，则该标记为true
    /// </summary>
    public bool IsForceWrap { get; set; } = false;
    
    
}