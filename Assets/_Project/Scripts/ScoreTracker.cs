using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public static ScoreTracker s_Instance;
    private int[] _comboScores;
    private int[] _bonusScores;
    private float _score;
    public float Score
    {
        get
        {
            return _score;
        }
        set
        {
            Debug.Log($"+{value - _score}");
            _score = value;
            _scoreText.text = _score.ToString();
        }
    }
    [SerializeField] private TMP_Text _scoreText;

    void Awake()
    {
        if (s_Instance != null)
        {
            Destroy(s_Instance.gameObject);
        }
        s_Instance = this;
    }

    void Start()
    {
        _comboScores = new int[] {10, 30, 50, 75, 100, 125, 150};
        _bonusScores = new int[] {5, 15, 25, 40, 60, 85, 120};
    }
    public float GetCombo(int streak)
    {
        if (streak - 1 >= _comboScores.Length)
        {
            streak = _comboScores.Length;
        }

        return _comboScores[streak - 1];
    }

    public float GetBonus(int streak)
    {
        if (streak - 1 >= _bonusScores.Length)
        {
            streak = _bonusScores.Length;
        }

        return _bonusScores[streak-1];
    }
}