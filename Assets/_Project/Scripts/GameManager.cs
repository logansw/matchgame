using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameSettings GameSettings;
    public static GameManager s_Instance;
    
    void Awake()
    {
        if (s_Instance != null)
        {
            Destroy(s_Instance.gameObject);
        }
        s_Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void CreateNewGameSettings(float time)
    {
        GameSettings = new GameSettings(time);
    }
}
