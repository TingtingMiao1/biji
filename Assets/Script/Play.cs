using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    public GameObject sing;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPlay()
    {
        SceneManager.LoadScene("1");//要切换到的场景名
    }
    public void OnSting()
    {
        sing.SetActive(true);
    }
   
}
