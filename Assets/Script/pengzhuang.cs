using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class pengzhuang : MonoBehaviour
{
    public AudioClip jinbiyinxiao ;
    public AudioClip guoguanyinxiao ;
    public static int Score = 0;
    public Text jinbi;
    public GameObject pa;
    public GameObject Play;    //（在Inspector拖入人物组件）
    public GameObject canv;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    { 
        if (collision.gameObject .tag == "Cell" )
        {
            AudioSource.PlayClipAtPoint(jinbiyinxiao, transform.localPosition);

            caomei1 caomei = collision.gameObject.GetComponent<caomei1>();
            caomei.Death();  
        }
        if (collision.gameObject.name == "guoguantiaojian")
        {
            AudioSource.PlayClipAtPoint(guoguanyinxiao, transform.localPosition);
            
            pa.SetActive(true);

            StartCoroutine(PlayEffect());
            SavePos(0, 2, 0);
           
        }
        
        
    }
   
    // Update is called once per frame
    void Update()
    {
        jinbi.text = "" + Score;
       
    }
    IEnumerator PlayEffect()
    {
        Debug.Log("111");
        yield return new WaitForSeconds(1.0f); //等待6S后切换界面
        SceneManager.LoadScene(2);//需要切换的界面
        DontDestroyOnLoad(Play);//防止人物在切换场景的时候被销毁
        DontDestroyOnLoad(canv);//防止人物在切换场景的时候被销
        pa.SetActive(false );
    }
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
