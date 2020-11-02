using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDisplay : MonoBehaviour
{
    public const float spacing = -26.5f;
    [SerializeField] TextMeshProUGUI Name;
    [SerializeField] TextMeshProUGUI HP;
    [SerializeField] TextMeshProUGUI MP;
    [SerializeField] Image ATBmeter;
    private PlayerBase p;

    public void setUp(PlayerBase p) {
        this.p = p;
        Name.text = p.name;
        setHP(p.HP);
        setMP(p.MP);
        setATB(p.ATP);

    }

    public void setHP(int h) {
        HP.text = h.ToString();
    }

    public void setMP(int m) {
        MP.text = m.ToString();
    }

    public void setATB(float a) {
        ATBmeter.fillAmount = a;
    }
}
