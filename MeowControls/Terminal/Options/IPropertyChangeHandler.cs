namespace MeowControls.Controls.Terminal.Options;

public interface IPropertyChangeHandler<in T>
{
    /// <summary>
    /// 当这个Property发生改变时，会先调用此方法，然后根据该方法的返回值判断是否再调用SetValue
    /// </summary>
    /// <param name="value">改变后的值</param>
    /// <returns>是否要SetValue。如果返回false，则跳过SetValue。如果返回true，则SetValue</returns>
    public bool Handle(T value);
}