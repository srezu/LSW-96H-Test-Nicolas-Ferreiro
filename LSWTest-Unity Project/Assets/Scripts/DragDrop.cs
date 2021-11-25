using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour,IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
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

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_onDrag) return;
        EventManager.Call(Constantes.TogglePlayerInput, new TogglePlayerInputDP() { toggle = true});
        _initialRecTransform = _rectTransform.position;
        _initialRAnchoredPos = _rectTransform.anchoredPosition;
        // Debug.Log("OnPointerDown");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
       // Debug.Log("OnBeginDrag");       
        _onDrag = true;


        eventData.pointerDrag.GetComponent<Image>().raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       // Debug.Log("OnEndDrag");
        _onDrag = false;
        _rectTransform.position = _initialRecTransform;
        _rectTransform.anchoredPosition = _initialRAnchoredPos;
        eventData.pointerDrag.GetComponent<Image>().raycastTarget = true;
        EventManager.Call(Constantes.TogglePlayerInput, new TogglePlayerInputDP() { toggle = false});
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        _rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;


    }

   
}
