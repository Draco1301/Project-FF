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

    public void setPlayer(PlayerBase p) {
        player = p;
    }

    public void updateDisplay() {
        pfp.sprite = MainMenuScript.getJobSprite(player.main_job);
        Name.text = player.Name;
        level.text = player.GetJobLevel().ToString();
        hp.text = player.HP.ToString();
        mp.text = player.MP.ToString();
        maxHP.text = player.MAX_HP.ToString();
        maxMP.text = player.MAX_MP.ToString();
    }

    public void OpenJob() {
        MainMenuScript.instance.MenuJob.setUp(player);
    }
}
