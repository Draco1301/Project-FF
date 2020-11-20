using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerAttackIndex
{
    public static void getAttack(GameObject o, int i) {
        switch (i) {
            case 0:
                o.AddComponent<PA_Fight>();
                break;
            case 1:
                o.AddComponent<PA_Cure>();
                break;
            case 2:
                o.AddComponent<PA_Revive>();
                break;
            case 3:
                o.AddComponent<PA_CureAll>();
                break;
            case 4:
                o.AddComponent<PA_Fire>();
                break;
            case 5:
                o.AddComponent<PA_Fire2>();
                break;
            case 6:
                o.AddComponent<PA_Fire3>();
                break;
            case 7:
                o.AddComponent<PA_Focus>();
                break;
            case 8:
                o.AddComponent<PA_Kick>();
                break;
            case 9:
                o.AddComponent<PA_Counter>();
                break;
            case 10:
                o.AddComponent<PA_Gaurd>();
                break;
            case 11:
                o.AddComponent<PA_Strike>();
                break;
            case 12:
                o.AddComponent<PA_TwoHanded>();
                break;
            default:
                o.AddComponent<PA_Fight>();
                break;
        }

    }

    public static string getAttackName(int i) {
        switch (i) {
            case 0:
                return "Fight";
            case 1:
                return "Cure";
            case 2:
                return "Revive";
            case 3:
                return "Cure All";
            case 4:
                return "Fire";
            case 5:
                return "Fire II";
            case 6:
                return "Fire III";
            case 7:
                return "Focus";
            case 8:
                return "Kick";
            case 9:
                return "Counter";
            case 10:
                return "Gaurd";
            case 11:
                return "Strike";
            case 12:
                return "Two Hands";
            default:
                return "Fight";
        }
    }
}
