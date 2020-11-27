using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataState : MonoBehaviour
{
    [SerializeField] PlayerBase[] players;
    [SerializeField] InventoryBase inventory;
    static PlayerDataState instance = null;
    
    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }    
    }

    public static PlayerBase[] getPlayers() {
        return instance.players;
    }

    public static InventoryBase getInventory() {
        return instance.inventory;
    }
}
