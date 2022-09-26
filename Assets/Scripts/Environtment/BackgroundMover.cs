using UnityEngine;

public class BackgroundMover : MonoBehaviour, IResettable
{
    [SerializeField] private float _shift = 10;
    [SerializeField] private Transform _part1Transform;
    [SerializeField] private Transform _part2Transform;
    [SerializeField] private Transform _birdTransorm;

    private Vector3 _firstStartPosition;
    private Vector3 _secondStartPosition;

    public void Reset()
    {
         _part1Transform.position = _firstStartPosition;
         _part2Transform.position = _secondStartPosition;
    }

    private void Awake()
    {
        _firstStartPosition = _part1Transform.position;
        _secondStartPosition = _part2Transform.position;
    }

    private void LateUpdate()
    {
        if (_birdTransorm.position.x > Mathf.Max(_part1Transform.position.x, _part2Transform.position.x))
        {
            UpdatePosition();
        }
    }

    private void UpdatePosition()
    {
        if (_part1Transform.position.x > _part2Transform.position.x)
        {
            Vector3 position = _part2Transform.position;
            _part2Transform.position = new Vector3(position.x + _shift,position.y,position.z); 
        }
        else
        {
            Vector3 position = _part1Transform.position;
            _part1Transform.position = new Vector3(position.x + _shift,position.y,position.z); 
        }
    }
}
