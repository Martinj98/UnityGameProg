using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class colorChanger : MonoBehaviour
{
    private Color startColor;
    public float changeTicks= 100f;
    public float timeBetweenTicks = 0.01f;
    public bool isChanging;

    public void changeColor(Color newColor) {
        //dif = (Time.time - startTime) *lerpSpeed;

        StartCoroutine(updateColor(newColor));
    }

    public IEnumerator updateColor(Color newColor) {
        startColor = GetComponent<Renderer>().material.color;
        isChanging = true;
        int i = 0;
        float percentage=0.1f * i;
        while (percentage < 1)
        {
            GetComponent<Renderer>().material.color = Color.Lerp(startColor, newColor, percentage);
            i++;
            //changeTicks determines how many times to loop //care! if 0 this is an infinite loop
            percentage=(1f /changeTicks) * i;
            yield return new WaitForSeconds(timeBetweenTicks);
        }
        isChanging = false;
    }
    public void disableGameobject() {
        Color currentCol= GetComponent<Renderer>().material.color;
        Color newc = new Color(currentCol.r+1, currentCol.g, currentCol.b);
        newc.a =0;

        StartCoroutine(updateColor(newc));
    }

}
