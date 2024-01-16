using UnityEngine;

public class PlayerCameraMove : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private PlayerConfig _config;
    [SerializeField] private PlayerInput _input;
    private Vector2 _velocity;
    private Vector2 _frameVelocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Calculation();
        Move();
    }

    private void Calculation()
    {
        var mouseDelta = _input.MouseMoveDirection;
        var rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * _config.MouseSensivity);
        _frameVelocity = Vector2.Lerp(_frameVelocity, rawFrameVelocity, 1 / _config.CameraSmooth);
        _velocity += _frameVelocity;
        _velocity.y = Mathf.Clamp(_velocity.y, -90, 90);
    }

    private void Move()
    {
        transform.localRotation = Quaternion.AngleAxis(-_velocity.y, Vector3.right);
        _player.localRotation = Quaternion.AngleAxis(_velocity.x, Vector3.up);
    }
}