using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private const int GRID_WIDTH = 8;
    private BallQueueGrid _ballQueueGrid;
    [SerializeField] private BallRenderer _ballRenderer;
    [SerializeField] private Queue<Ball> _selectedBalls;
    
    void Start()
    {
        _ballQueueGrid = new BallQueueGrid(GRID_WIDTH);
        PopulateQueueGrid();
        _ballRenderer.Initialize(_ballQueueGrid, this);
        _selectedBalls = new Queue<Ball>(3);
    }

    private void PopulateQueueGrid()
    {
        for (int i = 0; i < _ballQueueGrid.Width; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                _ballQueueGrid.AddAt(i, Random.Range(0, 7));
            }
        }
    }

    public void AddBallToQueue(Ball ball)
    {
        _selectedBalls.Enqueue(ball);
        if (_selectedBalls.Count >= 3)
        {
            DeleteBallFromQueue();
        }
    }
    
    public void DeleteBallFromQueue()
    {
        Ball ball = _selectedBalls.Dequeue();
        Destroy(ball.gameObject);
    }
}
