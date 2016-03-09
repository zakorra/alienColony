using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class Equipment : MonoBehaviour, IHasChanged {
    [SerializeField] Boolean isEquipment;
    [SerializeField] Transform slots;
    [SerializeField] Text moduleText;


    // Use this for initialization
    void Start () {
        HasChanged();
	}
	
    public void HasChanged()
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        builder.Append(" - ");
        if (isEquipment) {
            foreach (Transform slotTransform in slots) {
                GameObject item = slotTransform.GetComponent<Slot>().item;
                if (item) {
                    builder.Append(item.name);
                    builder.Append(" - ");
                }
            }
        }
        moduleText.text = builder.ToString();
    }
}

namespace UnityEngine.EventSystems
{
    public interface IHasChanged : IEventSystemHandler
    {
        void HasChanged();
    }
}