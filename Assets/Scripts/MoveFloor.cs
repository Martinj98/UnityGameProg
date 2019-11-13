using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SceneController;

public class MoveFloor : MonoBehaviour
{
    public float speed = 0;
    //Right now difficult is approx:2supereasy-3medium 4-hard 5-extreme 
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Debug.Log(StaticClass.CrossSceneInformation+" = SELECTED Difficulty number");
        speed = StaticClass.CrossSceneInformation;
    }

    // Update is called once per frame
    void Update()
    {
        //Move the floor as long as the level isnt over
        if (!gameManager.isLevelOver)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
     
    }
}
