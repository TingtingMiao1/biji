using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class guoguan : MonoBehaviour
{
    public AudioClip guoguanyinxiao;
    public string senceName;
    public Image pa;
    //public GameObject Play;    //（在Inspector拖入人物组件）
    public GameObject canv;
    //public GameObject Sky;
    public GameObject rukou1;
    [SerializeField] private string newpw;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.name == "Player")
        {
                pa.transform.position = new Vector3(960, 550, 0);
            pengzhuang.instance.pw = newpw;
            AudioSource.PlayClipAtPoint(guoguanyinxiao, transform.localPosition);
            
            //DontDestroyOnLoad(Sky);//防止人物在切换场景的时候被销
            //pa.SetActive(false);
        }

    }
        // Update is called once per frame
        void Update()
    {
        
    }
    public void Xiayiguan()
    {
        pa.transform.position = new Vector3(-960, -550, 0);
        SceneManager.LoadScene(senceName);//要切换到的场景名
        DontDestroyOnLoad(canv);//防止人物在切换场景的时候被销
    }
    public void Chongxinkaishi()
    {
        pa.transform.position = new Vector3(-960, -550, 0);
        SceneManager.LoadScene("0");//要切换到的场景名

    }
}
