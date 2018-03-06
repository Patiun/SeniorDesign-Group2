using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A First-In, First-Out data structure
// Think like a line at the store (get in line at the back and leave at the front)
public class Queue<T>
{
    // List to store all the objects in the queue
    private List<T> items;

    // The length of the queue
    public int Count
    {
        get { return items.Count; }
    }

    // The index of the first entry in the queue
    // This value will always be 0
    public T First
    {
        get { return items[0]; }
    }

    // The index of the last entry in the queue
    public T Last
    {
        get { return items[items.Count - 1]; }
    }

    // Custom indexer
    // Allows for accessing entries with:
    // queue[0]
    public T this[int index]
    {
        get { return items[index]; }
    }

    // Constructor
    // Instantiates the queue with length 0
    public Queue()
    {
        items = new List<T>();
    }

    /// <summary>
    /// Add a new item to the back of the queue
    /// </summary>
    /// <param name="item">The item to add</param>
    /// <returns>The position of that item in the queue</returns>
    public void Enqueue(T item)
    {
        items.Add(item);
    }

    /// <summary>
    /// Remove the first item from the queue
    /// </summary>
    /// <returns>The first item in the queu (the one that has been removed)</returns>
    public T Dequeue()
    {
        // First ensure that the queue is not empty
        if (Count > 0)
        {
            // Store the item in index 0 (the first in the queue)
            T item = items[0];
            // Remove it from the list and return it
            items.Remove(item);
            return item;
        }

        // If the queue is empty, just return the default item of whatever generic class is being stored
        return default(T);
    }

    /// <summary>
    /// Whether the queue contains an item
    /// </summary>
    /// <param name="target">The object target to search for</param>
    /// <returns>Bool true if an object matching target is found and false otherwise</returns>
    public bool Contains(T target)
    {
        // Compare each item in the queue to the target item
        foreach(T item in items)
        {
            // If a match is found, return true
            if(item.Equals(target))
            {
                return true;
            }
        }
        
        // Return false if no match is found
        return false;
    }
}
