using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DummyController : MonoBehaviour
{

    private CharacterController Dummycontroller;
    private Vector3 playerVelocity;

    private bool groundedPlayer;
    public float playerSpeed = 1.0f;
    private float gravityValue = -9.81f;

    bool move = false;
    GameObject character;

    Animator anim;
    //Health    
    bool isTouched = false;
    Image Redfilter;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        Dummycontroller = gameObject.GetComponent<CharacterController>();
    }
    void Start()
    {
        Redfilter = GameObject.FindWithTag("Red_filter").GetComponent<Image>();
        move = true;
        character = GameObject.FindWithTag("Character");
    }



    void Update()
    {

        groundedPlayer = Dummycontroller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (character.activeSelf)
        {
            Vector3 movement = character.transform.position - transform.position;
            movement.y = 0;
            Quaternion rotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = rotation;

            Dummycontroller.Move(movement * Time.deltaTime * playerSpeed);
        }
        else{
            move=false;
        }




        if (move)
            anim.SetBool("IsMoving", true);
        else
            anim.SetBool("IsMoving", false);


        playerVelocity.y += gravityValue * Time.deltaTime;
        Dummycontroller.Move(playerVelocity * Time.deltaTime);


    }

    void OnControllerColliderHit(ControllerColliderHit other)
    {
        if (other.gameObject.tag == "Character" && isTouched == false)
        {
            other.gameObject.GetComponent<CharactereController>().Health -= 10f;
            isTouched = true;
            Redfilter.color = new Color(Redfilter.color.r, Redfilter.color.g, Redfilter.color.b, 0.5f);
            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        isTouched = false;
        Redfilter.color = new Color(Redfilter.color.r, Redfilter.color.g, Redfilter.color.b, 0f);
    }
}
