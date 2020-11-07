using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageDisplay : MonoBehaviour
{
    public static DamageDisplay instance;
    public static bool isDisplayingDamage = false;
    public TextMeshProUGUI textPrefab;
    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }

    public static void DisplayDamage(CharacterInstance c, int damage) {
        TextMeshProUGUI temp = Instantiate(instance.textPrefab, instance.transform);
        Vector2 pos = Camera.main.WorldToScreenPoint(c.pos);
        Debug.Log(pos);
        pos.x *= instance.transform.GetComponent<RectTransform>().rect.width / Screen.width;
        pos.y *= instance.transform.GetComponent<RectTransform>().rect.height / Screen.height;
        temp.GetComponent<RectTransform>().localPosition = pos;
        temp.text = damage.ToString();
        instance.StartCoroutine(destroyDamage(temp));
    }

    private static IEnumerator destroyDamage(TextMeshProUGUI t) {
        isDisplayingDamage = true;
        yield return new WaitForSeconds(1);
        isDisplayingDamage = false;
        Destroy(t.gameObject);
    }
}
