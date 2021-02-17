using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovePiece : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isDragging = false;
    GameObject selectedPiece;
    Vector2 position;

    private void Update()
    {
        if (isDragging == true)
        {
            position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Debug.Log(position);

            selectedPiece.transform.position = position;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;

        selectedPiece = eventData.pointerCurrentRaycast.gameObject;


        Debug.Log("hello");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;

        selectedPiece = null;
    }
}
