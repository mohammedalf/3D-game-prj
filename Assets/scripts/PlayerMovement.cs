using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float gravity = 20f;

    private int instTime = 8;
    public float jump = 8f;

    CharacterController controller;

    Animator anim;

    public float rotSpeed = 80f;

    float rot = 0f;

    private float time = 0.0f;
    public int showintro = 1;
    [SerializeField] GameObject introCanvas;

    float horizontal;
    float vertical;

    Vector3 moveDirection = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // state 1
        if (showintro == 1)
        {
            Movement();

            if (time > 1)
            {
                time = 0.0f;
                showintro = 2;
            }

            time += Time.deltaTime;
        }


        // state 2
        if (showintro == 2)
        {
            introCanvas.SetActive(true);
            if (time > instTime)
            {
                time = 0.0f;
                showintro = 3;
            }

            time += Time.deltaTime;
        }

        // start the movement and set state to 3
        if (showintro == 3)
        {
            introCanvas.SetActive(false);
            Movement();
        }
    }

    private void Movement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0.0f, vertical);
            moveDirection *= speed;

            moveDirection = transform.TransformDirection(moveDirection);

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jump;
            }

            if (Input.GetKey(KeyCode.W))
            {
                anim.SetBool("IsWalking", true);
            }
            else
                anim.SetBool("IsWalking", false);


        }
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
