using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    [SerializeField] private float _gravityMultiplier;
    [SerializeField] private float _multiplierIncrease;
    [SerializeField] private float _wallMultiplierIncrease;
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private GroundCheck _groundCheck;
    [SerializeField] private WallCheck _wallCheck;
    private bool _isReseted = true;
    private const float GRAVITY = -9.81f;
    private float _multiplierDefault;

    private void Awake()
    {
        _multiplierDefault = _gravityMultiplier;
    }

    private void FixedUpdate()
    {
        var gravity = GRAVITY * _gravityMultiplier * Vector3.up;
        _rigidBody.AddForce(gravity, ForceMode.Acceleration);
    }

    private void Update()
    {
        if(_groundCheck.IsGrounded && _isReseted)
        {
            return;
        }
        else if(_groundCheck.IsGrounded && !_isReseted)
        {
            _isReseted = true;
            _gravityMultiplier = _multiplierDefault;
        }
        else if(!_groundCheck.IsGrounded && _isReseted)
        {
            _isReseted = false;
        }
        else if(_wallCheck.IsTouching && !_groundCheck.IsGrounded)
        {
            _gravityMultiplier += _wallMultiplierIncrease;
        }
        _gravityMultiplier += _multiplierIncrease;
    }
}
