using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class MouseHooverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    private Text textTooltipText;

    // Use this for initialization
    void Start() {
        textTooltipText = GameObject.FindGameObjectWithTag("tooltipText").GetComponent<Text>();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        textTooltipText.text = gameObject.name;
    }

    public void OnPointerExit(PointerEventData eventData) {
        textTooltipText.text = "";
    }

    
	
	
}
