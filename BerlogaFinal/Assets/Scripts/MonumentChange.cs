using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonumentChange : MonoBehaviour
{
    [SerializeField] private GameObject[] _monuments;

    static int index = 0;


    private bool _entered;

    private void Update()
    {
        if (_entered)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                MoveRight();
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                MoveLeft();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _entered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _entered = false;
        }
    }

    private void MoveLeft()
    {
        if (index == 0)
        {
            _monuments[index].SetActive(false);
            index = 3;
            _monuments[index].SetActive(true);
        }
        else
        {
            _monuments[index].SetActive(false);
            index--;
            _monuments[index].SetActive(true); 
        }
    }

    private void MoveRight()
    {
        if (index != 3)
        {
            _monuments[index].SetActive(false);
            index++;
            _monuments[index].SetActive(true);
        }
        else
        {
            _monuments[index].SetActive(false);
            index = 0;
            _monuments[index].SetActive(true);
        }
    }
}