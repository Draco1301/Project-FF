using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuJobSelect : MonoBehaviour
{
    PlayerBase player;
    [SerializeField] PlayerMenuDisplay playerDisp;
    [SerializeField] GameObject menu;
    public bool IsOpen;

    public void setUp(PlayerBase player) {
        setEnableMenu(true);
        playerDisp.setPlayer(player);
        this.player = player;
        playerDisp.updateDisplay();
    }

    public void setJob(int j) {
        player.main_job = (Jobs)j;
        player.sprite = MainMenuScript.getJobSprite(player.main_job);
        playerDisp.updateDisplay();
    }

    public void setEnableMenu(bool b) {
        IsOpen = b;
        menu.SetActive(b);
    }
}
