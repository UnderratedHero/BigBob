using UnityEngine;

public class WallCheck : MonoBehaviour
{
    [SerializeField] private string _collisionTag;
    private int _collisions;

    public bool IsTouching { get; private set; }

    private void Start()
    {
        _collisions = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_collisionTag))
        {
            _collisions++;
            IsTouching = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(_collisionTag))
        {
            _collisions--;

            if (_collisions == 0)
            {
                IsTouching = false;
            }
        }
    }
}
