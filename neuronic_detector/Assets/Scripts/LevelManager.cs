using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;

    public static LevelManager Instance { get { return _instance; } }

    #region levelInfo
    public int totalConnections;    // Total connections required for level.
    public int currConnections;     // Current number of connections.
    private GameObject[] goals;     // A list of goals, in case there are multiple goals in a level.
    public GameObject nextLevelButton;
    public int levelNumber;         // The tutorial level is Level0.
    #endregion

    private void Awake()
    {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

        currConnections = 0;
        goals = GameObject.FindGameObjectsWithTag("Goal");
        nextLevelButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void incrementConnections()
    {
        currConnections += 1;
        checkCompletion();
    }

    public void decrementConnections()
    {
        currConnections -= 1;
    }

    private void checkCompletion()
    {
        if (currConnections >= totalConnections) {
            foreach (GameObject g in goals) {
                g.GetComponent<Goal>().activateGoalSprite();
            }
            nextLevelButton.SetActive(true);
        }
    }

    public void goToNextLevel()
    {
        Debug.Log("go to next level");
        GameObject gm = GameObject.FindWithTag("GameController");

        if (levelNumber < gm.GetComponent<GameManager>().GetFinalLevel()) {
            string sceneName = "Level" + (levelNumber + 1);
            gm.GetComponent<GameManager>().StartLevel(sceneName);
        } else {
            gm.GetComponent<GameManager>().EndGame();
        }
        
    }
}
