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
    public static bool finishMessages = false;

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

    public static IEnumerator displayBattleResults(Queue<string> messages) {
        text.enabled = true;
        img.enabled = true;
        text.text = messages.Dequeue();

        while (messages.Count != 0) {
            if (Input.GetKeyDown(KeyCode.Mouse0)){
                text.text = messages.Dequeue();
            }
            yield return null;
        }

        while (!Input.GetKeyDown(KeyCode.Mouse0)) {
            yield return null;
        }

        text.enabled = false;
        img.enabled = false;
        finishMessages = true;
    }

}
