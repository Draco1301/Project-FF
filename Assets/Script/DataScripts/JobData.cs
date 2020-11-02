using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Jobs { None, White, Black, Monk, Knight}
public static class JobData 
{
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
