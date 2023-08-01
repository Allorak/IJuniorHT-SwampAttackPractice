using System;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _first;

    private Player _target;
    private State _current;

    public State Current => _current;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        Reset(_first);
    }

    private void Update()
    {
        if (_current == null)
            return;

        var nextState = _current.GetNextState();
        if (nextState != null)
            Transit(nextState);
    }

    private void Reset(State startState)
    {
        _current = startState;

        if (_current != null)
            _current.Enter(_target);
    }

    private void Transit(State nextState)
    {
        if(_current != null)
            _current.Exit();

        _current = nextState;

        if(_current != null)
            _current.Enter(_target);
    }
}
