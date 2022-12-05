using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCompartment : MonoBehaviour
{
    public GameObject placePrefabObject;
    public Transform barrelEnd;


    public void TakeObjects(GameObject takeObject)
    {
        GameObject.FindGameObjectWithTag("Items").GetComponent<InventoryDisplay>().gmObjects.Add(takeObject);
    }  
    public void TakeItems(Item takeItem)
    {
        GameObject.FindGameObjectWithTag("Items").GetComponent<toDisplayInventory>().Items.Add(takeItem);
    }   
  
}
