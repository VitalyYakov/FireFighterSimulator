using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;

public class PumpScrpt : MonoBehaviour
{

    // The class responsible for checking whether the car is standing on a water source or not


    public CheckBar chb; 

    public bool takeWater = false;
    

    void Start()
    {
       
    }
    void Update()
    {
        // if(Input.GetMouseButtonDown(0))
        // {
        //     UnityStandardAssets.Effects.Hose.UseProtec();
        // }
        if (takeWater && Input.GetKey("p"))
        {
           StartCoroutine( FullWater());
        }
    }
    IEnumerator FullWater()
    {
        for(int i=0; i<=100; i++)
        {
            yield return new WaitForSeconds(0.1f);
            chb.AdjustCurrentValue(25);
        }
    }
    // Methods of checking whether the car is in the trigger or out of it
    private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "TakeWater")
        {
            Debug.Log("Take Water");
            takeWater = true;
        }
        
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.tag == "TakeWater")
        {
            Debug.Log("Take Water");
            takeWater = false;
        }
        }
}
