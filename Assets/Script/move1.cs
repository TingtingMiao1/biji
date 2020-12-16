using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move1 : MonoBehaviour 
{
    public float speed = 16.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
   
    // Start is called before the first frame update
    void Start()
    {    
    }
    // Update is called once per frame
    void Update()
    {
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
}
