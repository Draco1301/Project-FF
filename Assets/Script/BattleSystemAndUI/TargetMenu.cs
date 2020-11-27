using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public enum TargetType { self, party, partyMember, enemy, enemies }
public class TargetMenu : MonoBehaviour
{

    private int nextButtonIndex = 0;
    public Button[] targets = new Button[10];
    [SerializeField] ActionMenu actionMenu;
    [SerializeField] Button btn_prefab;
    public bool IsOpen;

    private void Awake() {
        for (int i=0; i< targets.Length; i++) {
            targets[i] = Instantiate(btn_prefab, this.transform);
            targets[i].gameObject.SetActive(false);
        }
    }

    public void SetUp(List<EnemyInstance> eb, List<PlayerInstance> pb, PlayerInstance player, TargetType t) {
        this.gameObject.SetActive(true);
        IsOpen = true;
        if (t == TargetType.party || t == TargetType.partyMember) {
            foreach (PlayerInstance p in pb) {
                Vector2 pos = Camera.main.WorldToScreenPoint(p.pos);
                pos.x *= transform.GetComponent<RectTransform>().rect.width / Screen.width;
                pos.y *= transform.GetComponent<RectTransform>().rect.height / Screen.height;

                Button b = getNextButton();
                b.GetComponent<RectTransform>().localPosition = pos;
                b.onClick.AddListener(delegate { actionMenu.setTarget(p); turnOff(); UIAudioManager.Select(); });
            }
        } else if (t == TargetType.enemy || t == TargetType.enemies) {
            foreach (EnemyInstance e in eb) {
                Vector2 pos = Camera.main.WorldToScreenPoint(e.pos);
                pos.x *= transform.GetComponent<RectTransform>().rect.width / Screen.width;
                pos.y *= transform.GetComponent<RectTransform>().rect.height / Screen.height;

                Button b = getNextButton();
                b.GetComponent<RectTransform>().localPosition = pos;
                b.onClick.AddListener(delegate { actionMenu.setTarget(e); turnOff(); UIAudioManager.Select(); });
            }
        } else if (t == TargetType.self) {
            Vector2 pos = Camera.main.WorldToScreenPoint(player.pos);
            pos.x *= transform.GetComponent<RectTransform>().rect.width / Screen.width;
            pos.y *= transform.GetComponent<RectTransform>().rect.height / Screen.height;

            Button b = getNextButton();
            b.GetComponent<RectTransform>().localPosition = pos;
            b.onClick.AddListener(delegate { actionMenu.setTarget(player); turnOff(); UIAudioManager.Select(); });
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
        IsOpen = false;
        this.gameObject.SetActive(false);
    }

    private Button getNextButton() {
        targets[nextButtonIndex].gameObject.SetActive(true);
        return targets[nextButtonIndex++];
    }

    private void resetAllButtons() {
        nextButtonIndex = 0;
        for (int i = 0; i < targets.Length; i++) {
            if (targets[i] != null) {
                targets[i].gameObject.SetActive(false);
                targets[i].onClick.RemoveAllListeners();
            }
        }
    }
}
