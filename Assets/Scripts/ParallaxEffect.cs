using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private Vector3 startPos;
    [SerializeField] PlayerMovement playermovement;

    void Start()
    {
        startPos = transform.position;
    }


    void Update()
    {
        transform.Translate(translation: Vector3.down * playermovement.yScrollSpeed * Time.deltaTime);

        if(transform.position.y < -18.86)
        {
            transform.position = startPos;
        }
    }
}
