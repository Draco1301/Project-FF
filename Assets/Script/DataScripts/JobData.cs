using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Jobs { None, White, Black, Monk, Knight}
public struct JobBonusStats {
    public JobBonusStats(int x, int y, int z, int w) {
        Strength = x;
        Agility = y;
        Stamina = z;
        Magic = w;
    }

    public bool equalTo(JobBonusStats j) {
        return (j.Strength == this.Strength && j.Agility == this.Agility && j.Stamina == this.Stamina && j.Magic == this.Magic);
    }

    public int Strength;
    public int Agility;
    public int Stamina;
    public int Magic;
}
public static class JobData {
    public static int masteredLevel = 32;

    public static readonly JobBonusStats NONE = new JobBonusStats(0, 0, 0, 0);
    public static readonly JobBonusStats BLACK = new JobBonusStats(-2, 1, 5, 10);
    public static readonly JobBonusStats WHITE = new JobBonusStats(-2, 5, 1, 10);
    public static readonly JobBonusStats MONK = new JobBonusStats(5, 10, 1, -2);
    public static readonly JobBonusStats KNIGHT = new JobBonusStats(5, 1, 10, -2);

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
                return "MONK";
                break;
            case Jobs.Knight:
                return "SWORD";
                break;
            default:
                return "";
                break;
        }
    }

    public static JobBonusStats getBonusStats(PlayerBase pb) {
        switch (pb.job) {
            case Jobs.None:
                return getBestStats(pb);
            case Jobs.White:
                return WHITE;
            case Jobs.Black:
                return BLACK;
            case Jobs.Monk:
                return MONK;
            case Jobs.Knight:
                return KNIGHT;
            default:
                return NONE;
        }
    }

    private static JobBonusStats getBestStats(PlayerBase pb) {
        JobBonusStats temp = new JobBonusStats(0,0,0,0);
        
        if (pb.BLACK_LEVEL >= masteredLevel) {
            updateStats(temp, BLACK);
        }
        if (pb.WHITE_LEVEL >= masteredLevel) {
            updateStats(temp, WHITE);
        }
        if (pb.MONK_LEVEL >= masteredLevel) {
            updateStats(temp, MONK);
        }
        if (pb.KNIGHT_LEVEL >= masteredLevel) {
            updateStats(temp, KNIGHT);
        }

        return temp;

    }

    private static void updateStats(JobBonusStats toChange, JobBonusStats compare) {
        if (compare.Strength > toChange.Strength) {
            toChange.Strength = compare.Strength;
        }
        if (compare.Agility > toChange.Agility) {
            toChange.Agility = compare.Agility;
        }
        if (compare.Stamina > toChange.Stamina) {
            toChange.Stamina = compare.Stamina;
        }
        if (compare.Magic > toChange.Magic) {
            toChange.Magic = compare.Magic;
        }
    }

}
