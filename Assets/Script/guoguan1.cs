using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class guoguan1 : MonoBehaviour
{
    public AudioClip guoguanyinxiao;
    public Image pa2;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.name == "Player")
        {       
            AudioSource.PlayClipAtPoint(guoguanyinxiao, transform.localPosition);            
        }

    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
