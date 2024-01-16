using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimationControl : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GroundCheck _groundCheck;
    [SerializeField] private float _lifeTime;
}
