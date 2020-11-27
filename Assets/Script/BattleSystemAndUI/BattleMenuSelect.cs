using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BattleMenuSelect : MonoBehaviour
{
    [SerializeField] JobMenu jobMenu;
    [SerializeField] Button actionMenuDefault;
    [SerializeField] MenuSelect select;
    [SerializeField] ItemMenu itemMenu;
    [SerializeField] TargetMenu targetMenu;
    [SerializeField] Button gameOverDefault;

    private bool once = false;
    private bool gOnce = false;

    // Update is called once per frame
    void Update() {
        if ((BattleSystemManager.currentPlayersTurn == null || !ActionMenu.IsOpen) && !BattleSystemManager.instance.isGameOver) {
            EventSystem.current.SetSelectedGameObject(null);
            select.active = false;
        } else {
            select.active = true;
            if (BattleSystemManager.currentPlayersTurn != null && (EventSystem.current.currentSelectedGameObject == null || !EventSystem.current.currentSelectedGameObject.activeInHierarchy)) {
                if (targetMenu.IsOpen && !BattleSystemManager.AttackInProgress) {
                    EventSystem.current.SetSelectedGameObject(targetMenu.targets[0].gameObject);
                } else if (targetMenu.IsOpen && BattleSystemManager.AttackInProgress) { 
                    select.active = false;
                } else {
                    EventSystem.current.SetSelectedGameObject(actionMenuDefault.gameObject);
                }
            }
            if (jobMenu.IsOpen && jobMenu.buttons[0].gameObject.activeInHierarchy && !once) {
                once = true;
                EventSystem.current.SetSelectedGameObject(jobMenu.buttons[0].gameObject);
            }
            if (itemMenu.IsOpen && itemMenu.buttons[0].gameObject.activeInHierarchy && !once) {
                once = true;
                EventSystem.current.SetSelectedGameObject(itemMenu.buttons[0].gameObject);
            }
            if (targetMenu.IsOpen && targetMenu.targets[0].gameObject.activeInHierarchy && !once) {
                once = true;
                EventSystem.current.SetSelectedGameObject(targetMenu.targets[0].gameObject);
            }
            if (jobMenu.IsOpen && !jobMenu.buttons[0].gameObject.activeInHierarchy) {
                select.active = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) || (!jobMenu.IsOpen && !itemMenu.IsOpen && !targetMenu.IsOpen)) {
            once = false;
        }

        if (BattleSystemManager.instance.isGameOver && !gOnce) {
            gOnce = true;
            EventSystem.current.SetSelectedGameObject(gameOverDefault.gameObject);
        }
    }
}
