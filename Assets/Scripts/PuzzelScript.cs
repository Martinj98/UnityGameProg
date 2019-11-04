using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PuzzelScript : MonoBehaviour
{
    public PlayerController playerController;
    public GameManager gameManager;
    public AudioSource audioSource;

    public AudioClip failSound;
    public AudioClip correctSound;
    public ParticleSystem explosionParticle;

    public Image puzzelScreen;
    public GameManager.colorAnswers puzzelAnswer;

    public bool processingAnswer = false;
    public bool isSolved;

    public GameObject puzzelPaal;
    public GameObject puzzelFloor;
    public GameObject puzzelDoor;

 //   public float waitTimeAfterCorrect = 2.0f;
    public float waitTimeAfterWrong = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioSource = GetComponent<AudioSource>();
        playerController = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        if (puzzelScreen.gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E) && !processingAnswer)
            {
                if (gameManager.heldItem != null)
                {
                    GiveAnswer(gameManager.heldItem);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isSolved && other.CompareTag("Player"))
        {
            puzzelScreen.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puzzelScreen.gameObject.SetActive(false);
        }
    }
    public bool GiveAnswer(Item givenItem)
    {
        processingAnswer = true;
        if (puzzelAnswer == givenItem.itemAnswer)
        {
            StartCoroutine(ProccesRightAnswer(givenItem.color));
            return true;
        }
        else
        {
            StartCoroutine(ProccesWrongAnswer());
            return false;
        }
    }

    private IEnumerator ProccesWrongAnswer()
    {
        gameManager.addFail();
        audioSource.PlayOneShot(failSound);
        explosionParticle.Play();
        yield return new WaitForSeconds(waitTimeAfterWrong);
        processingAnswer = false;

    }
    private IEnumerator ProccesRightAnswer(Color givenCol)
    {
        isSolved = true;
        audioSource.PlayOneShot(correctSound);
   
        GameObject[] puzzelObjects= { puzzelPaal,puzzelFloor,puzzelDoor };
        //Change the color of each object 
        foreach (GameObject puzzelobject in puzzelObjects)
        {
            StartCoroutine(puzzelobject.GetComponent<colorChanger>().updateColor(givenCol));
            while (puzzelobject.GetComponent<colorChanger>().isChanging)
            {
                yield return new WaitForSeconds(0.01f);
            }
        }
        //disable the door so the player can progress
        puzzelDoor.GetComponent<colorChanger>().disableGameobject();
        while (puzzelDoor.GetComponent<colorChanger>().isChanging)
        {
            yield return new WaitForSeconds(0.01f);
        }
        puzzelDoor.SetActive(false);
        puzzelScreen.gameObject.SetActive(false);
        processingAnswer = false;
    }
}
