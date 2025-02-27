using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameSettings GameSettings;

    public void CreateNewGameSettings(float time)
    {
        GameSettings = new GameSettings(time);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }
}
