﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class JobButton : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] TextMeshProUGUI Name;
    [SerializeField] TextMeshProUGUI Desception;
    [TextArea]
    [SerializeField] string NameText;
    [TextArea]
    [SerializeField] string DesceptionText;
      
    public void OnPointerEnter(PointerEventData eventData) {
        Name.text = NameText;
        Desception.text = DesceptionText;
        EventSystem.current.SetSelectedGameObject(this.gameObject);
    }

    private void Update() {
        if(EventSystem.current.currentSelectedGameObject == this.gameObject){
            Name.text = NameText;
            Desception.text = DesceptionText;
        }
    }
}
