using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleDataHolder : MonoBehaviour
{
    [SerializeField] EnemyBase[] list;
    [SerializeField] Vector2[] pos;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<PlayerMove>()) {
            CharacterDataTransfer.StartBattle(list, pos);
        }
    }

}
