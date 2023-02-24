using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    public int terminalType;

    private List<Object> connectedObjects;

    // Start is called before the first frame update
    void Start()
    {
        connectedObjects = new List<Object>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        connectedObjects.Add(collision.gameObject);

        GameObject g = collision.gameObject;
        if (g.CompareTag("Terminal")) {
            if (g.GetComponent<Terminal>().terminalType != terminalType) {
                LevelManager.Instance.incrementConnections();
            }
        }

        bool immuneuron = g.CompareTag("Immuneuron");
        // Problem here. The dendrite can pass immune power to the receptor, which is backwards.
        bool passedImmunity = g.CompareTag("Terminal") && g.GetComponentInParent<Neuron>().IsImmuneConnected;
        if (immuneuron || passedImmunity) {
            GetComponentInParent<Neuron>().ActivateImmuneConnection();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        connectedObjects.Remove(collision.gameObject);
        GameObject g = collision.gameObject;
        if (g.CompareTag("Terminal")) {
            if (g.GetComponent<Terminal>().terminalType != terminalType) {
                LevelManager.Instance.decrementConnections();
            }
        }

        bool immuneuron = g.CompareTag("Immuneuron");
        bool passedImmunity = g.CompareTag("Terminal") && g.GetComponentInParent<Neuron>().IsImmuneConnected;
        if (immuneuron || passedImmunity) {
            GetComponentInParent<Neuron>().DeactivateImmuneConnection();
        }
    }
}
