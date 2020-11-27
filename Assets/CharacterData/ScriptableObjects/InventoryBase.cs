using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Character/InventoryBase", order = 4)]
public class InventoryBase: ScriptableObject {
    public static string Elixer = "Elixer";
    public static string potion = "Potion";
    public static string Pheonix = "Pheonix";

    public Dictionary<string, int> Invenory = new Dictionary<string, int>{
        {Elixer, 0 },
        {potion, 0 },
        {Pheonix, 0 },
    };

    public int[] amount;


}
