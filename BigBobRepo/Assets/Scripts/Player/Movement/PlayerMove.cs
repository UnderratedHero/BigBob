using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private PlayerConfig _config;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private MoveSpeedSentry _speedSentry;
    [SerializeField] private WallCheck _wallCheck;
    [SerializeField] private GroundCheck _groundCheck;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(_wallCheck.IsTouching && !_groundCheck.IsGrounded)
        {
            return;
        }
        var forwardVelocity = _input.MoveDirection.x * _speedSentry.CurrentSpeed;
        var sideVelocity = _input.MoveDirection.z * _speedSentry.CurrentSpeed;
        _rigidBody.velocity = transform.rotation * new Vector3(forwardVelocity, _rigidBody.velocity.y, sideVelocity);
    }
}
