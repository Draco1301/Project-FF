using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ActionMenu : MonoBehaviour
{
    public static ActionMenu instance;

    [SerializeField] Button Fight;
    [SerializeField] Button Job;
    [SerializeField] Button Ability;
    [SerializeField] Button Item;
    private PlayerInstance player;
    private CharacterInstance target;
    private IPlayerAttack playerAttack;
    private Coroutine action;
    [SerializeField] TargetMenu targetMenu;
    [SerializeField] JobMenu jobMenu;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    public void setUp(PlayerInstance p) {
        player = p;
        if (player.HP <= 0) {
            return;
        }


        showMenu();

        Job.GetComponentInChildren<Text>().text = JobData.getJobName(p.main_job);
        if (p.main_job == Jobs.None) {
            Job.enabled = false;
            Job.GetComponent<Image>().enabled = false;
            Job.GetComponentInChildren<Text>().enabled = false;
        } else {
            jobMenu.setUp(p);
            Job.enabled = true;
            Job.GetComponent<Image>().enabled = true;
            Job.GetComponentInChildren<Text>().enabled = true;
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
        if (player != null && player.HP == 0) {
            SkipAction();
            player = null;
        } else if (Input.GetKeyDown(KeyCode.Q)) {
            if (playerAttack != null) { //target menu is open
                if (jobMenu.IsOpen) {
                    jobMenu.setEnableMenu(true);
                }
                StopCoroutine(action);
                playerAttack.DestoryThis();
                playerAttack = null;
                targetMenu.turnOff();
                setEnableMenu(true);
            } else if (jobMenu.IsOpen) {
                jobMenu.setShowMenu(false);
            } 
        }
    }

    #region Execute

    private void StartAction() {
        setEnableMenu(false);
        action = StartCoroutine(WaitForTarget());
        targetMenu.SetUp(BattleSystemManager.getEnemies(), BattleSystemManager.getPlayers(), player, playerAttack.getTargetType());
    }

    private IEnumerator WaitForTarget() {
        while (target == null || BattleSystemManager.AttackInProgress) {
            yield return null;
        }
        performAction();
    }

    public void setTarget(CharacterInstance t) {
        target = t;
    }

    private void performAction() {
        StartCoroutine(playerAttack.StartAction(player, target));
        target = null;
        player.ATB = 0;
        hideMenu();
        if (jobMenu.IsOpen) {
            jobMenu.setShowMenu(false);
        }
        player = null;
        playerAttack = null;
    }

    private void SkipAction() {
        target = null;
        playerAttack = null;
        player.ATB = 0;
        hideMenu();
        BattleSystemManager.endPlayerTurn();
    }

    #endregion


    private void hideMenu() {
        this.GetComponent<Image>().enabled = false;

        Fight.onClick.RemoveAllListeners();
        Fight.gameObject.SetActive(false);

        Job.onClick.RemoveAllListeners();
        Job.gameObject.SetActive(false);

        Ability.onClick.RemoveAllListeners();
        Ability.gameObject.SetActive(false);

        Item.onClick.RemoveAllListeners();
        Item.gameObject.SetActive(false);

        jobMenu.setShowMenu(false);
        targetMenu.turnOff();
    }

    private void showMenu() {
        setEnableMenu(true);
        this.GetComponent<Image>().enabled = true;
        Fight.gameObject.SetActive(true);

        Job.gameObject.SetActive(true);

        Ability.gameObject.SetActive(true);

        Item.gameObject.SetActive(true);
    }

    private void setEnableMenu(bool b) {
        Fight.interactable = b;
        Job.interactable = b;
        Ability.interactable = b;
        Item.interactable = b;
    }

    public static void Start_Action() {
        instance.playerAttack = instance.gameObject.GetComponent<IPlayerAttack>();
        instance.StartAction();
    }
}
