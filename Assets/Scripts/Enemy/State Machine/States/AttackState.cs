using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private readonly int _attackAnimationHash = Animator.StringToHash("Attack");

    private Animator _animator;
    private float _lastAttackTime;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _lastAttackTime -= Time.deltaTime;

        if (_lastAttackTime > 0)
            return;

        Attack(Target);
        _lastAttackTime = _delay;
    }

    private void Attack(Player target)
    {
        _animator.Play(_attackAnimationHash);
        target.ApplyDamage(_damage);
    }
}
