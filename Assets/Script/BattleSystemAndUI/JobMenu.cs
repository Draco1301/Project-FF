﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JobMenu : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    [SerializeField] Image background;
    PlayerInstance player;
    int[] attacks;
    public bool IsOpen;

    public void setUp(PlayerInstance p) {
        resetMenu();
        player = p;
        attacks = JobData.getJobAttacks(player.main_job, player.GetCurrentJobLevel());
        setEnableMenu(true);
        for (int i=0; i < attacks.Length ;i++) {
            buttons[i].gameObject.SetActive(true);
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().SetText(PlayerAttackIndex.getAttackName(attacks[i]));
            buttons[i].interactable = isCastable(p.gameObject, attacks[i]);
        }
        cleanUp(p);
    }

    public void setAttack(int i) {
        setEnableMenu(false);
        PlayerAttackIndex.getAttack(ActionMenu.instance.gameObject, attacks[i]); 
        ActionMenu.Start_Action();
    }

    public void setShowMenu(bool b) {
        IsOpen = b;
        this.gameObject.SetActive(b);
    }

    public void setEnableMenu(bool b) {
        for (int i = 0; i < attacks.Length; i++) {
            buttons[i].interactable = b;
        }
    }

    public void resetMenu() {
        player = null;
        attacks = null;
        for (int i = 0; i < buttons.Length; i++) {
            buttons[i].gameObject.SetActive(false);
        }
    }

    public bool isCastable(GameObject p, int i) {

        PlayerAttackIndex.getAttack(p, i);
        IPlayerAttack temp = p.GetComponent<IPlayerAttack>();
        bool b = temp.reqirementsMet();
        temp.DestoryThis();
        return b;
    }

    public void cleanUp(PlayerInstance p) {
        IPlayerAttack[] temp = p.gameObject.GetComponents<IPlayerAttack>();
        foreach (IPlayerAttack pa in temp) {
            pa.DestoryThis();
        }
    }
}
