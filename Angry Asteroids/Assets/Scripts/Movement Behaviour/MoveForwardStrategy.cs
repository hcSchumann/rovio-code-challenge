using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardStrategy : MovementStrategy
{
    private Vector3 _moveDirection;
    public MoveForwardStrategy(Transform self)
    {
        Self = self;
        _moveDirection = new Vector3(Random.value, Random.value, 0).normalized;
        Self.right = _moveDirection;
    }

    public override Vector3 GetMoveDirection()
    {
        return _moveDirection;
    }
}
