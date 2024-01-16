using System;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private string _collisionTag;
    private int _collisions;
    public bool IsGrounded { get; private set; }

    private void Start()
    {
        _collisions = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_collisionTag))
        {
            _collisions++;
            IsGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(_collisionTag))
        {
            _collisions--;

            if (_collisions == 0)
            {
                IsGrounded = false;
            }
        }
    }

}
