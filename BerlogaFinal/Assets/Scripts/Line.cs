using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Line : MonoBehaviour
{
    private Star _star1;
    private Star _star2;
    private LineRenderer _lineRenderer;
    public Action<Star, Star, GameObject> _lineDestroy;

    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();    
        var meshCollider = gameObject.AddComponent<MeshCollider>();
        Mesh mesh = new Mesh();
        _lineRenderer.BakeMesh(mesh, false);
        meshCollider.sharedMesh = mesh;
    }

    public void Init(Star star1, Star star2, Action<Star, Star, GameObject> lineDestroy)
    {
        _lineDestroy = lineDestroy;
        _star1 = star1;
        _star2 = star2;
    }

    private void OnMouseDown()
    {
        _lineDestroy?.Invoke(_star1, _star2, gameObject);
    }
}
