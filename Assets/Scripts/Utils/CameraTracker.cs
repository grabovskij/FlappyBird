using System;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private float _xOffset = 3;
    [SerializeField] private float _zOffset = -5;
    private void LateUpdate()
    {
        transform.position = new Vector3(_bird.transform.position.x + _xOffset,transform.position.y, _zOffset);
    }
}
