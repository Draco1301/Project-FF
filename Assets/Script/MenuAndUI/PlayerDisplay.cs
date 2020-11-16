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
    private PlayerInstance p;

    public void setUp(PlayerInstance p) {
        this.p = p;
        Name.text = p.Name;
        setHP(p.HP);
        setMP(p.MP);
        setATB(p.ATB);

    }

    private void Update() {
        HP.text = p.HP.ToString();
        MP.text = p.MP.ToString();
        ATBmeter.fillAmount = p.ATB;
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
