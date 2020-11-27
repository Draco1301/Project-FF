using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class MenuAbilitySelect : MonoBehaviour {

    PlayerBase player;
    [SerializeField] GameObject menu;
    [SerializeField] PlayerMenuDisplay playerDisp;
    [SerializeField] Button[] buttons;
    [SerializeField] List<int> attacks;
    public bool IsOpen = false;

    public void setUp(PlayerBase player) {
        setEnableMenu(true);
        playerDisp.setPlayer(player);
        this.player = player;
        playerDisp.updateDisplay();

        attacks.Clear();
        int[] attacksTemp;
        int count = 0;

        EventSystem.current.SetSelectedGameObject(buttons[count].gameObject);
        buttons[count++].gameObject.SetActive(true);

        if (player.job != Jobs.Black) {
            attacksTemp = JobData.getJobAttacks(Jobs.Black, player.BLACK_LEVEL);
            for (int i = 0; i < attacksTemp.Length; i++) {
                attacks.Add(attacksTemp[i]);
            }
            for (int i = 0; i < attacksTemp.Length; i++) {
                buttons[count].gameObject.SetActive(true);
                buttons[count].GetComponentInChildren<TextMeshProUGUI>().SetText(PlayerAttackIndex.getAttackName(attacksTemp[i]));
                count++;
            }
        }

        if (player.job != Jobs.White) {
            attacksTemp = JobData.getJobAttacks(Jobs.White, player.WHITE_LEVEL);
            for (int i = 0; i < attacksTemp.Length; i++) {
                attacks.Add(attacksTemp[i]);
            }
            for (int i = 0; i < attacksTemp.Length; i++) {
                buttons[count].gameObject.SetActive(true);
                buttons[count].GetComponentInChildren<TextMeshProUGUI>().SetText(PlayerAttackIndex.getAttackName(attacksTemp[i]));
                count++;
            }
        }

        if (player.job != Jobs.Monk) {
            attacksTemp = JobData.getJobAttacks(Jobs.Monk, player.MONK_LEVEL);
            for (int i = 0; i < attacksTemp.Length; i++) {
                attacks.Add(attacksTemp[i]);
            }
            for (int i = 0; i < attacksTemp.Length; i++) {
                buttons[count].gameObject.SetActive(true);
                buttons[count].GetComponentInChildren<TextMeshProUGUI>().SetText(PlayerAttackIndex.getAttackName(attacksTemp[i]));
                count++;
            }
        }

        if (player.job != Jobs.Knight) {
            attacksTemp = JobData.getJobAttacks(Jobs.Knight, player.KNIGHT_LEVEL);
            for (int i = 0; i < attacksTemp.Length; i++) {
                attacks.Add(attacksTemp[i]);
            }
            for (int i = 0; i < attacksTemp.Length; i++) {
                buttons[count].gameObject.SetActive(true);
                buttons[count].GetComponentInChildren<TextMeshProUGUI>().SetText(PlayerAttackIndex.getAttackName(attacksTemp[i]));
                count++;
            }
        }

        for (int i = count; i< buttons.Length; i++) { 
            buttons[i].gameObject.SetActive(false);
        }

    }

    public void setEnableMenu(bool b) {
        IsOpen = b;
        menu.SetActive(b);
    }

    public void setAbility(int i) {
        if (i == -1) {

        } else {
            player.secondaryAbility = attacks[i];
        }
        playerDisp.updateDisplay();
    }
}
