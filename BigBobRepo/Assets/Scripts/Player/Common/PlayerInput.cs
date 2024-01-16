using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private string _jumpButton;
    [SerializeField] private string _horizontalMoveButtons;
    [SerializeField] private string _verticalMoveButtons;
    [SerializeField] private string _runButton;
    [SerializeField] private string _horizontalMouse;
    [SerializeField] private string _verticalMouse;

    public event Action OnJumpPressed;

    public bool IsRun { get; private set; }
    public bool IsWalk { get; private set; }
    public Vector3 MoveDirection { get; private set; }
    public Vector2 MouseMoveDirection { get; private set; }

    private void Update()
    {
        MouseMoveDirection = new Vector2(Input.GetAxisRaw(_horizontalMouse), Input.GetAxisRaw(_verticalMouse));
        MoveDirection = new Vector3(Input.GetAxis(_horizontalMoveButtons), 0, Input.GetAxis(_verticalMoveButtons));

        if (MoveDirection != Vector3.zero)
        {
            IsWalk = true;
        }
        else
        {
            IsWalk = false;
        }

        if (Input.GetButtonDown(_jumpButton))
        {
            OnJumpPressed?.Invoke();
        }

        if (Input.GetButton(_runButton) && IsWalk)
        {
            IsRun = true;
            IsWalk = false;
        }
        else
        {
            IsWalk = true;
            IsRun = false;
        }
    }
}
