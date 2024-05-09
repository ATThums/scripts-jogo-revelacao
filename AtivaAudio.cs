using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AtivaAudio : MonoBehaviour
{
    private AudioSource audioSource;
    //private AudioClip audioClip;
    //public GameObject talkingBox;
    public static bool isTalking;
    public bool textScreen;
    public bool destroyer;
    public float timeToDestroy;
    public float timeFadeFinal;
    public Image textFade;
    public float timeFade;

    public UnityEvent OnInteraction;
    public UnityEvent FinishFade;

    private void Start()
    {
        //audioClip = talkingBox.GetComponent<AudioClip>();
        isTalking = false;

        Iniciar();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTalking = true;
            OnInteraction.Invoke();
            StartCoroutine(Destruicao());
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            GetComponent<BoxCollider>().enabled = false;            
        }
    }

    public void DestruirObjeto()
    {
        StartCoroutine(Destruicao());
    }

    public void Iniciar()
    {
        if (textScreen)
        {
            StartCoroutine(Fading());
            if (destroyer)
            {
                DestruirObjeto();
            }
        }
    }

    public void Final()
    {
        if (textScreen)
        {
            StartCoroutine(FinalFading());            
        }
    }

    IEnumerator Destruicao()
    {
        Debug.Log("Destruir ativado");
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(this.gameObject);
    }

    IEnumerator Fading()
    {
        Color newColor = textFade.color;
        while (newColor.a < 1)
        {
            newColor.a += Time.deltaTime;
            textFade.color = newColor;
            yield return null;
        }

        yield return new WaitForSeconds(timeFade);

        while (newColor.a > 0)
        {
            newColor.a -= Time.deltaTime;
            textFade.color = newColor;
            yield return null;
        }

        FinishFade.Invoke();
    }

    IEnumerator FinalFading()
    {
        yield return new WaitForSeconds(timeFadeFinal);

        Color newColor = textFade.color;
        while (newColor.a < 1)
        {
            newColor.a += Time.deltaTime;
            textFade.color = newColor;
            yield return null;
        }
    }
}
