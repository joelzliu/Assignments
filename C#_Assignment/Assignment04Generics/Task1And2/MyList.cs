namespace Task1;

using System;
using System.Collections.Generic;

public class MyList<T>
{
    private List<T> list;

    public MyList()
    {
        list = new List<T>();
    }

    public void Add(T element)
    {
        list.Add(element);
    }

    public T Remove(int index)
    {
        if (index < 0 || index >= list.Count)
            throw new ArgumentOutOfRangeException(nameof(index), "Invalid index.");

        T removed = list[index];
        list.RemoveAt(index);
        return removed;
    }

    public bool Contains(T element)
    {
        return list.Contains(element);
    }

    public void Clear()
    {
        list.Clear();
    }

    public void InsertAt(T element, int index)
    {
        if (index < 0 || index > list.Count)
            throw new ArgumentOutOfRangeException("Invalid index.");
        
        list.Insert(index, element);
    }

    public void DeleteAt(int index)
    {
        if (index < 0 || index >= list.Count)
            throw new ArgumentOutOfRangeException("Invalid index.");
        
        list.RemoveAt(index);
    }

    public T Find(int index)
    {
        if (index < 0 || index >= list.Count)
            throw new ArgumentOutOfRangeException("Invalid index.");
        
        return list[index];
    }
}