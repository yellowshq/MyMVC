using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    UP,DOWN,RIGHT,LEFT
}

public class MyRemoveCommand : IRCommand {

    private Direction moveDirection;
    private MyRemoveCommandReceiver commandReceiver;
    private GameObject target;
    private float distance;

    public MyRemoveCommand(MyRemoveCommandReceiver commandReceiver, Direction dicretion,GameObject target,float distance)
    {
        this.commandReceiver = commandReceiver;
        this.moveDirection = dicretion;
        this.target = target;
        this.distance = distance;
    }

    public void Execute()
    {
        commandReceiver.MoveOperation(target, moveDirection, distance);
    }

    public void UnExecute()
    {
        commandReceiver.MoveOperation(target, InverseDirection(moveDirection), distance);
    }

    private Direction InverseDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.UP:
                return Direction.DOWN;
            case Direction.DOWN:
                return Direction.UP;
            case Direction.RIGHT:
                return Direction.LEFT;
            case Direction.LEFT:
                return Direction.RIGHT;
            default:
                Debug.LogError("Unknown MoveDirection");
                return Direction.UP;
        }
    }
}
