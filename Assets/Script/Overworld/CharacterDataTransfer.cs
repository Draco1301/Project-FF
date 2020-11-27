using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterDataTransfer : MonoBehaviour
{
    private static CharacterDataTransfer instance;
    private PlayerBase[] playersToTransfer;
    private InventoryBase inventory;
    private EnemyBase[] enemiesToTransfer;
    private Vector2[] pos;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this);
            SceneManager.sceneLoaded += sendData;
        } else {
            Destroy(this.gameObject);
        }
    }

    public static void StartBattle(EnemyBase[] e, Vector2[] pos) {
        instance.enemiesToTransfer = e;
        instance.pos = pos;
        instance.playersToTransfer = PlayerDataState.getPlayers();
        instance.inventory = PlayerDataState.getInventory();
        SceneManager.LoadScene("BattleScene");
    }

    private void sendData(Scene scene, LoadSceneMode mode) {
        if (scene.buildIndex == SceneManager.GetSceneByName("BattleScene").buildIndex) {
            BattleLoader.setUpScene(playersToTransfer,enemiesToTransfer, pos, inventory);
        }
    }

}
