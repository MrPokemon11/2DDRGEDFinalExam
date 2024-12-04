using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPiece : MonoBehaviour
{
    public static SpawnPiece spawner;
    
    GameObject fallingPiece = null;
    
    private GameObject[] piecePrefabs = new GameObject[7];
    private GameObject[] pool = new GameObject[49];
    
    ControlPiece Control = null;

    private void Awake()
    {
        if (spawner == null)
        {
            spawner = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Control = ControlPiece.instance;
        
        // these are the canonical names of the tetris pieces!
        piecePrefabs[0] = Resources.Load("Prefabs/BlueRicky") as GameObject;
        piecePrefabs[1] = Resources.Load("Prefabs/OrangeRicky") as GameObject;
        piecePrefabs[2] = Resources.Load("Prefabs/ClevelandZ") as GameObject;
        piecePrefabs[3] = Resources.Load("Prefabs/RhodeIslandZ") as GameObject;
        piecePrefabs[4] = Resources.Load("Prefabs/Hero") as GameObject;
        piecePrefabs[5] = Resources.Load("Prefabs/Teewee") as GameObject;
        piecePrefabs[6] = Resources.Load("Prefabs/Smashboy") as GameObject;

        instantiatePieces();

        SpawnNewPiece();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public SpawnPiece GetSpawner()
    {
        return spawner;
    }
    
    public void SpawnNewPiece()
    {
        int rand = Random.Range(0, pool.Count());
        fallingPiece = pool[rand];
        pool[rand] = null;
        fallingPiece.transform.position = new Vector2(0, 9);
        fallingPiece.GetComponent<Rigidbody2D>().Sleep();
        Control.NextPiece(fallingPiece);
        
    }



    void instantiatePieces()
    {
        foreach (var piece in piecePrefabs)
        {
            for (int i = 0; i < 3; i++)
            {
                pool.Append(Instantiate(piece, gameObject.transform));
            }
        }
    }
}
