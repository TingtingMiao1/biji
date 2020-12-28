using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class guoguan1 : MonoBehaviour
{
    public AudioClip guoguanyinxiao;
    public GameObject pal;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.name == "Player")
        {
           
            AudioSource.PlayClipAtPoint(guoguanyinxiao, transform.localPosition);
            pal.SetActive(true);
          
            // scoreList.Add(new Score(Name, numScore));//分数名字直接调变量，不用给出细节

        }

    }
    public void Xiayiguan()
    {
        SceneManager.LoadSceneAsync ("3");//要切换到的场景名
      

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
