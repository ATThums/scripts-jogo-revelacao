using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
public class Passos : MonoBehaviour
{

    [Header("Sound Steps")]
    public AudioSource passos;
    public AudioSource corrida;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {        
        if(controller.isGrounded && controller.velocity.magnitude > 0.2f)
        {
            TocarSons();            
        }
        if(!controller.isGrounded || controller.velocity.magnitude < 0.19f)
        {
            passos.Stop();
            corrida.Stop();
        }
    }

    void TocarSons()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !corrida.isPlaying)
        {
            if (!passos.isPlaying)
            {
                corrida.Play();
                passos.Stop();
            }
            
        }
        else if (!Input.GetKey(KeyCode.LeftShift) && !passos.isPlaying)
        {
            if (!corrida.isPlaying)
            {
                passos.Play();
                corrida.Stop();
            }            
        }
    }

    public void StopPassos()
    {
        passos.Stop();
        corrida.Stop();
    }
}
