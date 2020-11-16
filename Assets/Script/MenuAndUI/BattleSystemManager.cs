using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystemManager : MonoBehaviour
{
    public static BattleSystemManager instance;
    public static bool AttackInProgress;

    private List<EnemyInstance> Enemies;
    private List<PlayerInstance> Players;
    private Queue<PlayerInstance> playerOrder = new Queue<PlayerInstance>();
    [SerializeField] ActionMenu actionMenu;
    private bool readyForAction = true;

    [SerializeField] GameObject Pnl_Main;
    [SerializeField] PlayerDisplay pdisplayPrefab;

    private bool isGameOver = false;
    private bool isVictory = false;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else { 
            Destroy(this);
        } 
    }

    private void Start() {
        for (int i=0;i < Players.Count;i++) {
            Instantiate(pdisplayPrefab, Pnl_Main.transform).GetComponent<PlayerDisplay>().setUp(Players[i]);
        }
        
    }

    private void Update() {
        if (!AttackInProgress && !isGameOver && !isVictory) {

            //Update ATB and activate player and enemy turns 
            for (int i = 0; i < Enemies.Count; i++) {
                Enemies[i].ATB += Time.deltaTime * Enemies[i].Agility / 100.00f;
                if (Enemies[i].ATB > 1) {
                    Enemies[i].GetComponent<IEnemyController>().StartAttack();
                    Enemies[i].ATB = 0;
                }
            }
            for (int i = 0; i < Players.Count; i++) {
                if (Players[i].HP > 0) {
                    Players[i].ATB += Time.deltaTime * Players[i].Agility / 100.00f;
                    if (Players[i].ATB > 1 && !playerOrder.Contains(Players[i])) {
                        playerOrder.Enqueue(Players[i]);
                    }
                } else {
                    Players[i].ATB = 0;
                }
            }
            if (playerOrder.Count > 0 && readyForAction) {
                startPlayerTurn();
            }

            //Delete enemies
            for (int i = 0; i < Enemies.Count; i++) {
                if (Enemies[i].HP <= 0 && !AttackInProgress) {
                    Destroy(Enemies[i].gameObject);
                    Enemies.RemoveAt(i);
                    i--;
                }
            }

            //check for end states
            CheckForGameOver();
            CheckForVictory();
            if (isGameOver) {
                GameOverMenu.StartGameOver();
            } else if (isVictory) {
                VictoryManager.startVictoryEvents();
            }
        }

    }
    #region GetSet
    public static List<EnemyInstance> getEnemies() {
        return instance.Enemies;
    }

    public static List<PlayerInstance> getPlayers() {
        List<PlayerInstance> temp = new List<PlayerInstance>();
        foreach (PlayerInstance p in instance.Players) {
            temp.Add(p);
        }

        return temp;
    }

    public static void setReadyForAction(bool b) {
        instance.readyForAction = b;
    }
    
    public static void setCharacters(EnemyInstance[] e, PlayerInstance[] p) {
        instance.Enemies = e.ToList<EnemyInstance>();
        instance.Players = p.ToList<PlayerInstance>();
    }

    #endregion

    #region playerTurn
    private void startPlayerTurn() {
        if (playerOrder.Peek().HP > 0) {
            readyForAction = false;
            actionMenu.gameObject.SetActive(true);
            actionMenu.setUp(playerOrder.Peek());
        }
    }
    public static void endPlayerTurn() {
        AttackInProgress = false;
        instance.readyForAction = true;
        instance.playerOrder.Dequeue();
    }
    #endregion

    private void CheckForGameOver() {
        foreach (PlayerInstance p in Players) {
            if (p.HP > 0) {
                return;
            }
        }
        isGameOver = true;
    }

    private void CheckForVictory() {
        if (Enemies.Count == 0) { 
            isVictory = true;
        }
    }

}
