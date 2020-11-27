using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum UIOffset { Double = 4, Half = 1 }
public enum UISide { Left = -1, Right = 1 }
public class SelectDisplay : MonoBehaviour
{
    [SerializeField] RectTransform currentlySelected;
    [SerializeField] RectTransform subSelect;
    public bool active;
    UIOffset uiOffset = UIOffset.Double;
    UISide uiSide = UISide.Left;

    // Update is called once per frame
    void Update() {
        if (active && EventSystem.current.currentSelectedGameObject != null) {
            currentlySelected.gameObject.SetActive(true);
            RectTransform temp = EventSystem.current.currentSelectedGameObject.GetComponent<RectTransform>();
            currentlySelected.localPosition = temp.position - new Vector3(Screen.width/2, Screen.height / 2, 0) + (int)(uiSide) * new Vector3((float)(uiOffset) /2 * temp.rect.width,0,0);
        } else {
            currentlySelected.gameObject.SetActive(false);
            subSelect.gameObject.SetActive(false);
        }
    }

    public void setCurrentSettings(UIOffset uio, UISide uis) {
        uiOffset = uio;
        uiSide = uis;
        currentlySelected.localScale = new Vector3(-1f*(int)(uis),1f,1f);
    }   

    public void setSubSelect(bool b) {
        subSelect.gameObject.SetActive(b);

        subSelect.localPosition = currentlySelected.localPosition;
        subSelect.localScale = new Vector3(-1f * (int)(uiSide), 1f, 1f);
    }

    public void enableSubSelect(bool b) {
        subSelect.gameObject.SetActive(b);
    }


}
