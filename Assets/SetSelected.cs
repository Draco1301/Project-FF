using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SetSelected : MonoBehaviour, IPointerEnterHandler, ISelectHandler {
    public void OnPointerEnter(PointerEventData eventData) {
        if (this.GetComponent<Button>() != null && this.GetComponent<Button>().interactable) {
            EventSystem.current.SetSelectedGameObject(this.gameObject);
        }
    }

    public void OnSelect(BaseEventData eventData) {
        if (this.GetComponent<Button>() != null && this.GetComponent<Button>().interactable) {
            UIAudioManager.instance.onMove();
        }
    }

    private void Start() {
        this.GetComponent<Button>().onClick.AddListener(delegate { 
            Debug.Log("called", this.gameObject); 
            UIAudioManager.instance.select();
        } );
    }
    
}
