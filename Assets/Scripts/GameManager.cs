using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    [Header("Drag these in the inspector")]
    public TextMeshProUGUI levelCompleteText;
    public TextMeshProUGUI failsText;
    public TextMeshProUGUI coinsTextEndLevel;
    public TextMeshProUGUI coinsTextOverlay;

    public GameObject levelCompleteScreen;
    public AudioClip levelCompleteSound;
    public Image gameOverScreen;
    public AudioClip gameOverSound;

    public GameObject player;

    private int totalCoins = 10;
    [Space(20)]
    public int coinsCollected;
    public int fails;
    public bool isLevelOver;

    //public MoveFloor moveFloorScript;
    //public float floorSpeedUp = 0.25f;
    ///For matching color of the player to the answers in puzzel
    public enum colorAnswers { Cyan, Orange, Yellow };
    public Item heldItem;
    // Start is called before the first frame update
    void Start()
    {
        // moveFloorScript=FindObjectOfType<MoveFloor>();
    }

    // Update is called once per frame
    void Update()
    {

        //moveFloor.speed += floorSpeedUp * Time.deltaTime ;
    }

    public void completeLevel()
    {
        //This bool will stop the world and player from moving
        isLevelOver = true;
        player.GetComponent<AudioSource>().PlayOneShot(levelCompleteSound);
        levelCompleteScreen.SetActive(true);
    }

    public void addFail()
    {
        fails++;
        //Increase the floor speed when giving a false answer
        //moveFloorScript.speed++;
        failsText.text = "Fails: " + fails;
;    }
    public void addCoin()
    {
        coinsCollected++;
        coinsTextEndLevel.text = "Coins: " + coinsCollected+"/"+totalCoins;
        coinsTextOverlay.text = ""+coinsCollected;


    }
    public void setGameOver()
    {
        isLevelOver = true;
        player.GetComponent<AudioSource>().PlayOneShot(gameOverSound);
        gameOverScreen.gameObject.SetActive(true);
    }
    public void pause()
    {
        Time.timeScale = 0;

    }
    public void unpause()
    {
        Time.timeScale = 1;

    }

    public void equipItem(Item item)
    {
        if (heldItem!= null)
        {
            heldItem.gameObject.SetActive(true);
        }

        item.gameObject.SetActive(false);
        heldItem = item;
        Material Player_Material = player.GetComponent<Renderer>().material;
        Player_Material.color = item.gameObject.GetComponent<Renderer>().material.color;
    }
}
