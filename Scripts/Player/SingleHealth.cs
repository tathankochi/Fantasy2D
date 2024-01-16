using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleHealth : MonoBehaviour
{
    //Singleton Pattern start
    public static SingleHealth Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //Singleton Pattern end
}
