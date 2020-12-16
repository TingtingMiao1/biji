using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class qiehuanbaoliu : MonoBehaviour
{
    public GameObject effectToPlay; //Particle effect you want to play
    public Transform objectToAnimate; //The game object you want to animate
    public GameObject Player;
    public GameObject can;
    //public Vector3 z;
    //void Awake()
    //{
    //    z = new Vector3(0, 2, 0);
    //    DontDestroyOnLoad(this);
    //    //DontDestroyOnLoad(cu);
    //    SceneManager.LoadScene(2);
    //    this.transform.position = z;

    //}

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //做碰撞或触发检测时执行
    //void OnTriggerEnter(Collider collision)
    //{
    //    if (collision.gameObject.tag == "guoguan")
    //    {
    //        StartCoroutine(PlayEffect());
    //        SavePos(0, 2, 0);
    //    }
    //    //effectToPlay.SetActive (true);//要显示的传送效果没有可不写
       
    //}
   
    //保存主角当前位置
    void SavePos(float posX, float posY, float posZ)
    {
        PlayerPrefs.SetFloat("PosX", posX);
        PlayerPrefs.SetFloat("PosY", posY);
        PlayerPrefs.SetFloat("PosZ", posZ);
    }
    //读取主角的位置
    void LoadPos()
    {
        float x = PlayerPrefs.GetFloat("PosX");
        float y = PlayerPrefs.GetFloat("PosY");
        float z = PlayerPrefs.GetFloat("PosZ");
        transform.localPosition = new Vector3(x, y, z);
    }
}
