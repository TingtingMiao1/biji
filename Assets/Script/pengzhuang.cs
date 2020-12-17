using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class pengzhuang : MonoBehaviour
{
    public float speed = 16.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public static pengzhuang instance;
    public AudioClip jinbiyinxiao;
 
    public static int Score = 0;
    public Text jinbi;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else
        {
            if(instance != null)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
    [SerializeField ]
    public string pw;
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
       
    }
   
    // Update is called once per frame
    void Update()
    {
        jinbi.text = "" + Score;
        PlayerPrefs.SetInt("indexM", Score );
        CharacterController controller = GetComponent<CharacterController>();
        float h = Input.GetAxis("Horizontal");
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        transform.Rotate(transform.up * h * Time.deltaTime * 100);
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }
 //IEnumerator PlayEffect()
    //{

    //    yield return new WaitForSeconds(1.0f); //等待6S后切换界面

    //}
   
}
