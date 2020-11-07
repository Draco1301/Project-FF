using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetMenu : MonoBehaviour
{
    private List<EnemyInstance> Enemies;
    private List<PlayerInstance> Players;
    private int nextButtonIndex = 0;
    private Button[] targets = new Button[10];
    [SerializeField] ActionMenu actionMenu;
    [SerializeField] Button btn_prefab;

    private void Awake() {
        for (int i=0; i< targets.Length; i++) {
            targets[i] = Instantiate(btn_prefab, this.transform);
            targets[i].gameObject.SetActive(false);
        }
    }

    public void SetUp(List<EnemyInstance> eb, List<PlayerInstance> pb) {
        this.gameObject.SetActive(true);


        foreach (PlayerInstance p in pb) {
            Vector2 pos = Camera.main.WorldToScreenPoint(p.pos);
            pos.x *= transform.GetComponent<RectTransform>().rect.width  / Screen.width;
            pos.y *= transform.GetComponent<RectTransform>().rect.height / Screen.height;
            //pos.x += transform.GetComponent<RectTransform>().rect.width  / 2;
            //pos.y += transform.GetComponent<RectTransform>().rect.height / 2;

            Button b = getNextButton();
            b.GetComponent<RectTransform>().localPosition = pos;
            b.onClick.AddListener(delegate { actionMenu.setTarget(p); turnOff(); });
        }

        foreach (EnemyInstance e in eb) {
            Vector2 pos = Camera.main.WorldToScreenPoint(e.pos);
            pos.x *= transform.GetComponent<RectTransform>().rect.width / Screen.width;
            pos.y *= transform.GetComponent<RectTransform>().rect.height / Screen.height;
            //pos.x += transform.GetComponent<RectTransform>().rect.width  / 2;
            //pos.y += transform.GetComponent<RectTransform>().rect.height / 2;

            Button b = getNextButton();
            b.GetComponent<RectTransform>().localPosition = pos;
            b.onClick.AddListener(delegate { actionMenu.setTarget(e); turnOff(); });
        }
    }

    private void Update() {
        if (BattleSystemManager.AttackInProgress == targets[0].IsActive() ) {
            for (int i = 0; i < nextButtonIndex; i++) {
                targets[i].gameObject.SetActive(!BattleSystemManager.AttackInProgress);
            }
        }
    }

    public void turnOff() {
        resetAllButtons();
        this.gameObject.SetActive(false);
    }

    private Button getNextButton() {
        targets[nextButtonIndex].gameObject.SetActive(true);
        return targets[nextButtonIndex++];
    }

    private void resetAllButtons() {
        nextButtonIndex = 0;
        for (int i = 0; i < targets.Length; i++) {
            targets[i].gameObject.SetActive(false);
            targets[i].onClick.RemoveAllListeners();
        }
    }
}
