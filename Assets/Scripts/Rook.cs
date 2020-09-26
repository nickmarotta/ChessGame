using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Chessman
{
    public override bool[,] PossibleMove()
    {
        bool[,] possibleMoves = new bool[8, 8];

        Chessman pieceAtCurrentSpace;
        int i;

        //Right 
        i = CurrentX;
        while (true)
        {
            i++;
            if (i >= 8)
                break;

            pieceAtCurrentSpace = BoardManager.instance.Chessmans[i, CurrentY];
            if (pieceAtCurrentSpace == null)
                possibleMoves[i, CurrentY] = true;
            else
            {
                bool isNotYourPiece = pieceAtCurrentSpace.isWhite != this.isWhite;
                if (isNotYourPiece)
                    possibleMoves[i, CurrentY] = true;

                break;
            }
        }

        //Left 
        i = CurrentX;
        while (true)
        {
            i--;
            if (i < 0)
                break;

            pieceAtCurrentSpace = BoardManager.instance.Chessmans[i, CurrentY];
            if (pieceAtCurrentSpace == null)
                possibleMoves[i, CurrentY] = true;
            else
            {
                bool isNotYourPiece = pieceAtCurrentSpace.isWhite != this.isWhite;
                if (isNotYourPiece)
                    possibleMoves[i, CurrentY] = true;

                break;
            }
        }

        //Up 
        i = CurrentY;
        while (true)
        {

            i++;
            if (i >= 8)
                break;

            pieceAtCurrentSpace = BoardManager.instance.Chessmans[CurrentX, i];
            if (pieceAtCurrentSpace == null)
                possibleMoves[CurrentX, i] = true;

            else
            {
                bool isNotYourPiece = pieceAtCurrentSpace.isWhite != this.isWhite;
                if (isNotYourPiece)
                    possibleMoves[CurrentX, i] = true;

                break;
            }
        }

        //Down 
        i = CurrentY;
        while (true)
        {
            i--;
            if (i < 0)
                break;

            pieceAtCurrentSpace = BoardManager.instance.Chessmans[CurrentX, i];
            if (pieceAtCurrentSpace == null)
                possibleMoves[CurrentX, i] = true;
            else
            {
                bool isNotYourPiece = pieceAtCurrentSpace.isWhite != this.isWhite;
                if (isNotYourPiece)
                    possibleMoves[CurrentX, i] = true;

                break;
            }
        }

        return possibleMoves;
    }
}
