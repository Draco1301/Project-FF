using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAudio : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip gameover;


    // Update is called once per frame
    void Update()
    {
        if (BattleSystemManager.instance.isGameOver && audioSource.clip != gameover) {
            audioSource.Stop();
            audioSource.clip = gameover;
            audioSource.Play();
        }
    }
}
