using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Chessman
{
    public override bool[,] PossibleMove()
    {

        //TODO: I think the logic in this function can be simplified. Idt you can go diagonal left or right 
        // when you're in the left column or the right column. Only one of the coords matters. 
        bool[,] possibleMoves = new bool[8, 8];
        Chessman c, c2;

        // White team move 
        if (isWhite)
        {
            //Diagonal Left
            bool isPieceOnTopLeftCorner = CurrentX == 0 && CurrentY == 7;
            if (!isPieceOnTopLeftCorner)
            {
                //If space to diagonal left is not empty AND the piece is black 
                //  then move is possible 
                c = BoardManager.instance.Chessmans[CurrentX - 1, CurrentY + 1];
                if (c != null && !c.isWhite)
                    possibleMoves[CurrentX - 1, CurrentY + 1] = true;
            }
            //Diagonal Right
            bool isPieceOnTopRightCorner = CurrentX == 7 && CurrentY == 7;
            if (!isPieceOnTopRightCorner)
            {
                //If space to diagonal right is not empty AND the piece is black 
                //  then move is possible 
                c = BoardManager.instance.Chessmans[CurrentX + 1, CurrentY + 1];
                if (c != null && !c.isWhite)
                    possibleMoves[CurrentX + 1, CurrentY + 1] = true;
            }
            //Middle
            bool isTopOfBoard = CurrentY == 7; //Promotion point 
            if (!isTopOfBoard)
            {
                //Can only move forward if no one is directly in front of us 
                c = BoardManager.instance.Chessmans[CurrentX, CurrentY + 1];
                if (c == null)
                    possibleMoves[CurrentX, CurrentY + 1] = true;

            }

            //Middle on first move 
            bool isFirstMove = CurrentY == 1; //Pawns can't go backwards, and can go 2 spaces on first move - so this should work  
            if (isFirstMove)
            {
                //Can only move forward if no one is directly in front of us 
                c = BoardManager.instance.Chessmans[CurrentX, CurrentY + 1];
                c2 = BoardManager.instance.Chessmans[CurrentX, CurrentY + 2];

                if (c == null && c2 == null)
                    possibleMoves[CurrentX, CurrentY + 2] = true;

            }
        }
        // Black pieces move in the other direction
        else
        {
            //Diagonal Left
            bool isPieceOnBottomLeftCorner = CurrentX == 0 && CurrentY == 0;
            if (!isPieceOnBottomLeftCorner)
            {
                //If space to diagonal left is not empty AND the piece is black 
                //  then move is possible 
                c = BoardManager.instance.Chessmans[CurrentX - 1, CurrentY - 1];
                if (c != null && c.isWhite)
                    possibleMoves[CurrentX - 1, CurrentY - 1] = true;
            }
            //Diagonal Right
            bool isPieceOnTopRightCorner = CurrentX == 7 && CurrentY == 0;
            if (!isPieceOnTopRightCorner)
            {
                //If space to diagonal right is not empty AND the piece is black 
                //  then move is possible 
                c = BoardManager.instance.Chessmans[CurrentX + 1, CurrentY - 1];
                if (c != null && c.isWhite)
                    possibleMoves[CurrentX + 1, CurrentY - 1] = true;
            }
            //Middle
            bool isTopOfBoard = CurrentY == 7; //Promotion point 
            if (!isTopOfBoard)
            {
                //Can only move forward if no one is directly in front of us 
                c = BoardManager.instance.Chessmans[CurrentX, CurrentY - 1];
                if (c == null)
                    possibleMoves[CurrentX, CurrentY - 1] = true;

            }

            //Middle on first move 
            bool isFirstMove = CurrentY == 6; //Pawns can't go backwards, and can go 2 spaces on first move - so this should work  
            if (isFirstMove)
            {
                //Can only move forward if no one is directly in front of us 
                c = BoardManager.instance.Chessmans[CurrentX, CurrentY - 1];
                c2 = BoardManager.instance.Chessmans[CurrentX, CurrentY - 2];

                if (c == null && c2 == null)
                    possibleMoves[CurrentX, CurrentY - 2] = true;

            }
        }

        return possibleMoves;
    }
}
