using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private const int GRID_WIDTH = 8;
    private BallQueueGrid _ballQueueGrid;
    [SerializeField] private BallRenderer _ballRenderer;
    
    void Start()
    {
        _ballQueueGrid = new BallQueueGrid(GRID_WIDTH);
        PopulateQueueGrid();
        _ballRenderer.Initialize(_ballQueueGrid);
    }

    private void PopulateQueueGrid()
    {
        for (int i = 0; i < _ballQueueGrid.Width; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                _ballQueueGrid.AddAt(i, Random.Range(0, 8));
            }
        }
    }
}
