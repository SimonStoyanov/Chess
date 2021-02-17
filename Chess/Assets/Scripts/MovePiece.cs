using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovePiece : MonoBehaviour, IPointerDownHandler
{
    bool isDragging = false;

    private void Update()
    {
        if (isDragging == true)
        {

        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
     
        Debug.Log("hello");
    }
}
