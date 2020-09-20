using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    private const float TILE_SIZE = 1.0f;
    private const float TILE_OFFSET = 0.5f;

    private int selectionX = -1;
    private int selectionY = -1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DrawChessboard();
        UpdateSelection();
    }

    private void DrawChessboard()
    {
        Vector3 widthLine = Vector3.right * 8;
        Vector3 heigthLine = Vector3.forward * 8;

        for (int i = 0; i <= 8; i++)
        {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine(start, start + widthLine);
            for (int j = 0; j <= 8; j++)
            {
                start = Vector3.right * j;
                Debug.DrawLine(start, start + heigthLine);
            }
        }

        // Draw the selection - selX and selY get updated every frame by UpdateSelection()
        //  Notes: 
        //      - Y in this context refers to Y on the chess board, but in the game world it is actually Z. 
        //      - Adding vectors together adds the X's, Y's and Z's separately. For instance (0,0,1) + (1,0,0) = (1,0,1)
        if (selectionX >= 0 && selectionY >= 0)
        {
            Debug.Log("selectionY" + selectionY);
            Debug.Log("forward * Y: " + Vector3.forward * selectionY);
            //Debug.Log("right * X: " + Vector3.right * selectionX);
            //Debug.Log("Added together: " + (Vector3.forward * selectionY + Vector3.right * selectionX));
            //Draw an X
            //Draw top right to bottom left 

            Vector3 

            Vector3 bottomLeftCornerOfBox = Vector3.forward * selectionY + Vector3.right * selectionX;

            Debug.DrawLine(
                Vector3.forward * selectionY + Vector3.right * selectionX,
                Vector3.forward * (selectionY + 1) + Vector3.right * (selectionX + 1));

            //Draw top left to bottom right 
            // Debug.DrawLine(
            //     Vector3.forward * selectionY + Vector3.right * selectionX,
            //     Vector3.forward * (selectionY + 1) + Vector3.right * (selectionX + 1));
        }
    }

    private void UpdateSelection()
    {
        if (!Camera.main)
        {
            return;
        }

        RaycastHit hit;
        Ray mouseLocationRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float maxDistance = 25.0f;
        int chessPlaneLayerMask = LayerMask.GetMask("ChessPlane");

        //The 'out' keyword is used for passing a reference to an object, rather than the object itself.
        //  I'm not 100% sure, but I think hit gets populated with information by the RayCast function
        //  which we will use after. 
        bool mouseHitsChessLayer = Physics.Raycast(mouseLocationRay, out hit, maxDistance, chessPlaneLayerMask);

        if (mouseHitsChessLayer)
        {
            selectionX = (int)hit.point.x;
            selectionY = (int)hit.point.z;
        }
        //Reset the coordinates if we  are not on the chess layer 
        else
        {
            selectionX = -1;
            selectionY = -1;
        }
    }
}
