using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BallController : MonoBehaviour
{
    private const int GRID_WIDTH = 8;
    [SerializeField] private Queue<Ball> _selectedBalls;
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private List<Sprite> _sprites;

    void Start()
    {
        PopulateQueueGrid();
        _selectedBalls = new Queue<Ball>(3);
        Ball.OnBallSelected += AddBallToQueue;
    }

    private void PopulateQueueGrid()
    {
        for (int i = 0; i < GRID_WIDTH; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                SpawnNewBall(new Vector2(i, j));
            }
        }
    }
    
    public void SpawnNewBall(Vector2 position)
    {
        Ball ball = GetRandomBall();
        ball.Column = (int)position.x;
        ball.transform.localPosition = new Vector2(-((GRID_WIDTH-1) / 2f) + position.x, position.y);
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
        SpawnNewBall(new Vector2(ball.Column, 10));
        Destroy(ball.gameObject);
    }

    public Ball GetRandomBall()
    {
        Ball ball = Instantiate(_ballPrefab, transform);
        ball.Value = Random.Range(0, 7);
        ball.SetSprite(_sprites[ball.Value]);
        return ball;
    }
}
