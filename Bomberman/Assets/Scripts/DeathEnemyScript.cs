using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManagerScript.instance.PlaySound(3);
        Destroy(gameObject,0.5f);
    }
}
