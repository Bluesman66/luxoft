using System;

public class Btn<T> where T : IComparable
{
    public T Value { get; set; }
    public Btn<T> Left { get; set; }
    public Btn<T> Right { get; set; }

    public Btn(T value)
    {
        Value = value;        
    }        
}
