using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

[System.Serializable]
public class LootItem
{
    public GameObject itemPrebab;
    [Range(0, 100)] public float dropChange;
}
