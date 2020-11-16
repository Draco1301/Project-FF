using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobMenu : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    [SerializeField] Image background;
    PlayerInstance player;
    int[] attacks;
    public static bool IsOpen;

    public void setUp(PlayerInstance p) {
        player = p;
        attacks = JobData.getJobAttacks(player.main_job, player.GetCurrentJobLevel());
        for (int i=0; i < attacks.Length ;i++) {
            buttons[i].gameObject.SetActive(true);
            buttons[i].onClick.AddListener(delegate { PlayerAttackIndex.getAttack(ActionMenu.instance.gameObject, attacks[i]) ; ActionMenu.Start_Action(); });
        }
    }

    public void setEnableMenu(bool b) { 
        
    }

    public void resetMenu() {
        player = null;
        attacks = null;
        for (int i = 0; i < buttons.Length; i++) {
            buttons[i].onClick.RemoveAllListeners();
            buttons[i].gameObject.SetActive(false);
        }
    }
}
