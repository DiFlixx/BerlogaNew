using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float _smoothness;
    private Transform _playerTransform;

    void Update()
    {
        Vector3 targetPosition = new Vector3(_playerTransform.position.x, _playerTransform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * _smoothness);
    }

    public void SetTarget(Transform t)
    {
        _playerTransform = t;
    }
}
