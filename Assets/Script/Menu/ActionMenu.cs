using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ActionMenu : MonoBehaviour
{
    [SerializeField] Button Fight;
    [SerializeField] Button Job;
    [SerializeField] Button Ability;
    [SerializeField] Button Item;
    private PlayerBase player;
    private CharacterBase target;
    private IPlayerAttack playerAttack;
    private Coroutine action;
    [SerializeField] TargetMenu targetMenu;

    public void setUp(PlayerBase p) {
        player = p;
        showMenu();

        Job.GetComponentInChildren<Text>().text = JobData.getJobName(p.main_job);
        if (p.main_job == Jobs.None) {
            Job.enabled = false;
            Job.GetComponent<Image>().enabled = false;
            Job.GetComponentInChildren<Text>().enabled = false;
        } else {
            //Assign job ability menu to the button
        }
        Ability.GetComponentInChildren<Text>().text = JobData.getJobName(p.sub_job);
        if (p.sub_job == Jobs.None) {
            Ability.enabled = false;
            Ability.GetComponent<Image>().enabled = false;
            Ability.GetComponentInChildren<Text>().enabled = false;
        } else {
            //Assign job ability menu to the button 
        }
        //Assign job ability menu to the button 
        Fight.onClick.AddListener(delegate { playerAttack = gameObject.AddComponent<PA_Fight>(); StartAction(); });
        //assign item to open item menu
    }

    private void Update() {
        if (playerAttack != null && Input.GetKeyDown(KeyCode.Q)) {
            StopCoroutine(action);
            playerAttack.DestoryThis();
            targetMenu.turnOff();
        }
    }

    private void StartAction() {
        action = StartCoroutine(WaitForTarget());
        targetMenu.SetUp(BattleSystemManager.getEnemies(), BattleSystemManager.getPlayers());
    }

    private IEnumerator WaitForTarget() {
        while (target == null || BattleSystemManager.AttackInProgress) {
            yield return null;
        }
        performAction();
    }

    public void setTarget(CharacterBase t) {
        target = t;
    }

    private void performAction() {
        StartCoroutine(playerAttack.StartAction(player, target));
        target = null;
        player.ATP = 0;
        hideMenu();
    }

    private void hideMenu() {
        this.GetComponent<Image>().enabled = true;
        Fight.gameObject.SetActive(false);

        Job.onClick.RemoveAllListeners();
        Job.gameObject.SetActive(false);

        Ability.onClick.RemoveAllListeners();
        Ability.gameObject.SetActive(false);

        Item.onClick.RemoveAllListeners();
        Item.gameObject.SetActive(false);
    }

    private void showMenu() {
        this.GetComponent<Image>().enabled = true;
        Fight.gameObject.SetActive(true);

        Job.gameObject.SetActive(true);

        Ability.gameObject.SetActive(true);

        Item.gameObject.SetActive(true);
    }
}
