using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPortas : MonoBehaviour
{
    public Animator anim;
    public Animator anim2;
    public bool open = false;

    public GameObject Intro;

    private void Start()
    {
        open = false;
    }
    public void Abrir2()
    {
        if(open == true)
        {
            anim.SetBool("Abrir", false);
            anim2.SetBool("Abrir", false);
            open = false;
        }
        else
        {
            anim.SetBool("Abrir", true);
            anim2.SetBool("Abrir", true);
            open = true;
        }              
    }

    public void Abrir1()
    {
        if (open == true)
        {
            anim.SetBool("Abrir", false);
            open = false;
        }
        else
        {
            anim.SetBool("Abrir", true);
            open = true;
        }
        StartCoroutine(StopIntro());
    }

    IEnumerator StopIntro()
    {
        yield return new WaitForSeconds(5f);
        Destroy(Intro);
    }

}
