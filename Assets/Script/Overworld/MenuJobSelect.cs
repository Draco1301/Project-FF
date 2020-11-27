using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuJobSelect : MonoBehaviour
{
    PlayerBase player;
    [SerializeField] PlayerMenuDisplay playerDisp;
    [SerializeField] GameObject menu;
    [SerializeField] Image[] mastered;
    public bool IsOpen;
    [SerializeField] Button defualt;

    public void setUp(PlayerBase player) {
        setEnableMenu(true);
        playerDisp.setPlayer(player);
        this.player = player;
        playerDisp.updateDisplay();

        if (player.BLACK_LEVEL >= JobData.masteredLevel) { 
            mastered[0].enabled = true;
        } else {
            mastered[0].enabled = false;
        }

        if (player.WHITE_LEVEL >= JobData.masteredLevel) {
            mastered[1].enabled = true;
        } else {
            mastered[1].enabled = false;
        }

        if (player.MONK_LEVEL >= JobData.masteredLevel) {
            mastered[2].enabled = true;
        } else {
            mastered[2].enabled = false;
        }

        if (player.KNIGHT_LEVEL >= JobData.masteredLevel) {
            mastered[3].enabled = true;
        } else {
            mastered[3].enabled = false;
        }

        EventSystem.current.SetSelectedGameObject(defualt.gameObject);
    }

    public void setJob(int j) {
        player.job = (Jobs)j;
        player.sprite = MainMenuScript.getJobSprite(player.job);
        playerDisp.updateDisplay();
    }

    public void setEnableMenu(bool b) {
        IsOpen = b;
        menu.SetActive(b);
    }
}
