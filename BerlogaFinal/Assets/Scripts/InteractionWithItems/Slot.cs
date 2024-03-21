using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public bool IsFull = false;
    
    [SerializeField] 
    int slotIndex = 0;

    private int _itemIndex = 0;
    private Inventory _inventory;

    private void Start()
    {
        _inventory = GetComponent<Inventory>();
    }

    public void MakeSlotEmpty()
    {
        foreach (Transform child in transform)
        {
            UnityEngine.GameObject.Destroy(child.gameObject);
            IsFull = false;
            _itemIndex = 0;
        }
    }

    public void DropItem()
    {
        MakeSlotEmpty();
    }

    public void SetIndex(int index)
    {
        _itemIndex = index;
    }

    public int GetIndex()
    {
        return _itemIndex;
    }
}
