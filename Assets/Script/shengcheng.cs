using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shengcheng : MonoBehaviour
{
    public GameObject [] obj;
    public Transform[] SpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPoint", 1, 1);
        Invoke("cancelInvoke", SpawnPoints .Length+1);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void cancelInvoke()
    {
        CancelInvoke();
    }
    void SpawnPoint()
    {
        int SpawnIndex = Random.Range(0, SpawnPoints.Length);
        Instantiate(obj[0], SpawnPoints[SpawnIndex].position, SpawnPoints[SpawnIndex].rotation);
    }
}
