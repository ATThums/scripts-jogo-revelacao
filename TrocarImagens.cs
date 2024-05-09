using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TrocarImagens : MonoBehaviour
{
    public Sprite[] imageList;
    public int index;
    public UnityEvent StopView;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Previous();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Next();
        }

        if (index >= 5)
        {
            index = 5;
        }

        if (index <= 0)
        {
            index = 0;
        }

        if(index == 0)
        {
            UIManager.instance.SetImageFolder(imageList[0]);
        }

        if (Input.GetMouseButtonDown(1))
        {
            StopView.Invoke();            
        }
    }

    public void Next()
    {
        index += 1;
        for(int i = 0; i < imageList.Length; i++)
        {
            UIManager.instance.SetImageFolder(imageList[index]);
        }
        Debug.Log(index);
    }

    public void Previous()
    {
        index -= 1;
        for (int i = 0; i < imageList.Length; i++)
        {
            UIManager.instance.SetImageFolder(imageList[index]);
        }
        Debug.Log(index);
    }
}
