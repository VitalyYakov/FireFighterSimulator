using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointDebug : MonoBehaviour{
    public bool inExit = true;
    public Text podText;
    public Text radius;
    public GameObject Point;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Object enter");
            inExit = false;
            StopAllCoroutines();
            StartCoroutine(showTextCoroutine());
            

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Object exit");
            inExit = true;
            Object.Destroy(Point);
            Text.Destroy(radius);
            Text.Destroy(podText);
        }
    }

    IEnumerator showTextCoroutine()
{
    Color textColor = radius.color;
    Color textColor2 = podText.color;
    textColor.a = 1;
    textColor2.a = 1;
    radius.color = textColor;
    podText.color = textColor2;
 
    float hideTime = 2f; 
    float timer = hideTime;
 
    while (timer > 0)
    {
        timer -= Time.deltaTime;
 
        textColor.a = (1f / hideTime) * timer;
        textColor2.a = (1f / hideTime) * timer;
        radius.color = textColor;
        podText.color = textColor2;
 
        yield return null;
    }
}
}
