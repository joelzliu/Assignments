namespace Task3;

using System;
using System.Collections.Generic;
using System.Linq;

public class GenericRepository<T> : IRepository<T> where T : Entity
{
    private readonly List<T> items;

    public GenericRepository()
    {
        items = new List<T>();
    }

    public void Add(T item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));
        items.Add(item);
    }

    public void Remove(T item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));
        items.Remove(item);
    }

    public void Save()
    {
        Console.WriteLine("Changes saved to the repository.");
    }

    public IEnumerable<T> GetAll()
    {
        return items;
    }

    public T GetById(int id)
    {
        return items.FirstOrDefault(item => item.Id == id);
    }
}