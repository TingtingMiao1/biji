using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rukou : MonoBehaviour
{
 
    public string rukoupw;
    // Start is called before the first frame update
    void Start()
    {
    
     if(pengzhuang .instance .pw ==rukoupw )
        {
            pengzhuang.instance.transform.position = transform.position;
            
          
        } else
        {

        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
