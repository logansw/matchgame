using UnityEditor;
using UnityEngine;

public class ChainTracker : MonoBehaviour
{
    [HideInInspector] public int CurrentBallValue;
    [HideInInspector] public int CurrentStreak;
    private ScoreTracker _scoreTracker;

    void Start()
    {
        Ball.OnBallSelected += ChangeCurrentStreak;
        _scoreTracker = ScoreTracker.s_Instance;
    }

    private void ChangeCurrentStreak(Ball ball)
    {
        CurrentStreak = CurrentBallValue == ball.Value ? CurrentStreak + 1 : 1;
        _scoreTracker.Score += _scoreTracker.GetCombo(CurrentStreak);
        
        CurrentBallValue = ball.Value;
    }
}