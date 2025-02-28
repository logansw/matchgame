using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _panels;
    
    void OnEnable()
    {
        Timer.OnTimerComplete += SetGameOver;
    }

    void OnDisable()
    {
        Timer.OnTimerComplete -= SetGameOver;
    }

    private void SetGameOver()
    {
        SetActivePanel(1);
    }

    public void SetActivePanel(int index)
    {
        foreach (GameObject panel in _panels)
        {
            panel.SetActive(false);
        }
        _panels[index].SetActive(true);
    }
}
