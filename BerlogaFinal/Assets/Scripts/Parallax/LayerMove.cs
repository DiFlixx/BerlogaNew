using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerMove : MonoBehaviour
{
    public UnityEngine.GameObject cam;
    float startPosX;
    public float Parallax;

    void Start()
    {
        startPosX = transform.position.x;
    }

    void Update()
    {
        float distX = cam.transform.position.x * (1 - Parallax);

        transform.position = new Vector3(startPosX - distX, transform.position.y, transform.position.z);
    }
}
