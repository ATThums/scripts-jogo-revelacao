using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public bool grabbable;
    public bool message;
    public AudioClip audioClip;
    public string text;
    public Sprite image;

    [Header("Inventory")]
    public bool inventoryItem;
    public string collectMessage;

}
