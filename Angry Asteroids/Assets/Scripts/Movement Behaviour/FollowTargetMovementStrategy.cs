using UnityEngine;

public class FollowTargetMovementStrategy : MovementStrategy
{
    public override Vector3 GetMoveDirection()
    {
        if (Target == null) return Vector3.zero;

        var target2DPosition = new Vector2(Target.position.x, Target.position.y);
        var self2DPosition = new Vector2(Self.position.x, Self.position.y);
        var newDirection2DVector = target2DPosition - self2DPosition;
        Self.right = new Vector3(newDirection2DVector.x, newDirection2DVector.y, 0).normalized;
        
        return Self.right;
    }
}
