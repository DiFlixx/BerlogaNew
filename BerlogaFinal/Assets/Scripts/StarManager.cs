using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class StarManager : MonoBehaviour
{
    public bool IsOverStar;
    
    private bool _isBinding;
    private LineRenderer _line;
    private Star _star;
    private bool _shouldDestroy;
    private HashSet<Star> _starList;
    private bool _starConnectionCompleted;
    private int _connetionsLeft;

    [SerializeField]
    private int _starConnectionCount;
    [SerializeField]
    private LineRenderer _linePrefab;
    [SerializeField]
    private UnityEvent _starsConnected;

    private void Start()
    {
        _starList = new HashSet<Star>();
        _connetionsLeft = _starConnectionCount;
    }

    public void HandleBinding(Star star)
    {
        if (_starConnectionCompleted) return;
        _shouldDestroy = false;
        if (_isBinding)
        {
            _isBinding = false;
            _line.SetPosition(1, star.transform.position);
            _starList.Add(star);
            _starList.Add(_star);
            Line line = _line.AddComponent<Line>();
            line.Init(star, _star, BreakConnection);
            _connetionsLeft -= 1;
            if (_connetionsLeft == 0)
            {
                Check();
            }
            HandleBinding(star);
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

    private void BreakConnection(Star star1, Star star2, GameObject obj)
    {
        if (!IsOverStar && !_isBinding && !_starConnectionCompleted)
        {
            Destroy(obj);
            _starList.Remove(star1);
            _starList.Remove(star2);
            star1.BreakConnection(star2);
            star2.BreakConnection(star1);
        }
    }

    private bool Check()
    {
        foreach(Star star in _starList)
        {
            if (!star.CheckConnections()) return false;
            
        }
        _starConnectionCompleted = true;
        _starsConnected?.Invoke();
        return true;
    } 

    private void Restart()
    {
        foreach (Star star in _starList)
        {
            star.BreakConnections();
        }
        foreach (Line line in FindObjectsOfType<Line>())
        {
            Destroy(line.gameObject);
        }
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
