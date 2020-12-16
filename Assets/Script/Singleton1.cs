using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton1 
{
    private static Singleton1 instance;
    private Singleton1()
    {
          Singleton1 GetSingleton()
        {
            if (instance == null)
            {
                instance = new Singleton1();
            }return instance ;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
