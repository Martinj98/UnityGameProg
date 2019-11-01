using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 spawnPos;
    public float defaultmovespeed;
    public float movespeed;
    public float jumpforce;
    public CharacterController controller;
    private Vector3 movedirection;
    public float gravityScale;

    public GameManager gameManager;
    // public GameObject cameraObject;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        controller = GetComponent<CharacterController>();
        //cameraObject = GameObject.Find("Main Camera");
    }
    // Update is called once per frame
    void Update()
    {
        //only Let the player move if the level isnt completed yet
        if (!gameManager.isLevelOver)
        {
            var oldY = movedirection.y;
            // movedirection = new Vector3(Input.GetAxis("Horizontal") * movespeed, movedirection.y, Input.GetAxis("Vertical") * movespeed);
            movedirection = (transform.forward * Input.GetAxisRaw("Vertical")) +
                (transform.right * Input.GetAxisRaw("Horizontal"));
            movedirection = movedirection * movespeed;

            movedirection.y = oldY;
            //Stop 
            if (controller.isGrounded)
            {
                //reset forces pulling down when we are on the ground
                movedirection.y = 0f;
                if (Input.GetButtonDown("Jump"))
                {
                    movedirection.y = jumpforce;
                }

            }
            //Applying gravity and moving the charactercontroller
            movedirection.y += Physics.gravity.y * gravityScale * Time.deltaTime;//TODO time deltatime
            controller.Move(movedirection * Time.deltaTime);

            //If the player is falling below 0 reset
            if (!controller.isGrounded && transform.position.y < -20)
            {
               // resetPlayer();
                gameManager.setGameOver();
            }
        }
    }

    //private void resetPlayer()
    //{
    // //   transform.position = spawnPos;
    //}
}
