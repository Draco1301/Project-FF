using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuScript : MonoBehaviour
{
    public static MainMenuScript instance = null;

    private enum menuSelect { none, job, ability}
    private menuSelect currentSelect;
    [SerializeField] GameObject menu;
    [SerializeField] Button defualt;

    [SerializeField] Button[] menuOptions;
    [SerializeField] Sprite[] imgs;

    private PlayerBase[] players;
    [SerializeField] PlayerMenuDisplay displayPrefab;
    private PlayerMenuDisplay[] playerDisplays;
    [SerializeField] Transform displayHolder;
    
    [SerializeField] MenuJobSelect MenuJob;
    [SerializeField] MenuAbilitySelect MenuAb;
    
    [SerializeField] SelectDisplay selectDisplay;

    public bool IsOpen => menu.activeInHierarchy || MenuJob.IsOpen || MenuAb.IsOpen;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }

    private void Start() {
        players = PlayerDataState.getPlayers();

        playerDisplays = new PlayerMenuDisplay[players.Length];
        for (int i = 0; i < players.Length; i++) {
            playerDisplays[i] = Instantiate(displayPrefab, displayHolder);
            playerDisplays[i].setPlayer(players[i]);
            playerDisplays[i].updateDisplay();
            playerDisplays[i].GetComponent<Button>().interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            selectDisplay.enableSubSelect(false);
            if (MenuJob.IsOpen) {
                MenuJob.setEnableMenu(false);
                menu.SetActive(true);
            } else if (MenuAb.IsOpen) {
                MenuAb.setEnableMenu(false);
                menu.SetActive(true);

            } else if(currentSelect == menuSelect.none) {
                menu.SetActive(!menu.activeInHierarchy);
                if (menu.activeInHierarchy) {
                    UIAudioManager.Select();
                } else { 
                    UIAudioManager.Cancel();
                }
                selectDisplay.active = menu.activeInHierarchy;
            }

            currentSelect = menuSelect.none;
            selectDisplay.setCurrentSettings(UIOffset.Double, UISide.Left);
            foreach (PlayerMenuDisplay pmd in playerDisplays) {
                pmd.updateDisplay();
            }
            foreach (Button b in menuOptions) {
                b.interactable = currentSelect == menuSelect.none;
            }
            foreach (PlayerMenuDisplay b in playerDisplays) {
                b.GetComponent<Button>().interactable = currentSelect != menuSelect.none;
            }
            EventSystem.current.SetSelectedGameObject(defualt.gameObject);

        }
        if (MenuJob.IsOpen || MenuAb.IsOpen) {
            menu.SetActive(false);
            selectDisplay.setCurrentSettings(UIOffset.Half, UISide.Left);
        }
        if (currentSelect == menuSelect.none || MenuJob.IsOpen || MenuAb.IsOpen) {
            selectDisplay.enableSubSelect(false);
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

    public void setMenuSelect(int i) {
        instance.currentSelect = (menuSelect)i;
        if (i == 1 || i == 2) {
            foreach (PlayerMenuDisplay pmd in playerDisplays) {
                pmd.GetComponent<Button>().interactable = true;
            }
        }

        foreach (Button b in menuOptions) {
            b.interactable = currentSelect == menuSelect.none;
        }
        if (currentSelect != menuSelect.none) {
            EventSystem.current.SetSelectedGameObject(playerDisplays[0].gameObject);
            selectDisplay.setSubSelect(true);
            selectDisplay.setCurrentSettings(UIOffset.Half, UISide.Right);
        } else {
            selectDisplay.enableSubSelect(false);
        }
    }

    public void openMenu(PlayerBase i) {
        if (currentSelect == menuSelect.job) {
            MenuJob.setUp(i);
        }
        if (currentSelect == menuSelect.ability) {
            MenuAb.setUp(i);
        }
    }
    
}
