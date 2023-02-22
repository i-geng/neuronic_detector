using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neuron : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

}
