using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// 按照时间销毁

public class DestoryOnTime : MonoBehaviour {
    public float desTime = 10f;
	// Use this for initialization
	void Start () {
        Invoke("Dead", desTime);
	}
	
	// Update is called once per frame
	void Dead () {

        //销毁自身
        Destroy(gameObject);
	}
}
