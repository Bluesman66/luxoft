using System;
using System.Collections;
using System.Collections.Generic;

public class BtnTree<T> : IEnumerable<T> where T : IComparable
{
    private Btn<T> _head { get; set; }
    public int Count { get; set; }

    public void Add(T value)
    {
        if (_head == null)
            _head = new Btn<T>(value);
        else
            AddTo(_head, value);
    }

    private void AddTo(Btn<T> node, T value)
    {
        if (value.CompareTo(node.Value) < 0)
        {
            if (node.Left == null)
                node.Left = new Btn<T>(value);
            else
                AddTo(node.Left, value);
        }
        else
        {
            if (node.Right == null)
                node.Right = new Btn<T>(value);
            else
                AddTo(node.Right, value);
        }

        Count++;
    }

    public IEnumerator<T> InOrderTraversal()
    {
        if (_head != null)
        {
            Stack<Btn<T>> stack = new Stack<Btn<T>>();
            Btn<T> current = _head;

            bool goLeftNext = true;
            stack.Push(current);

            while (stack.Count > 0)
            {
                if (goLeftNext)
                {
                    while (current.Left != null)
                    {
                        stack.Push(current);
                        current = current.Left;
                    }
                }

                yield return current.Value;

                if (current.Right != null)
                {
                    current = current.Right;
                    goLeftNext = true;
                }
                else
                {
                    current = stack.Pop();
                    goLeftNext = false;
                }
            }
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return InOrderTraversal();
    }   

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}