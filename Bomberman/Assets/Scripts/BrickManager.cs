using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    [SerializeField] GameObject winDoor;
    [SerializeField] GameObject[] brickList;
    Vector2 winDoorposition;
    public int brickWinDoor;

    void Start()
    {
        brickWinDoor = UnityEngine.Random.Range(1, brickList.Length);
        winDoorposition = brickList[brickWinDoor].transform.position;
        Instantiate(winDoor, winDoorposition, Quaternion.identity);
    }
}
