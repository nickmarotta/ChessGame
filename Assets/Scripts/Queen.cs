using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Chessman
{
    public override bool[,] PossibleMove()
    {
        bool[,] possibleMoves = new bool[8, 8];

        Chessman pieceAtCurrentSpace;
        int i, j;

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
