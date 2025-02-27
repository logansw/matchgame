using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public static ScoreTracker s_Instance;
    private int[] _comboScores;
    private float _score;
    public float Score
    {
        get
        {
            return _score;
        }
        set
        {
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
        _comboScores = new int[] {10, 15, 25, 40, 60, 85, 115, 150};
    }
    public float GetCombo(int streak)
    {
        if (streak - 1 >= _comboScores.Length)
        {
            streak = _comboScores.Length;
        }

        return _comboScores[streak - 1];
    }
}