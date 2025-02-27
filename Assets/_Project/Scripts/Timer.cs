using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    private float _secondsRemaining;
    [SerializeField] private TMP_Text _text;
    public static Action OnTimerComplete;
    private Coroutine _timerCoroutine;

    void Start()
    {
        StartTimer(60);
    }

    public void StartTimer(float startTime)
    {
        _secondsRemaining = startTime;
        _timerCoroutine = StartCoroutine(UpdateTimer());
    }
    
    public IEnumerator UpdateTimer()
    {
        while (_secondsRemaining > 0)
        {
            _secondsRemaining -= Time.deltaTime;
            int minutes = (int)(_secondsRemaining / 60);
            int seconds = (int)(_secondsRemaining % 60);
            _text.text = $"{minutes}:{seconds}";
            yield return null;
        }

        OnTimerComplete?.Invoke();
    }
}
