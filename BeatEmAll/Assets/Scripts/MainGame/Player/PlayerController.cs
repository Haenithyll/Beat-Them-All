using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float runSpeed = 5.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    Animator anim;

    //Mouse view
    public float mouseSensitivity = 150.0f;
    public float clampAngle = 80.0f;
    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    //Health
    Text my_text;
    public float Health = 100f;
    GameObject Redfilter;

    //

    private void Awake()
    {
        my_text = GameObject.FindWithTag("Health").GetComponent<Text>();
        anim = GetComponent<Animator>();
        controller = gameObject.GetComponent<CharacterController>();
    }
    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    void Update()
    {
        //Health
        my_text.text = Health.ToString();

        if (Health <= 0 && gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            return;
        }

        //Deplacement
        ////Mouvement horiz/verti
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        bool move = false, run = false;

        if ((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) && !Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 movement = (transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal"));
            controller.Move(movement * Time.deltaTime * playerSpeed);
            move = true;
        }
        else
        {
            Vector3 movement = (transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal"));
            controller.Move(movement * Time.deltaTime * runSpeed);
            run = true;
        }
        ///Anim mouvement
        if (move)
            anim.SetBool("IsMoving", true);
        else
            anim.SetBool("IsMoving", false);


        if (run)
            anim.SetBool("IsRunning", true);
        else
            anim.SetBool("IsRunning", false);


        /// Jump
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        ///Accroupir
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            controller.height -= 1.0f;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            controller.height += 1.0f;
        }
        ///Gravity
        playerVelocity.y += gravityValue * Time.deltaTime;
        if (gameObject.activeSelf)
        {
            controller.Move(playerVelocity * Time.deltaTime);
        }
        //
        //MouseLook
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }


}
