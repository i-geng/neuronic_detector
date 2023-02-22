using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public Sprite activatedSprite;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateGoalSprite()
    {
        spriteRenderer.sprite = activatedSprite;
    }
}
