using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Jobs { None, White, Black, Monk, Knight}
public static class JobData 
{
    public static int[] getJobAttacks(Jobs j, int exp) {
        int[] attacks ;
        LinkedList<int> temp = new LinkedList<int>();

        switch (j) {
            case Jobs.None:
                break;
            case Jobs.White:
                if (exp > 10) {
                    temp.AddLast(1);
                }
                if (exp > 20) {
                    temp.AddLast(2);
                }
                if (exp > 30) {
                    temp.AddLast(3);
                }
                break;
            case Jobs.Black:
                if (exp > 10) {
                    temp.AddLast(4);
                }
                if (exp > 20) {
                    temp.AddLast(5);
                }
                if (exp > 30) {
                    temp.AddLast(6);
                }
                break;
            case Jobs.Monk:
                if (exp > 10) {
                    temp.AddLast(7);
                }
                if (exp > 20) {
                    temp.AddLast(8);
                }
                if (exp > 30) {
                    temp.AddLast(9);
                }
                break;
            case Jobs.Knight:
                if (exp > 10) {
                    temp.AddLast(10);
                }
                if (exp > 20) {
                    temp.AddLast(11);
                }
                if (exp > 30) {
                    temp.AddLast(12);
                }
                break;
        }


        attacks = new int[temp.Count];
        temp.CopyTo(attacks,0);
        return attacks;
    }

    public static string getJobName(Jobs j) {
        switch (j) {
            case Jobs.White:
                return "WHITE";
                break;
            case Jobs.Black:
                return "BLACK";
                break;
            case Jobs.Monk:
                return "FIST";
                break;
            case Jobs.Knight:
                return "SWORD";
                break;
            default:
                return "";
                break;
        }
    }
}
