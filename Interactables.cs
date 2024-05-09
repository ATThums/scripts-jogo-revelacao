using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

[System.Serializable]
public class PreviusItem
{
    public Item requiredItem;
    public Item interactionItem;
    public UnityEvent OnInteract;
}

public class Interactables : MonoBehaviour
{
    public Item item;

    public PreviusItem[] previusItem;

    public UnityEvent OnInteract;
    public UnityEvent CollecItem;


    [HideInInspector]
    public bool isMoving;    

}
