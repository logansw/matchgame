using System;
using System.Collections.Generic;

public class BallQueueGrid
{
    private List<Queue<int>> _balls;
    public int Width { get; private set; }
    public bool DataChanged { get; private set; }

    public BallQueueGrid(int width)
    {
        Width = width;
        _balls = new List<Queue<int>>();
        for (int i = 0; i < width; i++)
        {
            _balls.Add(new Queue<int>());
        }
    }
    
    public int RemoveAt(int column)
    {
        Queue<int> ballColumn = _balls[column];
        DataChanged = true;
        return ballColumn.Dequeue();
    }

    public void AddAt(int column, int item)
    {
        Queue<int> ballColumn = _balls[column];
        ballColumn.Enqueue(item);
        DataChanged = true;
    }

    public void ConsumeDataChange()
    {
        DataChanged = false;
    }

    public Queue<int> GetQueue(int column)
    {
        return _balls[column];
    }
}
