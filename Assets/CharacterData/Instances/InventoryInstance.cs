using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInstance : MonoBehaviour {
    public static InventoryInstance instacne;

    private InventoryBase IB;
    public Dictionary<string, int> Invenory = new Dictionary<string, int>();
    public int[] amount;

    public void Awake() {
        if (instacne == null) {
            instacne = this;
        } else {
            Destroy(this);
        }
    }

    public void loadData(InventoryBase IB) {
        this.IB = IB;
        int i = 0;
        amount = new int[IB.amount.Length];
        for (int n=0; n<IB.amount.Length;n++) {
            amount[n] = IB.amount[i];
        }
        foreach (KeyValuePair<string, int> pair in IB.Invenory) {
            Invenory.Add(pair.Key, amount[i++]);
        }
    }

    public void saveData() {
        int i = 0;
        foreach (KeyValuePair<string, int> pair in Invenory) {
            IB.Invenory[pair.Key] = amount[i++];
        }
        IB.amount = amount;
    }

    public string[] getNames() {
        string[] names = new string[Invenory.Count];
        int counter = 0;
        foreach (KeyValuePair<string, int> pair in Invenory) {
            names[counter++] = pair.Key;
        }
        return names;
    }

    public Dictionary<string, int> getInventory() {
        return Invenory;
    }

    public int[] getAmount() {
        return amount;
    }

    public static void useItem(string key) {
        instacne.Invenory[key] -= 1;
        int i = 0;
        foreach (KeyValuePair<string, int> pair in instacne.Invenory) {
            instacne.amount[i++] = instacne.Invenory[pair.Key];
        }
    }
}
