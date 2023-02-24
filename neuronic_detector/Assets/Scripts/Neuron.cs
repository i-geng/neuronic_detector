using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neuron : MonoBehaviour
{
    private bool isImmuneConnected;

    public bool IsImmuneConnected { get => isImmuneConnected;}
    // Start is called before the first frame update
    void Start()
    {
        isImmuneConnected = false;
    }

    private void OnMouseDown()
    {
        StartCoroutine(RotateNeuron());
    }

    public IEnumerator RotateNeuron()
    {
        for (int i = 0; i < 18; i++) {
            transform.rotation *= Quaternion.Euler(0f, 0f, 5);
            yield return new WaitForSeconds(0f);
        }
    }

    public void ActivateImmuneConnection()
    {
        isImmuneConnected = true;
        // Go through connected children and activate their immune connections.
    }

    public void DeactivateImmuneConnection()
    {
        isImmuneConnected = false;
        // Go through connected children and deactivate their immune connections.
    }
}
