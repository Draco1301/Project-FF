using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public static MainMenuScript instance = null;
    
    [SerializeField] PlayerBase[] players;
    [SerializeField] PlayerMenuDisplay[] playerDisplays;
    [SerializeField] PlayerMenuDisplay displayPrefab;
    [SerializeField] Sprite[] imgs = new Sprite[5];
    [SerializeField] Transform displayHolder;
    [SerializeField] public MenuJobSelect MenuJob;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }

        playerDisplays = new PlayerMenuDisplay[players.Length];
        for (int i=0; i < players.Length ;i++) {
            playerDisplays[i] = Instantiate(displayPrefab, displayHolder);
            playerDisplays[i].setPlayer(players[i]);
            playerDisplays[i].updateDisplay();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            if (MenuJob.IsOpen) {
                MenuJob.setEnableMenu(false);
                foreach (PlayerMenuDisplay pmd in playerDisplays) {
                    pmd.updateDisplay();
                }
            } else {
                gameObject.transform.GetChild(0).gameObject.SetActive(!gameObject.transform.GetChild(0).gameObject.activeInHierarchy);
            }
        }
    }

    public static Sprite getJobSprite(Jobs j) {
        switch (j) {
            case Jobs.None:
                return instance.imgs[0];
            case Jobs.Black:
                return instance.imgs[1];
            case Jobs.White:
                return instance.imgs[2];
            case Jobs.Monk:
                return instance.imgs[3];
            case Jobs.Knight:
                return instance.imgs[4];
            default:
                return instance.imgs[0];
        }
    }

    public static PlayerBase[] getPlayers() {
        return instance.players;
    }
}
