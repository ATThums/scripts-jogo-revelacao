using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    [Header("Sound Closed Door")]
    public AudioSource metalDoor;
    public AudioSource woodDoor;

    public void MetalDoor()
    {
        if (!metalDoor.isPlaying)
        {
            if (!woodDoor.isPlaying)
            {
                metalDoor.Play();
                woodDoor.Stop();
            }
        }
    }

    public void WoodDoor()
    {
        if (!woodDoor.isPlaying)
        {
            if (!metalDoor.isPlaying)
            {
                woodDoor.Play();
                metalDoor.Stop();
            }
        }
    }
}
