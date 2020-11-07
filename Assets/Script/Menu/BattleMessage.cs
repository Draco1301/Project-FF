using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleMessage : MonoBehaviour
{
    public static BattleMessage instance;
    private static TextMeshProUGUI text;
    private static Image img;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
        text = GetComponentInChildren<TextMeshProUGUI>();
        img = GetComponent<Image>();
        closeMessage();
    }

    public static void setMessage(string s) {
        text.enabled = true;
        img.enabled = true;  
        text.text = s;
    }

    public static void closeMessage() {
        text.enabled = false;
        img.enabled = false;
    }

}
