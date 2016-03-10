using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour, IDropHandler {

	public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }

            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        String mytag = gameObject.tag;
        String dragTag = eventData.pointerDrag.tag;
        String enterTag = eventData.pointerEnter.tag;
        if (!item && gameObject.tag == eventData.pointerDrag.tag)
        {
            DragHandler.itemBeeingDragged.transform.SetParent(transform);
            ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
        }
    }
}
