using UnityEditor;
using UnityEngine;

public class ChainTracker : MonoBehaviour
{
    [HideInInspector] public int CurrentBallValue;
    [HideInInspector] public int CurrentStreak;
    private ScoreTracker _scoreTracker;
    private bool _currentBallIsBonus;

    void Start()
    {
        BallController.OnBallScored += ChangeCurrentStreak;
        _scoreTracker = ScoreTracker.s_Instance;
    }

    private void ChangeCurrentStreak(Ball ball)
    {
        if (ball.IsWild)
        {
            ball.Value = CurrentBallValue;
            CurrentStreak++;
            _scoreTracker.Score += _scoreTracker.GetCombo(CurrentStreak);
        }
        else if (ball.IsBonus)
        {
            if (_currentBallIsBonus)
            {
                _scoreTracker.Score += 100;
            }
            
            _scoreTracker.Score += _scoreTracker.GetBonus(CurrentStreak);
            CurrentStreak = 1;
        }
        else
        {
            CurrentStreak = CurrentBallValue == ball.Value ? CurrentStreak + 1 : 1;

            _scoreTracker.Score += _scoreTracker.GetCombo(CurrentStreak);
            
            CurrentBallValue = ball.Value;
        }
        _currentBallIsBonus = ball.IsBonus;
    }
}