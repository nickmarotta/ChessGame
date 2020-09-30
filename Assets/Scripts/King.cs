using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Chessman
{
    public override bool[,] PossibleMove()
    {
        bool[,] possibleMoves = new bool[8, 8];
        Chessman pieceAtCurrentSpace;
        int i, j;

        //Top Side 
        i = CurrentX - 1;
        j = CurrentY + 1;
        if (CurrentY != 7)
        {
            // Running this loop 3 times allows us to check Diagonal Left, Up and Diagonal Right 
            for (int k = 0; k < 3; k++)
            {
                if (i >= 0 && i < 8)
                {
                    pieceAtCurrentSpace = BoardManager.instance.Chessmans[i, j];
                    if (pieceAtCurrentSpace == null)
                        possibleMoves[i, j] = true;
                    else if (isEnemyPiece(pieceAtCurrentSpace))
                        possibleMoves[i, j] = true;
                }
                i++; //Increment the x board coord that we're searching 
            }
        }

        //Down Side 
        i = CurrentX - 1;
        j = CurrentY - 1;
        if (CurrentY != 0)
        {
            // Running this loop 3 times allows us to check Diagonal Left, Up and Diagonal Right 
            for (int k = 0; k < 3; k++)
            {
                if (i >= 0 && i < 8)
                {
                    pieceAtCurrentSpace = BoardManager.instance.Chessmans[i, j];
                    if (pieceAtCurrentSpace == null)
                        possibleMoves[i, j] = true;
                    else if (isEnemyPiece(pieceAtCurrentSpace))
                        possibleMoves[i, j] = true;
                }
                i++; //Increment the x board coord that we're searching 
            }
        }

        //Middle Left 
        if (CurrentX != 0)
        {
            pieceAtCurrentSpace = BoardManager.instance.Chessmans[CurrentX - 1, CurrentY];
            if (pieceAtCurrentSpace == null || isEnemyPiece(pieceAtCurrentSpace))
                possibleMoves[CurrentX - 1, CurrentY] = true;
        }

        //Middle Right 
        if (CurrentX != 7)
        {
            pieceAtCurrentSpace = BoardManager.instance.Chessmans[CurrentX + 1, CurrentY];
            if (pieceAtCurrentSpace == null || isEnemyPiece(pieceAtCurrentSpace))
                possibleMoves[CurrentX + 1, CurrentY] = true;
        }

        return possibleMoves;
    }
}
