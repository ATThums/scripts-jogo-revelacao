using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManageer : MonoBehaviour
{
    [SerializeField]
    private string nomeLevelJogo;
    [SerializeField]
    private string nomeLevelMenu;
    [SerializeField]
    private string gameOver;
    [SerializeField]
    private string winGame;
    [SerializeField]
    private GameObject painelMenuInicial;
    [SerializeField]
    private GameObject painelOpcoes;
    [SerializeField]
    private float timeToLoadGameOver;
    [SerializeField]
    private float timeToLoadWinGame;
    [SerializeField]
    private AudioSource audioSource;

    void Start()
    {
        Time.timeScale = 1f;
        audioSource.Play();
        AudioListener.pause = false;
    }

    public void Jogar()
    {
        StartCoroutine(FadeLoad());
    }

    public void MenuInicial()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nomeLevelMenu);
    }

    public void GameOver()
    {
        StartCoroutine(FadeLoadGameOver());
    }

    public void WinGame()
    {
        StartCoroutine(FadeLoadWinGame());
    }

    public void AbrirOpções()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpções()
    {
        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    
    public void QuitGame()
    {
        Debug.Log("Saiu Jogo");
        Application.Quit();
    }

    IEnumerator FadeLoad()
    {
        yield return new WaitForSeconds(timeToLoadGameOver);
        SceneManager.LoadScene(nomeLevelJogo);
    }

    IEnumerator FadeLoadGameOver()
    {
        yield return new WaitForSeconds(timeToLoadGameOver);
        SceneManager.LoadScene(gameOver);
    }

    IEnumerator FadeLoadWinGame()
    {
        yield return new WaitForSeconds(timeToLoadWinGame);
        SceneManager.LoadScene(winGame);
    }
}
