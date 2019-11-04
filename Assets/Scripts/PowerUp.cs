using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private PlayerController playerController;
    public float rotateSpeed = 180f;

    public float speedbonus = 5.0f;
    public float bonusTime = 3;
    private GameManager gameManager;
    public AudioClip pickupSound;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        gameManager = gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = new Vector3(rotateSpeed*Time.deltaTime,0,0);
        transform.Rotate(rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.movespeed += speedbonus;
            playerController.GetComponent<AudioSource>().PlayOneShot(pickupSound);
            //StartCoroutine(resetPlayerSpeed());
            gameManager.addCoin();
            gameObject.SetActive(false);
        }
    }
    //private IEnumerator resetPlayerSpeed()
    //{
    //    yield return new WaitForSeconds(bonusTime);
    //    playerController.movespeed -= speedbonus;
    //}
}
