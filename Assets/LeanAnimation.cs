using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LeanAnimation
{
    public static float TIME = 0.1f;

    public static void sideAnimation(GameObject character, float distance) {
        AttackAudio.PlaySFX();
        Vector3 pos = character.transform.position;
        LeanTween.moveX(character, pos.x + distance, TIME).setOnComplete(() => revertSideAnimation(character, distance));
    }

    private static void revertSideAnimation(GameObject character, float distance) {
        LeanTween.moveX(character, character.transform.position.x - distance, TIME);
    }

    public static void OpenUI(GameObject obj) {
        obj.transform.localScale = new Vector3(0,0,0);
        LeanTween.scale(obj, new Vector3(1,1,1), 0.05f);
    }

    public static void closeUI(GameObject obj) {
        obj.transform.localScale = new Vector3(1, 1, 1);
        LeanTween.scale(obj, new Vector3(0, 0, 0), 0.05f);
    }
}
