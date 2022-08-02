using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class MyButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler 
{
     
    public bool buttonPressed = false;
     
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("button pressed");
    }
     
    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = true;
    }
}
