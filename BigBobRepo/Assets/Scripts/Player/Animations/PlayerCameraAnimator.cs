using UnityEngine;
using System;

public class PlayerCameraAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public event Action OnJumpAnimationOver;

    public void PlayJump()
    {
        _animator.SetTrigger("setJump");
    }

    public void PlayIdle()
    {
        _animator.SetTrigger("setIdle");
    }

    public void PlayWalkFromIdle()
    {
        _animator.SetTrigger("setWalkFromIdle");
    }

    public void PlayWalkFromJump()
    {
        _animator.SetTrigger("setWalkFromJump");
    }

    private void Handle_JumpAnimationOver()
    {
        OnJumpAnimationOver?.Invoke();
    }
}
