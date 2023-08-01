using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float _speed;

    private void Update()
    {
        float currentSpeed = _speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, currentSpeed);
    }
}
