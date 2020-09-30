using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Chessman
{
    public override bool[,] PossibleMove()
    {
        bool[,] possibleMoves = new bool[8, 8];
        Chessman pieceAtCurrentSpace;

        int i, j;
        // Top Left 
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i--;
            j++;
            if (i < 0 || j >= 8)
                break;

            pieceAtCurrentSpace = BoardManager.instance.Chessmans[i, j];
            if (pieceAtCurrentSpace == null)
                possibleMoves[i, j] = true;
            else 
            {
                if (isWhite != pieceAtCurrentSpace.isWhite)
                    possibleMoves[i, j] = true;
                break;
            }
        }

        // Top Right 
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i++;
            j++;
            if (i >= 8 || j >= 8)
                break;

            pieceAtCurrentSpace = BoardManager.instance.Chessmans[i, j];
            if (pieceAtCurrentSpace == null)
                possibleMoves[i, j] = true;
            else 
            {
                if (isWhite != pieceAtCurrentSpace.isWhite)
                    possibleMoves[i, j] = true;
                break;
            }
        }

        // Down Left 
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i--;
            j--;
            if (i < 0 || j < 0)
                break;

            pieceAtCurrentSpace = BoardManager.instance.Chessmans[i, j];
            if (pieceAtCurrentSpace == null)
                possibleMoves[i, j] = true;
            else 
            {
                if (isWhite != pieceAtCurrentSpace.isWhite)
                    possibleMoves[i, j] = true;
                break;
            }
        }

        // Down Right 
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i++;
            j--;
            if (i >= 8 || j < 0)
                break;

            pieceAtCurrentSpace = BoardManager.instance.Chessmans[i, j];
            if (pieceAtCurrentSpace == null)
                possibleMoves[i, j] = true;
            else 
            {
                if (isWhite != pieceAtCurrentSpace.isWhite)
                    possibleMoves[i, j] = true;
                break;
            }
        }

        return possibleMoves;
    }
}
