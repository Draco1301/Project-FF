using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAudio : MonoBehaviour
{
    static AttackAudio instance;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip sfx;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }

    public static void PlaySFX() {
        instance.source.PlayOneShot(instance.sfx);
    }
}
