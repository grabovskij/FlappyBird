using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Bird))]
[RequireComponent(typeof(Player))]

public class BirdMover : MonoBehaviour, IResettable
{
    [SerializeField] private float _speed = 3;
    [SerializeField] private float _tapForce = 10;
    [SerializeField] private ForceMode2D _forceMode = ForceMode2D.Impulse;
    [SerializeField] private float _rotationSpeed = 5;
    [SerializeField] private float _minAngleZ = 30;
    [SerializeField] private float _maxAngleZ = -30;
    [SerializeField] private Animator _animator;

    private Vector2 _startPosition;
    private bool _isMove;
    private Rigidbody2D _rigidbody;

    private void Update()
    {
        if (_isMove)
        {
            UpdateRotation();
        }
    }

    public void Reset()
    {
        _isMove = false;
        _rigidbody.position = _startPosition;
        _rigidbody.rotation = 0;
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.isKinematic = true;
    }

    public void Jump()
    {
        _rigidbody.velocity = new Vector2(_speed,0);
        _rigidbody.rotation = _minAngleZ;
        _rigidbody.AddForce(Vector2.up * _tapForce, _forceMode);
    }

    public void StopMove()
    {
        _rigidbody.isKinematic = true;
        _isMove = false;
        _animator.speed = 0;
        _rigidbody.velocity = new Vector2(0,0);
    }

    public void StartMove()
    {
        _rigidbody.isKinematic = false;
        _isMove = true;
        _animator.speed = 1;
        _rigidbody.velocity = new Vector2(_speed,0);
    }

    private void Start()
    {
        _startPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();
        Reset();
    }

    private void UpdateRotation()
    {
        _rigidbody.rotation = Mathf.Lerp(_rigidbody.rotation, _maxAngleZ, _rotationSpeed * Time.deltaTime);
    }
}
