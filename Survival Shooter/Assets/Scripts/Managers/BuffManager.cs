using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float spawnTime = 15f;
    public Transform[] spawnPoints;

    [SerializeField]
    MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }


    void Start()
    {
        InvokeRepeating("BuffSpawn", spawnTime, spawnTime);
    }


    void BuffSpawn()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        //Mendapatkan nilai random
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int spawnBuff = Random.Range(0, 2);

        //Memduplikasi enemy
        Factory.FactoryMethod(spawnBuff);
    }
}
