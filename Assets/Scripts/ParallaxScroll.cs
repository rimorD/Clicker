using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        // new position
        transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);

        // Check if were out of bounds (since were only moving in one direction we dont need to check both directions)
        if (transform.position.x >= startPosition + length)
        {
            transform.position = new Vector3(startPosition, transform.position.y, transform.position.z);
        }
    }

    // Data ///////////////////////////////////////////////////////////////////////////////////////
    public float length;
    public float startPosition;
    public float speed;
}
