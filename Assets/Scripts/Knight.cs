using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Chessman
{
    public override bool[,] PossibleMove()
    {
        bool[,] possibleMoves = new bool[8, 8];

        //Up Left 
        KnightMove(CurrentX - 1, CurrentY + 2, ref possibleMoves);

        //Up Right 
        KnightMove(CurrentX + 1, CurrentY + 2, ref possibleMoves);

        //Right Up
        KnightMove(CurrentX + 2, CurrentY + 1, ref possibleMoves);

        //Right Down
        KnightMove(CurrentX + 2, CurrentY - 1, ref possibleMoves);

        //Down Left 
        KnightMove(CurrentX - 1, CurrentY - 2, ref possibleMoves);

        //Down Right 
        KnightMove(CurrentX + 1, CurrentY - 2, ref possibleMoves);

        //Left Up 
        KnightMove(CurrentX - 2, CurrentY + 1, ref possibleMoves);

        //Left Down 
        KnightMove(CurrentX - 2, CurrentY - 1, ref possibleMoves);

        return possibleMoves;
    }

    public void KnightMove(int x, int y, ref bool[,] possibleMoves)
    {
        Chessman pieceAtCurrentSpace;
        if (x >= 0 && x < 8 && y >= 0 && y < 8)
        {
            pieceAtCurrentSpace = BoardManager.instance.Chessmans[x, y];
            if (pieceAtCurrentSpace == null)
            {
                possibleMoves[x, y] = true;
            }
            else if (isWhite != pieceAtCurrentSpace.isWhite)
            {
                possibleMoves[x, y] = true;
            }

        }

    }
}
