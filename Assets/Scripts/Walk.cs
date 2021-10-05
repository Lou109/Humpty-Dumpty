using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public float speed = 5f;
    bool switc = true;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (switc)
        {
            movehorseright();
        }
        if (!switc)
        {
            movehorseleft();
        }
        if (transform.position.x >= 20f)
        {
            switc = false;
            spriteRenderer.flipX = true;
        }
        if (transform.position.x <= -5f)
        {
            switc = true;
            spriteRenderer.flipX = false;
        }
    }

    void movehorseright()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
    void movehorseleft()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}