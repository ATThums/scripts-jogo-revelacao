using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

[System.Serializable]
public class Texts
{
    public string text;
    public float startTime;
}

public class CutsceneController : MonoBehaviour
{    
    public bool playOnAwake;
    public Texts[] texts;
    private PlayableDirector cutscene;
    public UnityEvent OnView;
    public UnityEvent FinishAudio;
    public AudioClip audioClip;
    public static bool inViewNow;

    private void Awake()
    {
        cutscene = GetComponent<PlayableDirector>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (playOnAwake)
        {
            Invoke("Play", 1f);
        }   
    }

    public void Play()
    {
        Debug.Log("Chamou Play Text");
        cutscene.Play();
        Invoke("Finish", (float)audioClip.length + 0.5f);
        inViewNow = true;
        for(int i = 0; i < texts.Length; i++)
        {
            StartCoroutine(Subtitle(texts[i]));
            OnView.Invoke();
        }
    }

    IEnumerator Subtitle(Texts text)
    {
        yield return new WaitForSeconds(text.startTime);
        UIManager.instance.SetCaptions(text.text);        
    }

    void Finish()
    {
        FinishAudio.Invoke();
        Debug.Log("acabou legenda");
        UIManager.instance.SetCaptions("");
        inViewNow = false;        
    }
}
