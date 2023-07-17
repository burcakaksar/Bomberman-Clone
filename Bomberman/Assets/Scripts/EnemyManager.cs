using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] EnemyList;
    public GameObject[] EnemyListEasy;
    public GameObject[] EnemyListHard;

    #region Singletion
    public static EnemyManager instance;
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
    #endregion 

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        EnemyListEasy = GameObject.FindGameObjectsWithTag("Enemy");
        EnemyListHard = GameObject.FindGameObjectsWithTag("EnemyHard");
        EnemyList = EnemyListEasy.Union(EnemyListHard).ToArray();

    }
}
