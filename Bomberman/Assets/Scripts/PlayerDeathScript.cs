using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour
{
    public float playerDeathTime = 1f;

    private void Start()
    {
        Destroy(gameObject, playerDeathTime);
    }
}
