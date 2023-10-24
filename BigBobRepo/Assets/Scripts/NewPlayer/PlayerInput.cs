using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private string _jumpButton;
    [SerializeField] private string _horizontalMoveButtons;
    [SerializeField] private string _verticalMoveButtons;

    public event Action OnJumpPressed;

    public Vector3 MoveDirection { get; private set; }

    private void Update()
    {
        if (Input.GetButtonDown(_jumpButton))
        {
            OnJumpPressed?.Invoke();
        }

        MoveDirection = new Vector3(Input.GetAxis(_verticalMoveButtons), 0, Input.GetAxis(_horizontalMoveButtons));
    }

}
