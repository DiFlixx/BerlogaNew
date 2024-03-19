using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float _smoothness;
    private Transform _playerTransform;
    private Transform _previousTarget;

    void Update()
    {
        Vector3 targetPosition = new Vector3(_playerTransform.position.x, _playerTransform.position.y + 1f, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * _smoothness);
    }

    public void SetTargetInstant(Transform t)
    {
        _playerTransform = t;
        Vector3 targetPosition = new Vector3(_playerTransform.position.x, _playerTransform.position.y + 1f, transform.position.z);
        transform.position = targetPosition;
    }

    public void SetTarget(Transform t)
    {
        _playerTransform = t;
        _previousTarget = _playerTransform;
    }

    public void ReturnToPlayer()
    {
        _playerTransform = _previousTarget;
        Vector3 targetPosition = new Vector3(_playerTransform.position.x, _playerTransform.position.y + 1f, transform.position.z);
        transform.position = targetPosition;
    }
}
