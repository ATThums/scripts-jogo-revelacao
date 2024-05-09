using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Contador : MonoBehaviour
{
    public Text minTimeText;
    public Text segTimeText;
    public float minTimeCount;
    public float timeCount;
    public bool timeOver = false;
    private PauseMenu pauseMenu;
    public UnityEvent Finish;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.GetComponent<PauseMenu>();
        timeOver = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(minTimeCount == 0 && timeCount <= 1)
        {
            Finish.Invoke();
            Debug.Log("Isso funcina acredita");
            //PauseMenu.gameOver = true;
        }       

        minTimeText.text = minTimeCount.ToString("F0");
        segTimeText.text = timeCount.ToString("F0");
        TimeCount();        
    }


    void TimeCount()
    {
        Debug.Log(timeOver);
        if(!timeOver && timeCount > 0)
        {
            timeCount -= Time.deltaTime;
            
            if(timeCount <= 0)
            {
                timeCount = 59f;
                minTimeCount --;
            }
        }
    }

    public void TimeOverTrue()
    {
        timeOver = true;
    }

    public void TimeOverFalse()
    {
        timeOver = false;
    }
}
