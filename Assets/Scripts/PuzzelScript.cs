using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PuzzelScript : MonoBehaviour
{
    public GameManager gameManager;

    public Image puzzelScreen;
    public string puzzelAnswer;

    public bool processingAnswer = false;
    public bool isSolved;
    //public int fails = 0;
    public GameObject door;
   // public GameObject bonusDoor;
    public AudioSource audioSource;
    public AudioClip failSound;
    public AudioClip correctSound;
    public ParticleSystem explosionParticle;

    public float waitTimeAfterCorrect=2.0f;
    public float waitTimeAfterWrong=4.0f;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isSolved&&other.CompareTag("Player"))
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
    public bool GiveAnswer(string givenAnswer)
    {
        processingAnswer = true;
        Debug.Log("Answer Given" + givenAnswer);
        if (puzzelAnswer == givenAnswer)
        {
            isSolved = true;
            StartCoroutine(ProccesRightAnswer());
            return true;
        }
        else
        {
            StartCoroutine(ProccesWrongAnswer());
            gameManager.addFail();
            return false;
        }

    }

    private IEnumerator  ProccesWrongAnswer()
    {

        audioSource.PlayOneShot(failSound);
        explosionParticle.Play();
        yield return new WaitForSeconds(waitTimeAfterWrong);
        processingAnswer = false;


    }
    private IEnumerator ProccesRightAnswer()
    {
        audioSource.PlayOneShot(correctSound);
        yield return new WaitForSeconds(waitTimeAfterCorrect);
        processingAnswer = false;
        endPuzzel();
    }
    public void endPuzzel()
    {
        //disables puzzel screen
        puzzelScreen.gameObject.SetActive(false);
        //Opens door
        door.SetActive(false);
        //if (fails == 0)
        //{
        //    bonusDoor.gameObject.SetActive(false);
        //}

    }
}
