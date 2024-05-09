using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MissionText : MonoBehaviour
{
    public Texts missionText;
    public Text itemText;
    private UIManager uiManager;
    private PauseMenu pauseMenu;
    public int escritasMission;

    private void Start()
    {
        pauseMenu.GetComponent<PauseMenu>();
        uiManager.GetComponent<UIManager>();
        escritasMission = 0;
        itemText.text = escritasMission.ToString("FO");
    }

    public void AlteraMissao()
    {
        UIManager.instance.SetMissions(missionText.text);
    }
    
    public void Escrever()
    {
        escritasMission++;
        Debug.Log(escritasMission);
        itemText.text = escritasMission.ToString();
    }

    private void Update()
    {        
        if (escritasMission > 7)
        {
            PauseMenu.escritas = true;
            escritasMission = 0;
            Debug.Log("Escreveu tudo");
        }
    }
}
