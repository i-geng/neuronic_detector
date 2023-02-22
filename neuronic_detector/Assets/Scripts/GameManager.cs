using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    [SerializeField] private int finalLevelNumber;

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        } else if (Instance != this) {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level0");
    }

    public int GetFinalLevel()
    {
        return finalLevelNumber;
    }

    public void StartLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
