using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    public static VictoryManager instance;
    Queue<string> logs = new Queue<string>();

    void Awake()
    {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }

    public static void startVictoryEvents() {
        instance.logs.Enqueue("Victory!");
        instance.logs.Enqueue("Level Up");
        instance.logs.Enqueue("5 gold");

        instance.StartCoroutine(BattleMessage.displayBattleResults(instance.logs));
    }

}
