using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRenderer : MonoBehaviour
{
    private BallQueueGrid _ballQueueGrid;
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private List<Sprite> _sprites;
    private BallController _ballController;

    public void Initialize(BallQueueGrid ballQueueGrid, BallController ballController)
    {
        _ballQueueGrid = ballQueueGrid;
        _ballController = ballController;
        InstantiateView();
        Ball.OnBallSelected += _ballController.AddBallToQueue;
    }

    public void InstantiateView()
    {
        for (int i = 0; i < _ballQueueGrid.Width; i++)
        {
            Queue<int> column = _ballQueueGrid.GetQueue(i);
            int count = column.Count;
            for (int j = 0; j < count; j++)
            {
                Ball ball = Instantiate(_ballPrefab, new Vector2(-((_ballQueueGrid.Width-1) / 2f) + i, j), Quaternion.identity, transform);
                ball.Value = column.Dequeue();
                ball.SetSprite(_sprites[ball.Value]);
            }
        }
    }

    private void UpdateView()
    {
        _ballQueueGrid.ConsumeDataChange();
    }
}