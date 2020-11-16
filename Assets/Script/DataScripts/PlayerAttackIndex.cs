using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerAttackIndex
{
    public static void getAttack(GameObject o, int i) {
        switch (i) {
            case 0:
                //this one shouldn't really ever be called
                o.AddComponent<PA_Fight>();
                break;
            case 1:
                o.AddComponent<EA_Bite>();
                break;
            case 2:
                o.AddComponent<EA_Bite>();
                break;
            case 12:
                break;
            default:
                o.AddComponent<PA_Fight>();
                break;
        }

    }

    public static string getAttackName(GameObject o, int i) {
        switch (i) {
            case 0:
                return "Fight";
            case 1:
                return "Fight";
            case 2:
                return "Fight";
            case 3:
                return "Fight";
            case 4:
                return "Fight";
            case 5:
                return "Fight";
            case 6:
                return "Fight";
            case 7:
                return "Fight";
            case 8:
                return "Fight";
            case 9:
                return "Fight";
            case 10:
                return "Fight";
            case 11:
                return "Fight";
            case 12:
                return "Fight";
            default:
                return "Fight";
        }
        return "Error";
    }
}
