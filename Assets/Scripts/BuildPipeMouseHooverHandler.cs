using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class BuildPipeMouseHooverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	private Text textTooltipText;

	// Use this for initialization
	void Start ()
	{
		textTooltipText = GameObject.FindGameObjectWithTag ("tooltipText").GetComponent<Text> ();
	}

	public void OnPointerEnter (PointerEventData eventData)
	{
		RunModuleVO runModuleVO = gameObject.GetComponent<RunModuleVO> ();
		textTooltipText.text = runModuleVO.getToolTipText ();
		//textTooltipText.text = gameObject.name;
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		textTooltipText.text = "";
	}

    
	
	
}
