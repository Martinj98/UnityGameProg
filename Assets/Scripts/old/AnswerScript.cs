using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class AnswerScript : MonoBehaviour
{
    /*
     DEPRECATED
     THIS SCRIPT IS CURRENTLY NOT IN USE
         SCRIPT COULD BE USED FOR CLICKING ON THE ANSWER 
         */


    private Button button;
    public Image crossImage;
    private TextMeshProUGUI text;

    public PuzzelScript puzzel;
    private Color color;
    //public string answer;
    public bool hasAnswerBeenGiven=false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<Button>();
        button = GetComponentInChildren<Button>();
       // button.onClick.AddListener(ButtonClick);
        text = GetComponent<TextMeshProUGUI>();
        color = text.color;
    }

    // Update is called once per frame
    void Update()
    {

    }
    //void ButtonClick()
    //{
    //    if (!hasAnswerBeenGiven&&!puzzel.processingAnswer)
    //    {
    //        hasAnswerBeenGiven = true;
    //        //Give answer and return boolean based on wheter it was correct or not
    //        bool isCorrect = puzzel.GiveAnswer(answer,color);
    //        if (isCorrect)
    //        {
    //            Debug.Log("goed answer");
    //            text.color = Color.green;
    //        }
    //        else
    //        {
    //            Debug.Log("fout answer");
    //            crossImage.gameObject.SetActive(true);
    //          //text.color = Color.red;
    //        }
    //    }
    //}
}
