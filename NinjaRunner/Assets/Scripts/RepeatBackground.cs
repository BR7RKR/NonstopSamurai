using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector2 startPos;
    private float repeatWidth;
    
    // Start is called before the first frame update
    void Start()
    {
        repeatWidth = GetComponent<BoxCollider2D>().size.x/2;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        SetToStartPosition();
    }

    private void SetToStartPosition()
    {
        if (transform.position.x < startPos.x-repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
