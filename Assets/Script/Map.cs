using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public GameObject map;
    public GameObject kaiguan;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Mapfangda()
    {
            map.transform.localScale = new Vector3(2f, 2f, 2f);
            map.transform.position =new Vector3  (1720, 880, 0);
        kaiguan.SetActive(true);
    }
    public void Maphuanyuan()
    {

        map.transform.localScale = new Vector3(1f, 1f, 1f);
        map.transform.position = new Vector3(1820, 980, 0);
        kaiguan.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
