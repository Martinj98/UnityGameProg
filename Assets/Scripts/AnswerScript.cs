using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    private Button button;
    private TextMeshProUGUI text;

    public PuzzelScript puzzel;

    public string answer;
    public bool hasAnswerBeenGiven=false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<Button>();
        button = GetComponentInChildren<Button>();
        button.onClick.AddListener(ButtonClick);
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ButtonClick()
    {
        if (!hasAnswerBeenGiven&&!puzzel.processingAnswer)
        {
            hasAnswerBeenGiven = true;
            //Give answer and return boolean based on wheter it was correct or not
            bool isCorrect = puzzel.GiveAnswer(answer);
            if (isCorrect)
            {
                Debug.Log("goed answer");
                text.color = Color.green;
            }
            else
            {
                Debug.Log("fout answer");
                text.color = Color.red;
            }
        }
    }
}
