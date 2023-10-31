using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedSentry : MonoBehaviour
{
    [SerializeField] private PlayerConfig _config;
    [SerializeField] private PlayerInput _input;

    public float CurrentSpeed { get; private set; }

    private void Awake()
    {
        CurrentSpeed = _config.WalkSpeed;
    }

    private void OnEnable()
    {
        _input.OnWalkMove += SpeedChange;
        _input.OnRunMove += SpeedChange;
    }

    private void OnDisable()
    {
        _input.OnWalkMove -= SpeedChange;
        _input.OnRunMove -= SpeedChange;
    }

    private void SpeedChange()
    {
        CurrentSpeed = CurrentSpeed == _config.WalkSpeed ? _config.RunSpeed : _config.WalkSpeed;
    }
}
