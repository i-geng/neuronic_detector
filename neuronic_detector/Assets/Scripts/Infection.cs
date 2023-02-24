using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infection : MonoBehaviour
{
    #region Infection Clearing Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Infection entered trigger.");
        GameObject g = collision.gameObject;
        bool cleared = g.CompareTag("Terminal") 
            && g.GetComponent<Terminal>().terminalType == 1
            && g.GetComponent<Terminal>().GetComponentInParent<Neuron>().IsImmuneConnected;
        
        if (cleared) {
            // Deactivate the infection.
            gameObject.SetActive(false);
            
            // Increment the number of connections.
            LevelManager.Instance.incrementConnections();
        }
    }
    #endregion
}
