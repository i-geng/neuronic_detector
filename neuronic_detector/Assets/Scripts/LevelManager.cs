using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;

    public static LevelManager Instance { get { return _instance; } }

    private bool isComplete;
    List<Neuron> neurons = new List<Neuron>();
    public int totalConnections;
    public int currConnections;
    private GameObject[] goals;

    private void Awake()
    {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

        isComplete = false;
        currConnections = 0;
        goals = GameObject.FindGameObjectsWithTag("Goal");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addNeuron(Neuron n)
    {
        neurons.Add(n);
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
                g.GetComponent<Goal>().changeSprite();
            }
        }
    }
}
