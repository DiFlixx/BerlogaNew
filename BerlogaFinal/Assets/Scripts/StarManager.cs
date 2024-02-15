using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    [SerializeField]
    private LineRenderer _linePrefab;
    private bool _isBinding;
    private LineRenderer _line;
    private Star _star;
    private bool _shouldDestroy;
    private HashSet<Star> _starList;

    private void Start()
    {
        _starList = new HashSet<Star>();
    }

    public void HandleBinding(Star star)
    {
        _shouldDestroy = false;
        if (_isBinding)
        {
            _isBinding = false;
            if (star.ConnectStars(_star)) 
            {
                _line.SetPosition(1, star.transform.position);
                _starList.Add(star);
                _starList.Add(_star);
                Line line = _line.AddComponent<Line>();
                line.Init(star, _star, BreakConnection);
                Debug.Log(line._lineDestroy);
                Check();
            }
            else
            {
                Destroy(_line.gameObject);
            }
        }
        else
        {
            _isBinding = true;
            LineRenderer line = Instantiate(_linePrefab);
            line.SetPosition(0, star.transform.position);
            _line = line;
            _star = star;
        }
    }

    private void BreakConnection(Star star1, Star star2)
    {
        _starList.Remove(star1);
        _starList.Remove(star2);
        star1.BreakConnection(star2);
        star2.BreakConnection(star1);
    }

    private void Check()
    {
        foreach(Star star in _starList)
        {
            if (!star.CheckConnections()) return;
            
        }
        Debug.Log("Созвездие готово");
    } 

    void Update()
    {
        if (_isBinding)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            _line.SetPosition(1, pos);
            if (_shouldDestroy)
            {
                _shouldDestroy=false;
            }
            if (Input.GetMouseButtonDown(1))
            {
                _shouldDestroy = true;
                Destroy(_line.gameObject);
                _isBinding = false;
            }
        }
    }
}
