using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Star : MonoBehaviour
{
    private StarManager starManager;
    private HashSet<Star> _stars;
    [SerializeField]
    private Star[] _rightStars;
    private HashSet<Star> _rightStarsSet;

    private void Start()
    {
        _rightStarsSet = new HashSet<Star>(_rightStars);  
        starManager = FindObjectOfType<StarManager>();
        _stars = new HashSet<Star>();
    }

    private void OnMouseDown()
    {
        starManager.HandleBinding(this);
    }

    private void OnMouseOver()
    {
        starManager.IsOverStar = true;
    }

    private void OnMouseExit()
    {
        starManager.IsOverStar = false;
    }

    public bool ConnectStars(Star star)
    {
        return ConnectStar(star) && star.ConnectStar(this);
    }

    public void BreakConnection(Star star)
    {
        _stars.Remove(star);
    }

    public void BreakConnections()
    {
        _stars.Clear();
    }

    private bool ConnectStar(Star star) 
    {
        if (_stars.Contains(star))
        {
            return false;
        }
        else
        {
            _stars.Add(star);
            return true;
        }
    }

    public bool CheckConnections()
    {
        Debug.Log(_stars.SetEquals(_rightStarsSet) + " " + name + " " + _stars.Count);
        foreach (Star star in _stars)
        {
            Debug.Log(star.name);
        }
        return _stars.SetEquals(_rightStarsSet);
    }
}
