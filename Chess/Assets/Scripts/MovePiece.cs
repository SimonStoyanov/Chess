using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovePiece : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isDragging = false;
    GameObject selectedPiece;
    Vector2 position;

    private GameObject draftPiece;

    [HideInInspector]
    public GameObject highlighter;

    private void Start()
    {
    }

    private void Update()
    {
        UpdatePiecePosition();
    }

    private void UpdatePiecePosition()
    {
        if (isDragging == true)
        {
            position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedPiece.transform.position = position;
            WorldPosToSquarePos(highlighter);
        }
    }

    private void WorldPosToSquarePos(GameObject gameObject)
    {
        Vector2 coordPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(3.5f, 3.5f, 0.0f);
        coordPos = Chess.Math.RoundV(coordPos, 0);
        gameObject.transform.position = new Vector2(coordPos.x - 3.5f, coordPos.y - 3.5f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;

        selectedPiece = eventData.pointerCurrentRaycast.gameObject;

        draftPiece = Instantiate(selectedPiece);
        SpriteRenderer sr = draftPiece.GetComponent<SpriteRenderer>();
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, .5f);
        draftPiece.SetActive(true);

        highlighter.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;

        WorldPosToSquarePos(selectedPiece);

        selectedPiece = null;
        Destroy(draftPiece);

        highlighter.SetActive(false);
    }
}
