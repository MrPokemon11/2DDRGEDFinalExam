using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class ControlPiece : MonoBehaviour
{
    //singleton
    public static ControlPiece instance = null;
    
    private ICommand buttonA = new MoveLeft();
    private ICommand buttonD = new MoveRight();
    private ICommand buttonW = new RotateCW();
    private ICommand buttonS = new RotateCCW();
    private ICommand gravity = new MoveDown();

    private GameObject currentPiece = null;

    private float pieceSpeed = 1;
    private bool fall = true;
    
    SpawnPiece piecespawner = null;

    private float timer;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        piecespawner = SpawnPiece.spawner;
        timer = Time.time;
    }

    public static ControlPiece getInstance()
    {
        return instance;
    }

    public void NextPiece(GameObject piece)
    {
        currentPiece.GetComponent<Rigidbody2D>().WakeUp();
        reverseRotation();
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

            if (Input.GetKey(KeyCode.D))
            {
                buttonD.Execute(currentPiece);
            }

            if (Input.GetKey(KeyCode.W))
            {
                buttonW.Execute(currentPiece);
            }

            if (Input.GetKey(KeyCode.S))
            {
                buttonS.Execute(currentPiece);
            }
        }

        if (fall)
        {
            pieceGravity();
        }

        if (timer + Time.time > 1800)
        {
            piecespawner.SpawnNewPiece();
            timer = Time.time;
        }
    }



    void reverseRotation()
    {
        ICommand swapControls = null;
            swapControls = buttonW;
            buttonW = buttonS;
            buttonS = swapControls;
    }

    IEnumerable<WaitForSeconds> pieceGravity()
    {
        fall = false;
        gravity.Execute(currentPiece);
        yield return new WaitForSeconds(1/pieceSpeed);
        fall = true;
    }
}
