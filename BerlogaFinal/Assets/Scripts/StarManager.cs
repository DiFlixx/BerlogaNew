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
    private int _connetionsLeft;

    [SerializeField]
    private Transform _lineParent;
    [SerializeField]
    private TextMeshProUGUI _text;
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
        if (ConnectionsCompleted()) return;
        _shouldDestroy = false;
        if (_isBinding)
        {
            _line.SetPosition(1, star.transform.position);
            _starList.Add(star);
            _isBinding = false;
            _starList.Add(_star);
            _connetionsLeft -= 1;
            _star.ConnectStars(star);
            if (ConnectionsCompleted())
            {
                if (Check())
                {
                    _starsConnected?.Invoke();
                }
                else
                {
                    Restart();
                }
            }
            else
            {
                HandleBinding(star);
            }
        }
        else
        {
            _isBinding = true;
            LineRenderer line = Instantiate(_linePrefab, _lineParent);
            line.SetPosition(0, star.transform.position);
            _line = line;
            _star = star;
        }
        _text.text = "Connections left:" + _connetionsLeft;
    }

    private void BreakConnection(Star star1, Star star2, GameObject obj)
    {
        if (!IsOverStar && !_isBinding && !ConnectionsCompleted())
        {
            Destroy(obj);
            _starList.Remove(star1);
            _starList.Remove(star2);
            star1.BreakConnection(star2);
            star2.BreakConnection(star1);
        }
    }

    private bool ConnectionsCompleted()
    {
        return _connetionsLeft <= 0;
    }

    private bool Check()
    {
        foreach (Star star in _starList)
        {
            if (!star.CheckConnections()) return false;
        }
        return true;
    } 

    private void Restart()
    {
        _connetionsLeft = _starConnectionCount;
        foreach (Star star in _starList)
        {
            star.BreakConnections();
        }
        foreach (Transform line in _lineParent)
        {
            Destroy(line.gameObject);
        }
        _text.text = "Connections left:" + _connetionsLeft;
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
                _isBinding = false;
                Restart();
            }
        }
    }
}
