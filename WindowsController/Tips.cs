using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tips : MonoBehaviour
{
    
    public void CloseTips(GameObject windowTip)
    {
        Destroy(windowTip);
    }
    public void CloseWindow(GameObject TipsWindow)
    {
        TipsWindow.SetActive(false);
    }
    void Update()
    {
        
    }
}
