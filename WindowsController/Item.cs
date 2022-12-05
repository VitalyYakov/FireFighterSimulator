using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ROAD/Item", order = 0)]
public class Item : ScriptableObject {
    public Sprite Icon;
    public GameObject Model;
}

