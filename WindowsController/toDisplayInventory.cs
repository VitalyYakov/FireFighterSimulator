using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toDisplayInventory : MonoBehaviour
{
    public Image img1,img2,img3,img4;

    [SerializeField] public List<Item> Items = new List<Item>();
    
    void Start()
    {
        
    }

    
    void Update()
    {
        img1.sprite = Items[0].Icon;
        img2.sprite = Items[1].Icon;
        img3.sprite = Items[2].Icon;
        img4.sprite = Items[3].Icon;
    }
}
