using System;
using UnityEngine;

public abstract class MovementStrategy
{
    public Transform Self;
    public Transform Target;

    public abstract Vector3 GetMoveDirection();
}
