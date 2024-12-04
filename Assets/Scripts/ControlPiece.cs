using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPiece : MonoBehaviour
{
    
    private ICommand buttonA = new MoveLeft();
    private ICommand buttonD = new MoveRight();
    private ICommand buttonW = new RotateCW();
    private ICommand buttonS = new RotateCCW();

    private GameObject currentPiece = null;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NextPiece(GameObject piece)
    {
        currentPiece = piece;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (currentPiece != null)
        {
            if (Input.GetKey(KeyCode.A))
            {
                buttonA.Execute(currentPiece);
            }
        }

    }

    void reverseRotation()
    {
        ICommand swapControls = null;
            swapControls = buttonW;
            buttonW = buttonS;
            buttonS = swapControls;
    }
}
