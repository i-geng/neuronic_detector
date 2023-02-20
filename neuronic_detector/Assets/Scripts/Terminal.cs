using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    public int terminalType;
    private bool isConnected;
    

    // Start is called before the first frame update
    void Start()
    {
        isConnected = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject g = collision.gameObject;
        if (g.CompareTag("Terminal")) {
            if (g.GetComponent<Terminal>().terminalType != terminalType) {
                g.GetComponent<Terminal>().isConnected = true;
                isConnected = true;
                LevelManager.Instance.incrementConnections();
            }
        }
    }
}
