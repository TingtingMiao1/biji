using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Audio : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip audioClip;
    bool isbool = true;
    public GameObject xing;
     bool ison=true ;
    bool iss=true ;
    public GameObject yinliang;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameMssage.i = audioSource.volume;

    }
    /// <summary>
    /// 播放音乐
    /// </summary>
    // Update is called once per frame
    public void PlayAudioClip()
    {
        if (isbool)
        {
            audioClip = Resources.Load<AudioClip>("Music/game");
            audioSource.clip = audioClip;
            audioSource.Play();
            yinliang.SetActive(true);
        }
        if(!isbool)
        {
            audioSource.Stop();
            yinliang.SetActive(false );
        }
        isbool = !isbool;
        Debug.Log(isbool);
    }
    public void OnPlayAudioClip()
    {
        if (ison)
        {
            xing.transform.position = new Vector3(150, 500, 100); 
        }
        if (!ison)
        {
            xing.transform.position = new Vector3(-500, -500, -500); 

        }
        ison = !ison;
        Debug.Log(isbool);
    }
    public void PlayShengYin()
    {
        if (iss)
        {
            yinliang.transform.position = new Vector3(1800, 650, 100);
        }
        if (!iss)
        {
            yinliang.transform.position = new Vector3(-100, 500, 100);
        }
        iss = !iss;
        Debug.Log(isbool);
    }

    void Update()
    {

        audioSource.volume =GameMssage .i ;
    }
   
}
