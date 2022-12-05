using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryDisplay : MonoBehaviour
{
    
    public GameObject ch1, ch2, ch3, ch4,ItemObject;


    public Transform barrelEnd;

    public GameObject Tips;
    public GameObject childList;
    public GameObject hope;

    private InteractionWithObjects iteraction;
    private toDisplayInventory dis;
    int numberElement;

    private int choiceInventoryObject;

    
    [SerializeField] public List<GameObject> gmObjects = new List<GameObject>();



    void Start() {
            ch1.SetActive(false);
            ch2.SetActive(false);
            ch3.SetActive(false);
            ch4.SetActive(false);
    }
    void Update ()
    {
        
        // FindHope();

        Choice();
        switch(choiceInventoryObject)
        {
            case 1 :
            ch1.SetActive(true);
            ch2.SetActive(false);
            ch3.SetActive(false);
            ch4.SetActive(false);
            
            
            
            break;
            case 2 :
            ch1.SetActive(false);
            ch2.SetActive(true);
            ch3.SetActive(false);
            ch4.SetActive(false);
            break;
            case 3 :
            ch1.SetActive(false);
            ch2.SetActive(false);
            ch3.SetActive(true);
            ch4.SetActive(false);
            break;
            case 4 :
            ch1.SetActive(false);
            ch2.SetActive(false);
            ch3.SetActive(false);
            ch4.SetActive(true);
            break;
            default :
            break;

        }

        FindHope();

    }
    void FindHope()
    {
        if(gmObjects[0]==hope)
        {
            numberElement=1;
            Debug.Log(numberElement);
        }
        else if(gmObjects[1] == hope)
        {
            numberElement=2;
            Debug.Log(numberElement);
        }
         else if(gmObjects[2]== hope)
        {
            numberElement=3;
            Debug.Log(numberElement);
        }
         else if(gmObjects[3] == hope)
        {
            numberElement=4;
            Debug.Log("NumberElement "+numberElement);
        }
        // for(int i=0;i<=4;i++)
        // {
        //     bool findHope = gmObjects.Find(obj=> obj.name == hope.name);
        //     if(findHope)
        //     {
        //         numberElement=i;
        //         Debug.Log(numberElement);
        //     }
        // }

    }
    void Choice()
        {
        if (Input.GetKey("1"))
        {
            if (numberElement==1)
            {
                choiceInventoryObject = 1;
            Debug.Log(choiceInventoryObject);
            TransRelieve(childList);
            GameObject objectRes = Instantiate(gmObjects[0],barrelEnd.position,barrelEnd.rotation) as GameObject;
            gmObjects.RemoveAt(0);
            Tips.SetActive(true);
            numberElement=0;
            }else{
            choiceInventoryObject = 1;
            Debug.Log(choiceInventoryObject);
            TransRelieve(childList);
            GameObject objectRes = Instantiate(gmObjects[0],barrelEnd.position,barrelEnd.rotation) as GameObject;
            objectRes.transform.SetParent(barrelEnd);
            }
        }
        if (Input.GetKey("2"))
        {
            if (numberElement==2)
            {
                choiceInventoryObject = 1;
            Debug.Log(choiceInventoryObject);
            TransRelieve(childList);
            GameObject objectRes = Instantiate(gmObjects[1],barrelEnd.position,barrelEnd.rotation) as GameObject;
            gmObjects.RemoveAt(1);
            Debug.Log("ZE" + dis.Items[1]);
            Tips.SetActive(true);
            numberElement=0;
            
            }else{
            choiceInventoryObject = 2;
            Debug.Log(choiceInventoryObject);
            TransRelieve(childList);
            GameObject objectRes = Instantiate(gmObjects[1],barrelEnd.position,barrelEnd.rotation) as GameObject;
            objectRes.transform.SetParent(barrelEnd);
            }
        }
        if (Input.GetKey("3"))
        {
            if (numberElement==3)
            {
                choiceInventoryObject = 1;
            Debug.Log(choiceInventoryObject);
            TransRelieve(childList);
            GameObject objectRes = Instantiate(gmObjects[2],barrelEnd.position,barrelEnd.rotation) as GameObject;
            gmObjects.RemoveAt(2);
            Debug.Log("ZE" + dis.Items[2]);
            Tips.SetActive(true);
            numberElement=0;
            
            }else{
            choiceInventoryObject = 3;
            Debug.Log(choiceInventoryObject);
            TransRelieve(childList);
            GameObject objectRes = Instantiate(gmObjects[2],barrelEnd.position,barrelEnd.rotation) as GameObject;
            objectRes.transform.SetParent(barrelEnd);
            }
        }
        if (Input.GetKey("4"))
        {
            if (numberElement==4)
            {
                choiceInventoryObject = 1;
            Debug.Log(choiceInventoryObject);
            TransRelieve(childList);
            GameObject objectRes = Instantiate(gmObjects[3],barrelEnd.position,barrelEnd.rotation) as GameObject;
            gmObjects.RemoveAt(3);
            Debug.Log("ZE" + dis.Items[3]);
            Tips.SetActive(true);
            numberElement=0;
            }else{
            choiceInventoryObject = 4;
            Debug.Log(choiceInventoryObject);
            TransRelieve(childList);
            GameObject objectRes = Instantiate(gmObjects[3],barrelEnd.position,barrelEnd.rotation) as GameObject;
            objectRes.transform.SetParent(barrelEnd);
            }
        }
        }

    void WithFireHose(int numberElement)
    {
            choiceInventoryObject = 1;
            Debug.Log(choiceInventoryObject);
            TransRelieve(childList);
            GameObject objectRes = Instantiate(gmObjects[0],barrelEnd.position,barrelEnd.rotation) as GameObject;
            gmObjects.RemoveAt(0);
            
            numberElement=0;
    }
    void TransRelieve(GameObject gameobject)
    {
        if (gameobject.transform.childCount != 0)
        {
            while(gameobject.transform.childCount > 0)
            {
                DestroyImmediate(gameobject.transform.GetChild(0).gameObject);
            }
        }
    }
}
