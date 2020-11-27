using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    public static VictoryManager instance;
    private static Queue<string> logs = new Queue<string>();
    private static PlayerInstance[] players;

    void Awake()
    {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }

    private void Update() {
        if (BattleMessage.finishMessages) {
            BattleMessage.finishMessages = false;
            SceneManager.LoadScene("OverWorldScene");
        }
    }

    public static void startVictoryEvents(PlayerInstance[] p) {
        players = p;
        logs.Enqueue("Victory!");

        for (int i = 0; i < p.Length; i++) {
            if ( p[i].GetCurrentJobLevel() + 2 > Mathf.FloorToInt((p[i].GetCurrentJobLevel()+10)/10)*10 ) {
                logs.Enqueue(p[i].Name + " leveled up");
            }
            p[i].AddExpCurrentJobLevel(2);
            p[i].saveData();
        }
        InventoryInstance.instacne.saveData();

        instance.StartCoroutine(BattleMessage.displayBattleResults(logs));
    }

}
