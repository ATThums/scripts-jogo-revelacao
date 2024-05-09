using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> itens;
    public int itensPlus;
    public PauseMenu pauseMenu;

    private void Start()
    {
        itensPlus = 0;
        pauseMenu.GetComponent<PauseMenu>();
    }
    private void Update()
    {
        //Debug.Log(itensPlus);
        PauseMenu.objColetados = itensPlus;
    }
    public void AddItem(Item item)
    {
        if (itens.Contains(item))
        {
            return;
        }

        UIManager.instance.SetItens(item, itens.Count);
        itens.Add(item);
        itensPlus++;
    }
}
