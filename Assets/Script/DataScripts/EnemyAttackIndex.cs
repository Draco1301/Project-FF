using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyAttackIndex
{
    public static void getAttack(GameObject o, int i) {
        switch (i) {
            case 0:
                o.AddComponent<EA_Bite>();
                break;
            case 1:
                o.AddComponent<EA_Gust>();
                break;
            case 2:
                o.AddComponent<EA_Shock>();
                break;
        }
    
    }
}
