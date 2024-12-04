using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ICommand : MonoBehaviour
{
    public abstract void Execute(GameObject target);
}

public class RotateCW : ICommand
{
    public override void Execute(GameObject target)
    {
        target.transform.rotation *= new Quaternion(0,0,-90,0);
    }
}

public class RotateCCW : ICommand
{
    public override void Execute(GameObject target)
    {
        target.transform.rotation *= new Quaternion(0,0,90,0);
    }
}

public class MoveDown : ICommand
{
    public override void Execute(GameObject target)
    {
        target.transform.position = new Vector2(target.transform.position.x, target.transform.position.y-1);
    }
}

public class MoveLeft : ICommand
{
    public override void Execute(GameObject target)
    {
        target.transform.position = new Vector2(target.transform.position.x-1, target.transform.position.y);
    }
}

public class MoveRight : ICommand
{
    public override void Execute(GameObject target)
    {
        target.transform.position = new Vector2(target.transform.position.x+1, target.transform.position.y);
    }
}