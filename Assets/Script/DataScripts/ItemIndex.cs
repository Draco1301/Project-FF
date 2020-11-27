using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemIndex
{
    public static IPlayerAttack GetIitems(GameObject o, string n) {
        IPlayerAttack temp;
        if (n.Equals("Elixer")) {
            temp = o.AddComponent<IT_Elixer>();
        } else if (n.Equals("Potion")) {
            temp = o.AddComponent<IT_Potion>();
        } else {
            temp = o.AddComponent<IT_Pheonix>();
        }

        return temp;
    }
}
