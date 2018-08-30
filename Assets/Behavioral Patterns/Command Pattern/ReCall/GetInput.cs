using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInput : MonoBehaviour
{

    public GameObject moveObject;
    private MyRemoveCommandReceiver removeCommandReceiver;

    public float distance = 1;

    List<IRCommand> rCommands;
    int currentNum=0;
    void Start()
    {
        removeCommandReceiver = new MyRemoveCommandReceiver();
        rCommands = new List<IRCommand>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveUp();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            MoveDown();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
    }

    public void MoveUp() { Move(Direction.UP); }
    public void MoveDown() { Move(Direction.DOWN); }
    public void MoveRight() { Move(Direction.RIGHT); }
    public void MoveLeft() { Move(Direction.LEFT); }

    private void Move(Direction direction)
    {
        MyRemoveCommand removeCommand = new MyRemoveCommand(removeCommandReceiver, direction, moveObject, distance);
        removeCommand.Execute();
        rCommands.Add(removeCommand);
        currentNum++;
    }

    public void Undo()
    {
        if (currentNum > 0)
        {
            currentNum--;
            MyRemoveCommand removeCommand = (MyRemoveCommand)rCommands[currentNum];
            removeCommand.UnExecute();
        }
    }

    public void Redo()
    {
        if (currentNum < rCommands.Count)
        {
            MyRemoveCommand removeCommand = (MyRemoveCommand)rCommands[currentNum];
            currentNum++;
            removeCommand.Execute();

        }
    }
}
