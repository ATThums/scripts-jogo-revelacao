using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public static bool gameOver;
    public static int objColetados;
    public static bool escritas;
    public bool gameOverWin;
    public UnityEvent InPause;
    public UnityEvent OutPause;
    public UnityEvent OnWin;

    public MissionText mission;

    public AudioSource pauseMenu;

    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    public GameObject youWinUI;
    public GameObject player;
    public GameObject camDois;

    // Start is called before the first frame update
    void Start()
    {
        Resume();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameOver = false;
        objColetados = 0;
        mission.GetComponent<MissionText>();
        escritas = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverWin)
        {
            Pause();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if(objColetados >= 7)
        {
            VerificaFim();
        }
    }

    public void Resume()
    {
        OutPause.Invoke();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        pauseMenu.Play();
    }

    void Pause()
    {
        InPause.Invoke();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        pauseMenu.Play();
    }

    void VerificaFim()
    {
        if (gameOver == true)
        {
            GameOver();
        }

        Debug.Log(escritas);
        if (escritas == true)
        {
            escritas = false;
            OnWin.Invoke();
            objColetados = 0;
            Debug.Log("Pegou todos itens");
            //Win();            
        }
    }
    public void QuitGame()
    {
        Debug.Log("Saiu Jogo");
        Application.Quit();
    }

    void GameOver()
    {
        InPause.Invoke();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        camDois.SetActive(true);
        player.SetActive(false);
        pauseMenu.Play();
        Debug.Log("Acabou");
    }

    public void Win()
    {
        InPause.Invoke();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        youWinUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        camDois.SetActive(true);
        player.SetActive(false);
        pauseMenu.Play();
        Debug.Log("Fugiu");
    }
}
