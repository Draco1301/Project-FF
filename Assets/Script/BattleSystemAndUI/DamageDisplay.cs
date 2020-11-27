using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageDisplay : MonoBehaviour
{
    public static DamageDisplay instance;
    public static bool isDisplayingDamage = false;
    public TextMeshProUGUI textPrefab;
    static Color defualtColor = Color.white;
    [SerializeField] AnimationCurve curve;
    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }

    public static IEnumerator DisplayDamage(CharacterInstance c, int damage, Color color = default(Color)) {
        if (color == default(Color)) {
            color = defualtColor;
        }

        TextMeshProUGUI temp = Instantiate(instance.textPrefab, instance.transform);
        temp.color = color;
        Vector2 pos = Camera.main.WorldToScreenPoint(c.pos);
        pos.x *= instance.transform.GetComponent<RectTransform>().rect.width / Screen.width;
        pos.y *= instance.transform.GetComponent<RectTransform>().rect.height / Screen.height;
        temp.GetComponent<RectTransform>().localPosition = pos;
        temp.text = damage.ToString();


        IEnumerator loop = destroyDamage(temp);
        while (loop.MoveNext()) {
            yield return loop.Current;
        }
    }

    private static IEnumerator destroyDamage(TextMeshProUGUI t) {
        isDisplayingDamage = true;
        LeanTween.moveY(t.GetComponent<RectTransform>(), t.GetComponent<RectTransform>().anchoredPosition.y+30, 0.9f).setEase(instance.curve);
        yield return new WaitForSeconds(1);
        isDisplayingDamage = false;
        Destroy(t.gameObject);
    }
}
