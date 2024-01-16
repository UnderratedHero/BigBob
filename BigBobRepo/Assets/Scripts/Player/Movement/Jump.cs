using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private PlayerConfig _config;
    [SerializeField] private GroundCheck _groundCheck;
    [SerializeField] private float _jumpMultiplier;

    private void OnEnable()
    {
        _input.OnJumpPressed += PlayerJump;
    }

    private void OnDisable()
    {
        _input.OnJumpPressed -= PlayerJump;
    }

    private void PlayerJump()
    {
        if (!_groundCheck.IsGrounded)
        {
            return;
        }
        _rigidBody.AddForce(_config.JumpSpeed * Vector3.up * _jumpMultiplier, ForceMode.Impulse);
    }
}
