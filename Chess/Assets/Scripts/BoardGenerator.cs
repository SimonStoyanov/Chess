using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    public Sprite squareSprite;
    public Sprite[] whitePieceSprites;
    public Sprite[] blackPieceSprites;

    public Color lightSquare;
    public Color darkSquare;

    private GameObject board;
    private Chess.Board chessBoard;

    // Start is called before the first frame update
    void Start()
    {
        board = new GameObject("ChessBoard");
            board.transform.parent = transform;

        CreateBoard();
        chessBoard = new Chess.Board();
        chessBoard.Initialize();

        DrawPieces();
    }

    void CreateBoard()
    {
        uint i = 0;
        for (int file = 0; file < 8; file++)
        {
            for (int rank = 0; rank < 8; rank++)
            {
                bool isLightSquare = (file + rank) % 2 == 0;

                var squareColor = isLightSquare ? lightSquare : darkSquare;
                Vector2 position = new Vector2(-3.5f + file, -3.5f + rank);

                DrawSquare(squareColor, position, i++);
            }
        }
    }

    private void DrawSquare(Color squareColor, Vector2 position, uint squareId)
    {
        GameObject square = new GameObject("square"+squareId);

        var renderer = square.AddComponent<SpriteRenderer>();
            renderer.sprite = squareSprite;
            renderer.color = squareColor;

        square.transform.parent = board.transform;
        square.transform.position = position;
    }

    private void DrawPieces()
    {
        int iterator = 0;
        for (int file = 0; file < 8; file++)
        {
            for (int rank = 0; rank < 8; rank++)
            {
                int piece = chessBoard.GetSquare(iterator); 
                Sprite[] usedPieceSet = Chess.Piece.isColour(piece, Chess.Piece.White) ? whitePieceSprites : blackPieceSprites;
                int pieceType = Chess.Piece.PieceType(piece);

                Sprite usedPiece;

                switch (pieceType)
                {
                    case Chess.Piece.Pawn:
                        usedPiece = usedPieceSet[0];
                        break;
                    case Chess.Piece.Knight:
                        usedPiece = usedPieceSet[1];
                        break;
                    case Chess.Piece.Bishop:
                        usedPiece = usedPieceSet[2];
                        break;
                    case Chess.Piece.Rook:
                        usedPiece = usedPieceSet[3];
                        break;
                    case Chess.Piece.Queen:
                        usedPiece = usedPieceSet[4];
                        break;
                    case Chess.Piece.King:
                        usedPiece = usedPieceSet[5];
                        break;
                    default:
                        Debug.Log("no piece");
                        iterator++;
                        continue;
                }

                GameObject pieceToDraw = new GameObject("piece");
                pieceToDraw.transform.position = new Vector2(-3.5f + file, -3.5f + rank);
                pieceToDraw.AddComponent<SpriteRenderer>().sprite = usedPiece;
                pieceToDraw.AddComponent<BoxCollider2D>().size = new Vector2(1, 1);
                pieceToDraw.AddComponent<MovePiece>();

                iterator++;
            }
        }
    }
}
