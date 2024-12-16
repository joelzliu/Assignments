namespace Task1;

using System;
using System.Collections.Generic;

public class MyStack<T>
{
    private List<T> stack;

    public MyStack()
    {
        stack = new List<T>();
    }

    public int Count()
    {
        return stack.Count;
    }

    public T Pop()
    {
        if (stack.Count == 0)
            throw new InvalidOperationException("Stack is empty.");
        
        T item = stack[stack.Count - 1];
        stack.RemoveAt(stack.Count - 1);
        return item;
    }

    public void Push(T element)
    {
        stack.Add(element);
    }
}