using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickButton : MonoBehaviour
{
    private GameObject _controller;
    [SerializeField] private UnityEngine.GameObject target;

    void Start()
    {
    }

    public void Create()
    {
        _controller = FindAnyObjectByType<GameObject>();
        Instantiate(target.gameObject, _controller.transform.position + new Vector3(0, 1.6f, 0), Quaternion.identity);
    }
}
