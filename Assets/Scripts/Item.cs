using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //public string itemAnswer;
    [HideInInspector]public Color color; //PuzzleObjects change into this color
    public GameManager.colorAnswers itemAnswer;//PuzzleScript checks if this is the right/wrong answer
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        color = GetComponent<Renderer>().material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.equipItem(this);
        }
    }
}
