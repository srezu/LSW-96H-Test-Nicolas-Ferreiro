using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.EventSystems;
using UnityEngine.UI;


/*This class allows an object to be dragged and dropped elsewhere, use it to move items from slot to slot*/
public class DragDrop : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler
{

    public Canvas canvas;

    public RectTransform _rectTransform;
    public Vector3 _initialRecTransform;
    public Vector2 _initialRAnchoredPos;

    
    private bool _onDrag;
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        canvas = FindObjectOfType<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_onDrag) return;

       EventManager.Call(Constantes.TogglePlayerInput, new TogglePlayerInputDP() { toggle = true});
       _initialRecTransform = _rectTransform.position;
       _initialRAnchoredPos = _rectTransform.anchoredPosition;
       eventData.pointerDrag.GetComponent<Image>().raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _onDrag = false;
        _rectTransform.position = _initialRecTransform;
        _rectTransform.anchoredPosition = _initialRAnchoredPos;
        eventData.pointerDrag.GetComponent<Image>().raycastTarget = true;
        EventManager.Call(Constantes.TogglePlayerInput, new TogglePlayerInputDP() { toggle = false});
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        _onDrag = true;
    }

   
}
