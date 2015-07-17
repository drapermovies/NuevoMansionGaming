//Made by Joel Draper for MansionGaming. 
using UnityEngine;
using System.Collections;

public class PlayerFunctions : MonoBehaviour {

    public bool isActive;
    public bool canJump = true;
    public bool skinOne = true;
    public bool skinTwo = false;
    public bool skin2AvBool = false;

    public float playerBool;
    public float jumpFloat;
    public float skinFloat;
    public float skin2Av;

    private int jumpHeight;
    public GameObject jumpSound;
    public GameObject charSelection2;

    public Sprite Skin1;
    public Sprite Skin2;

    public buttons button;
	public AudioManager audioM;
    public SpriteRenderer spriteRen;

    public Transform GroundCheck;
    public float GCRadius;
    public LayerMask WhatIsGround;
    private bool Grounded;

	void Start () {
        spriteRen = GetComponent<SpriteRenderer>();
        playerBool = PlayerPrefs.GetFloat("playerBool", 0);
        jumpFloat = PlayerPrefs.GetFloat("jumpFloat", 0);
        skinFloat = PlayerPrefs.GetFloat("skinFloat", 1);
        skin2Av = PlayerPrefs.GetFloat("skin2Av", 0);
        if (!isActive) { 
        GetComponent<Rigidbody2D>().gravityScale = 0; //Player floats at the beginning of the game
        }
	}

    void FixedUpdate()
    {
        Grounded = Physics2D.OverlapCircle(GroundCheck.position, GCRadius, WhatIsGround); //It checks these every frame
    }

    void Update() {
        if(skin2Av == 1)
            skin2AvBool = true;
        if (skin2Av == 0)
            skin2AvBool = false;
        if (skinFloat == 1)
        {
            skinOne = true;
            skinTwo = false;
        }
        if (skinFloat == 2)
        {
            skinOne = false;
            skinTwo = true;
        }
        if (jumpFloat == 1)
        {
            Debug.Log("player can jump");
            canJump = true;
        }
        if (jumpFloat == 0)
        {
            Debug.Log("player cannot jump");
            canJump = false;
        }
        if(playerBool == 1)
        {
            Debug.Log("PLAYER IS ACTIVE");
            isActive = true; 
			audioM.muteAudio = false;
        }
        if(playerBool == 0)
        {
            isActive = false;
            Debug.Log("PLAYER IS NOT ACTIVE");
        }

        if(!isActive)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
			audioM.muteAudio = true;
             if (Input.GetMouseButtonDown(0)){
                    if (button.paused == false)
                    {
                        playerBool = 1;
                    }
                }
          }

       if (isActive) {
              Debug.Log("Player is active");
              jumpHeight = 20;  //Player jump height
              GetComponent<Rigidbody2D>().gravityScale = 7; //On first mouse down, Player falls - Gravity Scale is scale of Gravity
              if (Grounded)
              {
                  if (canJump)
                  {
                      if (Input.GetMouseButtonDown(0))
                      {
                          Debug.Log("player has jumped");
                          GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight); //On mouse down, player jumps
                          jumpSound.GetComponent<AudioSource>().Play(); //When player jumps, play sound 
                      }
                  }
              }
              if (!Grounded)
              {
                  jumpFloat = 1;
                  canJump = false;
                  Debug.Log("player is not grounded");
                  if (Input.GetMouseButtonDown(0))
                  {
                      Debug.Log("player should not jump");
                      GetComponent<Rigidbody2D>().gravityScale = 10; //If player has already jumped, they cannot jump again 
                  }
              }
            }
       if(skinOne)
        {
            spriteRen.sprite = Skin1;
            skinFloat = 1;
        }
        if (!skin2AvBool)
            charSelection2.SetActive(false);
        if (skin2AvBool)
            charSelection2.SetActive(true);
       if(skinTwo && skin2AvBool && skin2Av == 1)
        {
            spriteRen.sprite = Skin2;
            skinFloat = 2;
        }
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("playerBool", 0);
        PlayerPrefs.SetInt("jumpFloat", 0);
        PlayerPrefs.SetFloat("skinFloat", skinFloat);
        PlayerPrefs.SetFloat("skin2Av", skin2Av);
    }
}
