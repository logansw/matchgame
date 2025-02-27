using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private const int GRID_WIDTH = 8;
    [SerializeField] private List<Ball> _selectedBalls;
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private List<Sprite> _sprites;
    public delegate void BallScoredDelegate(Ball ball);
    public static BallScoredDelegate OnBallScored;

    void Start()
    {
        PopulateQueueGrid();
        _selectedBalls = new List<Ball>();
        Ball.OnBallTapped += ProcessBallTap;
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

    public void ProcessBallTap(Ball ball)
    {
        if (_selectedBalls.Contains(ball))
        {
            if (_selectedBalls[_selectedBalls.Count-1] == ball)
            {
                ball.Deselect();
                _selectedBalls.Remove(ball);
            }
            return;
        }

        if (_selectedBalls.Count == 3)
        {
            Ball lastBall = _selectedBalls[_selectedBalls.Count - 1];
            if (ball.Value != lastBall.Value)
            {
                return;
            }
        }
        
        ball.HighlightSelected();
        
        if (_selectedBalls.Count != 0)
        {
            Ball lastBall = _selectedBalls[_selectedBalls.Count - 1];
            if (lastBall != null && ball.Value == lastBall.Value)
            {
                foreach (Ball b in _selectedBalls)
                {
                    Destroy(b.gameObject);
                    SpawnNewBall(new Vector2(b.Column, 10));
                }
                OnBallScored.Invoke(ball);
                _selectedBalls = new List<Ball>();
            }
        }

        _selectedBalls.Add(ball);
    }

    public Ball GetRandomBall()
    {
        Ball ball = Instantiate(_ballPrefab, transform);
        ball.Value = UnityEngine.Random.Range(0, 7);
        ball.SetSprite(_sprites[ball.Value]);
        return ball;
    }
}
