using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public SlotItem Itembutton;

    [SerializeField]
    private bool _isFood;
    [SerializeField]
    private int _index;

    private Inventory _inventory;
    private bool _isPicking;
    private bool _entered;

    protected abstract Action GetAction();
        
    void Start()
    {
        _inventory = FindAnyObjectByType<Inventory>();
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<RobotHelper>(out var robot) && _isFood)
        {
            for (int i = 0; i < _inventory.slots.Length; i++)
            {
                if (_inventory.slots[i].IsFull == false)
                {
                    robot.FoodPicked();
                    _inventory.slots[i].IsFull = true;
                    Instantiate(Itembutton, _inventory.slots[i].transform, false).Init(_inventory.slots[i], GetAction());
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

    private void Update()
    {
        if (_entered && Input.GetKey(KeyCode.E) && !_isPicking)
        {
            _isPicking = true;
            for (int i = 0; i < _inventory.slots.Length; i++)
            {
                if (_inventory.slots[i].IsFull == false)
                {
                    _inventory.slots[i].IsFull = true;
                    _inventory.slots[i].SetIndex(_index);
                    Instantiate(Itembutton, _inventory.slots[i].transform, false).Init(_inventory.slots[i], GetAction());
                    Destroy(gameObject);
                    break;
                }
            }
            _isPicking = false;
        }
    }
}
