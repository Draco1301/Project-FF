using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetMenu : MonoBehaviour
{
    EnemyBase[] Enemies;
    PlayerBase[] Players;
    List<Button> targets = new List<Button>();
    [SerializeField] ActionMenu actionMenu;
    [SerializeField] Button btn_prefab;

    public void SetUp(EnemyBase[] eb, PlayerBase[] pb) {
        this.gameObject.SetActive(true);

        foreach (PlayerBase p in pb) {
            Vector2 pos = Camera.main.WorldToScreenPoint(p.pos);
            pos.x *= transform.GetComponent<RectTransform>().rect.width  / Screen.width;
            pos.y *= transform.GetComponent<RectTransform>().rect.height / Screen.height;
            //pos.x += transform.GetComponent<RectTransform>().rect.width  / 2;
            //pos.y += transform.GetComponent<RectTransform>().rect.height / 2;

            Button b = Instantiate(btn_prefab, this.transform);
            targets.Add(b);
            b.GetComponent<RectTransform>().localPosition = pos;
            b.onClick.AddListener(delegate { actionMenu.setTarget(p); turnOff(); });
        }

        foreach (EnemyBase e in eb) {
            Vector2 pos = Camera.main.WorldToScreenPoint(e.pos);
            pos.x *= transform.GetComponent<RectTransform>().rect.width / Screen.width;
            pos.y *= transform.GetComponent<RectTransform>().rect.height / Screen.height;
            //pos.x += transform.GetComponent<RectTransform>().rect.width  / 2;
            //pos.y += transform.GetComponent<RectTransform>().rect.height / 2;

            Button b = Instantiate(btn_prefab, this.transform);
            targets.Add(b);
            b.GetComponent<RectTransform>().localPosition = pos;
            b.onClick.AddListener(delegate { actionMenu.setTarget(e); turnOff(); });
        }
    }

    public void turnOff() {
        foreach (Button b in targets) {
            Destroy(b.transform.gameObject);
        }
        targets.Clear();
        this.gameObject.SetActive(false);
    }
}
