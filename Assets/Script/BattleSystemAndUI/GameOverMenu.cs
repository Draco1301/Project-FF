using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverMenu : MonoBehaviour
{
    public static GameOverMenu instance;
    [SerializeField] GameObject panel;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
        panel.SetActive(false);

    }

    public static void StartGameOver() {
        instance.panel.SetActive(true);
    }


    public void RestartBattle() {
        SceneManager.LoadScene("BattleScene");
    }

    public void QuitBattle() {
        SceneManager.LoadScene("OverWorldScene");
    }
}
