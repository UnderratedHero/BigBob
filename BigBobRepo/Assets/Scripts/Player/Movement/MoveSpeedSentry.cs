using UnityEngine;

public class MoveSpeedSentry : MonoBehaviour
{
    [SerializeField] private PlayerConfig _config;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private GroundCheck _groundCheck;
    [SerializeField] private WallCheck _wallCheck;

    private void Awake()
    {
        CurrentSpeed = _config.WalkSpeed;
    }

    public float CurrentSpeed { get; private set; }

    private void Update()
    {
        SetSpeed();
    }

    private void SetSpeed()
    { 
        if(!_groundCheck.IsGrounded || (_wallCheck.IsTouching && !_groundCheck.IsGrounded))
        {
            return;
        }    
        CurrentSpeed = _input.IsRun ? _config.RunSpeed : _config.WalkSpeed;
    }
}
