using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffFactory : MonoBehaviour, IFactory
{
    [SerializeField]
    public GameObject[] buffPrefab;

    public GameObject FactoryMethod(int tag)
    {
        GameObject buff = Instantiate(buffPrefab[tag]);
        return buff;
    }
}
