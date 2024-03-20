using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;

public class FirstStep : MonoBehaviour
{
    public UnityEngine.GameObject String;
    public UnityEngine.GameObject Plank;
    public UnityEngine.GameObject Stick;
    public UnityEngine.GameObject Bow;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("string")) 
        {
            Bow.transform.position = collision.otherCollider.gameObject.transform.position;
            Stick.transform.position = new Vector2(-5, 1.2f);
            Plank.transform.position = new Vector2(7, 1.2f);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
