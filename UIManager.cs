using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Text captionsText;
    public Text missionsText;

    public GameObject cursorInterativo;
    public GameObject backImage;
    public Image interactionImage;
    public Image folderImage;

    internal void SetMissions(object text)
    {
        throw new NotImplementedException();
    }

    public GameObject inventotyImage;
    public Text[] inventoryItens;
    public Text infoText;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }    

    public void SetCaptions(string text)
    {
        captionsText.text = text;
    }

    public void SetMissions(string text)
    {
        missionsText.text = text;
    }

    public void SetHandCursor(bool state)
    {
        cursorInterativo.SetActive(state);
    }

    public void SetBackImage(bool state)
    {
        backImage.SetActive(state);
        if(state == false)
        {
            interactionImage.enabled = false;
        }
    }

    public void SetImage(Sprite sprite)
    {
        interactionImage.sprite = sprite;
        interactionImage.enabled = true;
    }
    public void SetImageFolder(Sprite sprite)
    {
        folderImage.sprite = sprite;
        folderImage.enabled = true;
    }

    public void SetItens(Item item, int index)
    {
        inventoryItens[index].text = item.collectMessage;
        Debug.Log(item);
        infoText.text = item.collectMessage;
        StartCoroutine(FadingText());
    }

    IEnumerator FadingText()
    {
        Color newColor = infoText.color;
        while(newColor.a < 1)
        {
            newColor.a += Time.deltaTime;
            infoText.color = newColor;
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        while (newColor.a > 0)
        {
            newColor.a -= Time.deltaTime;
            infoText.color = newColor;
            yield return null;
        }
    }
}
