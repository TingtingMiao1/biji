using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tijiaoshujv : MonoBehaviour
{
    public Text textdefen;
    private InputField _name;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textdefen.text = " "+pengzhuang.Score;
      //  _nameField =  GameObject.Find("/Canvas/NameInputField").GetComponent<InputField>();
    }
}
