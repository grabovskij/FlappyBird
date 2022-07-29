using System;
using UnityEngine;

public class Tube : MonoBehaviour
{
    [SerializeField] private Transform _part1Transform;
    [SerializeField] private Transform _part2Transform;
    [SerializeField] private float _betweenSize = 10;

    private void OnEnable()
    {
        ChangePosition(_part1Transform,_betweenSize / 2);
        ChangePosition(_part2Transform,- _betweenSize / 2);
    }

    private void ChangePosition(Transform transform, float betweenSize)
    {
        Vector3 position = transform.position;
        transform.position = new Vector3(position.x,  position.y + betweenSize, position.z);
    }
}
