using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenu : MonoBehaviour
{

    public Button[] buttons;
    public bool IsOpen;

    [SerializeField] InventoryInstance inventoryRef;
    public int[] amount;
    private string[] names;

    public void setUp() {
        amount = inventoryRef.getAmount();
        names = inventoryRef.getNames();
        resetMenu();
        int c = 0;
        for (int i=0; i < amount.Length && i < buttons.Length; i++) {
            if (amount[i] > 0) {
                buttons[c].gameObject.SetActive(true);
                buttons[c].GetComponentInChildren<TextMeshProUGUI>().SetText(names[i]);
                buttons[c].interactable = true;
                c++;
            }
        }
    }

    public void resetMenu() { 
        for (int i = 0; i < buttons.Length; i++) {
            buttons[i].gameObject.SetActive(false);
        }
    }

    public void setEnableMenu(bool b) {
        for (int i = 0; i < buttons.Length; i++) {
            buttons[i].interactable = b;
        }
    }

    public void setShowMenu(bool b) {
        IsOpen = b;
        this.gameObject.SetActive(b);
        if (IsOpen) {
            LeanAnimation.OpenUI(this.gameObject);
        }
    }
    
    public void setAttack(int i) {
        setEnableMenu(false);
        ItemIndex.GetIitems(ActionMenu.instance.gameObject, names[i]);
        ActionMenu.Start_Action();
    }

}
