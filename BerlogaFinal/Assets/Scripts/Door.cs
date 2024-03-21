using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Sprite _sprite;

    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;
    private CircleCollider2D _circleCollider;
    private Inventory _inventory;

    void Start()
    {
        _inventory = FindAnyObjectByType<Inventory>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _circleCollider = GetComponent<CircleCollider2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Check() 
    {
        for (int i = 0; i < _inventory.slots.Length; i++)
        {
            if (_inventory.slots[i].GetIndex() == 5)
            {
                Open();   
            }
        }
    }

    private void Open()
    {
        for (int i = 0; i < _inventory.slots.Length; i++)
        {
            if (_inventory.slots[i].GetIndex() == 5)
            {
                _inventory.slots[i].MakeSlotEmpty();
            }
        }
        _spriteRenderer.sprite = _sprite;
        _circleCollider.enabled = false;
        _boxCollider.enabled = false;
        transform.position += new Vector3(-1f, 0.3f, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Check();
        }
    }
}
