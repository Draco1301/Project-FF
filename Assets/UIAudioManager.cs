using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudioManager : MonoBehaviour
{
    public static UIAudioManager instance;
    [SerializeField] AudioClip selectSound;
    [SerializeField] AudioClip cursorSound;
    [SerializeField] AudioClip cancelSound;
    [SerializeField] AudioSource source;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }

    public void select() {
        source.PlayOneShot(instance.selectSound);
    }

    public void onMove() {
        source.PlayOneShot(instance.cursorSound);
    }

    public static void Select() {
        instance.source.PlayOneShot(instance.selectSound);   
    }

    public static void Cancel() {
        instance.source.PlayOneShot(instance.cancelSound);
    }
}
