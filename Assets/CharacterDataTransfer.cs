using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterDataTransfer : MonoBehaviour
{
    private static CharacterDataTransfer instance;
    [SerializeField] EnemyBase[] enemiesToTransfer;
    [SerializeField] PlayerBase[] playersToTransfer;
    [SerializeField] Vector2[] pos;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this);
            SceneManager.sceneLoaded += sendData;
        } else {
            Destroy(this.gameObject);
        }
    }

    //private void Update() {
    //    if (Input.GetKey(KeyCode.Q)) {
    //        StartBattle();
    //    }
    //}

    public static void StartBattle(EnemyBase[] e, Vector2[] pos) {
        instance.enemiesToTransfer = e;
        instance.pos = pos;
        SceneManager.LoadScene("BattleScene");
    }

    private void sendData(Scene scene, LoadSceneMode mode) {
        if (scene.buildIndex == SceneManager.GetSceneByName("BattleScene").buildIndex) {
            BattleLoader.setUpScene(playersToTransfer,enemiesToTransfer, pos);
        }
    }

}
