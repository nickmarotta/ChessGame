using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Chessman
{
    public override bool[,] PossibleMove()
    {

        bool[,] possibleMoves = new bool[8, 8];
        Chessman c, c2;
        bool isPieceInLeftColumn = CurrentX == 0;
        bool isPieceInRightColumn = CurrentX == 7;
        int[] enPassant = BoardManager.instance.EnPassantMove;


        // White team move 
        if (isWhite)
        {
            //Diagonal Left
            if (!isPieceInLeftColumn)
            {
                //EnPassant Move 
                if (enPassant[0] == CurrentX - 1 && enPassant[1] == CurrentY + 1)
                    possibleMoves[CurrentX - 1, CurrentY + 1] = true;

                //If space to diagonal left is not empty AND the piece is black 
                //  then move is possible 
                c = BoardManager.instance.Chessmans[CurrentX - 1, CurrentY + 1];
                if (c != null && !c.isWhite)
                    possibleMoves[CurrentX - 1, CurrentY + 1] = true;
            }
            //Diagonal Right
            if (!isPieceInRightColumn)
            {
                //EnPassant Move 
                if (enPassant[0] == CurrentX + 1 && enPassant[1] == CurrentY + 1)
                    possibleMoves[CurrentX + 1, CurrentY + 1] = true;

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
            if (!isPieceInLeftColumn)
            {
                //EnPassant Move 
                if (enPassant[0] == CurrentX + 1 && enPassant[1] == CurrentY - 1)
                    possibleMoves[CurrentX + 1, CurrentY - 1] = true;

                //If space to diagonal left is not empty AND the piece is white 
                //  then move is possible 
                c = BoardManager.instance.Chessmans[CurrentX - 1, CurrentY - 1];
                if (c != null && c.isWhite)
                    possibleMoves[CurrentX - 1, CurrentY - 1] = true;
            }
            //Diagonal Right
            if (!isPieceInRightColumn)
            {
                //EnPassant Move 
                if (enPassant[0] == CurrentX - 1 && enPassant[1] == CurrentY - 1)
                    possibleMoves[CurrentX - 1, CurrentY - 1] = true;

                //If space to diagonal right is not empty AND the piece is white 
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
