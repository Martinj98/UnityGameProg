using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{ 
    
    public TextMeshProUGUI levelCompleteText;
    public TextMeshProUGUI failsText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI coinsText2;

    public GameObject levelCompleteScreen;
    public AudioClip levelCompleteSound;
    public Image gameOverScreen;
    public AudioClip gameOverSound;


    private int totalCoins = 10;
    public bool isLevelOver;
    public int fails;
    public int coinsCollected;
 
    
    public MoveFloor moveFloor;
    public PlayerController playerController;
    public AudioSource playerAudioSource;
    public float floorSpeedUp = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        moveFloor=FindObjectOfType<MoveFloor>();
        playerController = FindObjectOfType<PlayerController>();
        playerAudioSource = playerController.GetComponent<AudioSource>();
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
        playerAudioSource.PlayOneShot(levelCompleteSound);
        levelCompleteScreen.SetActive(true);
    }

    public void addFail()
    {
        fails++;
        //Increase the floor speed when giving a false answer
        moveFloor.speed++;
        failsText.text = "Fails: " + fails;
;    }
    public void addCoin()
    {
        coinsCollected++;
        coinsText.text = "Coins: " + coinsCollected+"/"+totalCoins;
        coinsText2.text = ""+coinsCollected;


    }
    public void setGameOver()
    {
        isLevelOver = true;
        playerAudioSource.PlayOneShot(gameOverSound);
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
}
