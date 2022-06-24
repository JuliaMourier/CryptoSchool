using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : DragDrop, IDropHandler
{
    public int idSlot;
    private GameObject itemDragged;
    private DragDrop item;
    private bool isEmpty;

    private void Start()
    {
        isEmpty = true;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            itemDragged = eventData.pointerDrag.gameObject;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            isEmpty = false;
        }
    }

    public bool ValidationReponseItem()
    {
        if (!isEmpty)
            return (itemDragged.GetComponent<DragDrop>().idItem == idSlot);
        else
            return false;
    }

}
