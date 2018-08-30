using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRemoveCommandReceiver  {

    public void MoveOperation(GameObject gameObjectToMove, Direction direction, float distance)
    {
        switch (direction)
        {
            case Direction.UP:
                MoveY(gameObjectToMove, +distance);
                break;
            case Direction.DOWN:
                MoveY(gameObjectToMove, -distance);
                break;
            case Direction.RIGHT:
                MoveX(gameObjectToMove, +distance);
                break;
            case Direction.LEFT:
                MoveX(gameObjectToMove, -distance);
                break;
        }
    }

    private void MoveY(GameObject gameObject,float distance)
    {
        Vector3 newpos = gameObject.transform.position;
        newpos.y += distance;
        gameObject.transform.position = newpos;
    }

    private void MoveX(GameObject gameObject, float distance)
    {
        Vector3 newpos = gameObject.transform.position;
        newpos.x+= distance;
        gameObject.transform.position = newpos;
    }
}
