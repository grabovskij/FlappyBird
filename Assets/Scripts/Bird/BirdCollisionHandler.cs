using UnityEngine;
using UnityEngine.Events;

public class BirdCollisionHandler : MonoBehaviour
{
    [SerializeField] private BirdMover _mover;
    [SerializeField] private UnityEvent _enteredOnSafeZone;
    [SerializeField] private UnityEvent _died;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<SafeZone>(out SafeZone saveZone))
        {
            _enteredOnSafeZone.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _mover.StopMove();
        _died.Invoke();
    }
}
