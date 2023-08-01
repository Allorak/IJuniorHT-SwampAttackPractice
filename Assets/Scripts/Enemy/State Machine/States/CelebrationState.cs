using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CelebrationState : State
{
    private readonly int _celebrationAnimationHash = Animator.StringToHash("Celebration");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(_celebrationAnimationHash);
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
