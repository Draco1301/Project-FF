using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMenuDisplay : MonoBehaviour
{
    private PlayerBase player;
    [SerializeField] Image pfp;
    [SerializeField] TextMeshProUGUI Name;
    [SerializeField] TextMeshProUGUI level;
    [SerializeField] TextMeshProUGUI hp;
    [SerializeField] TextMeshProUGUI mp;
    [SerializeField] TextMeshProUGUI maxHP;
    [SerializeField] TextMeshProUGUI maxMP;
    [SerializeField] TextMeshProUGUI ability;

    public void setPlayer(PlayerBase p) {
        player = p;
    }

    public void updateDisplay() {
        pfp.sprite = MainMenuScript.getJobSprite(player.job);
        Name.text = player.Name;
        level.text = player.GetJobLevel().ToString();
        hp.text = player.HP.ToString() + "/";
        mp.text = player.MP.ToString() + "/";
        maxHP.text = player.MAX_HP.ToString();
        maxMP.text = player.MAX_MP.ToString();
        if (player.secondaryAbility != -1) {
            ability.text = PlayerAttackIndex.getAttackName(player.secondaryAbility);
        } else { 
            ability.text = "";
        }
    }

    public void OpenMenu() {
        MainMenuScript.instance.openMenu(player);
    }
}
