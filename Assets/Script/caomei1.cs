using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caomei1 : MonoBehaviour
{
    //public  AudioSource deathAudio;
    //public   void Start()
    //{
    //    //deathAudio = GetComponent<AudioSource>();
    //}
    
    public void Death()
    {
        //deathAudio.Play  ();
        pengzhuang.Score += 5;
        Destroy(gameObject);
    }
}
