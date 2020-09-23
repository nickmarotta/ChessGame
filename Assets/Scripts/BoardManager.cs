using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{

    enum Chessmen
    {
        WHITE_KING,
        WHITE_QUEEN,
        WHITE_ROOK,
        WHITE_BISHOP,
        WHITE_KNIGHT,
        WHITE_PAWN,
        BLACK_KING,
        BLACK_QUEEN,
        BLACK_ROOK,
        BLACK_BISHOP,
        BLACK_KNIGHT,
        BLACK_PAWN
    }

    //We're initializing a multi dimensional array here 
    public Chessman[,] Chessmans { set; get; }
    private Chessman selectedChessman;

    private const float TILE_SIZE = 1.0f;
    private const float TILE_OFFSET = 0.5f;

    private int selectionX = -1;
    private int selectionY = -1;

    public List<GameObject> chessmanPrefabs;
    public List<GameObject> activeChessman;

    public bool isWhiteTurn = true;

    // Start is called before the first frame update
    void Start()
    {
        SpawnAllChessmen();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSelection();
        DrawChessboard();

        bool leftClick = Input.GetMouseButtonDown(0);
        bool clickedOnBoard = selectionX >= 0 && selectionY >= 0;
        if (leftClick)
        {
            if (clickedOnBoard)
            {
                if (selectedChessman == null)
                {
                    SelectChessman(selectionX, selectionY);
                }
                else
                {
                    MoveChessman(selectionX, selectionY);
                }
            }
        }
    }

    private void SelectChessman(int x, int y)
    {

        if (Chessmans[x, y] == null)
            return;
        if (Chessmans[x, y].isWhite != isWhiteTurn)
            return;

        selectedChessman = Chessmans[x, y];

    }

    private void MoveChessman(int x, int y)
    {
        if (selectedChessman.PossibleMove(x, y))
        {
            Chessmans[selectedChessman.CurrentX, selectedChessman.CurrentY] = null;
            selectedChessman.transform.position = GetTileCenter(x, y);
            Chessmans[x, y] = selectedChessman;
        }

        selectedChessman = null;
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

            //Get Corners of selected space 
            Vector3 bottomLeft = Vector3.forward * selectionY + Vector3.right * selectionX;
            Vector3 topRight = Vector3.forward * (selectionY + 1) + Vector3.right * (selectionX + 1);
            Vector3 topLeft = Vector3.forward * (selectionY + 1) + Vector3.right * selectionX;
            Vector3 bottomRight = Vector3.forward * selectionY + Vector3.right * (selectionX + 1);


            Debug.DrawLine(bottomLeft, topRight);
            Debug.DrawLine(topLeft, bottomRight);
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

    /**
        Spawn a chess man on the board. 

        @param index - refers to which chessman to get in the chessmanPrefabs list 
        @param x - x board coord
        @param y - y board coord
    */
    private void SpawnChessman(int chessmanIndex, int x, int y)
    {
        //Not sure why this randomly broke, but I need to rotate the pieces separately now. 
        GameObject chessman;
        Quaternion eulerRotation = Quaternion.Euler(0, 180, 0);
        if (chessmanIndex <= 5)
            //Don't flip white 
            chessman = Instantiate(chessmanPrefabs[chessmanIndex], GetTileCenter(x, y), Quaternion.identity) as GameObject;
        else
            //Flip black
            chessman = Instantiate(chessmanPrefabs[chessmanIndex], GetTileCenter(x, y), eulerRotation) as GameObject;

        chessman.transform.SetParent(transform);
        Chessman chessmanScriptComponent = chessman.GetComponent<Chessman>() as Chessman;
        chessmanScriptComponent.SetPosition(x, y);
        Chessmans[x, y] = chessmanScriptComponent;
        activeChessman.Add(chessman);
    }

    private void SpawnAllChessmen()
    {
        activeChessman = new List<GameObject>();
        Chessmans = new Chessman[8, 8];

        SpawnChessman((int)Chessmen.WHITE_KING, 3, 0);
        SpawnChessman((int)Chessmen.WHITE_QUEEN, 4, 0);
        SpawnChessman((int)Chessmen.WHITE_ROOK, 0, 0);
        SpawnChessman((int)Chessmen.WHITE_ROOK, 7, 0);
        SpawnChessman((int)Chessmen.WHITE_BISHOP, 2, 0);
        SpawnChessman((int)Chessmen.WHITE_BISHOP, 5, 0);
        SpawnChessman((int)Chessmen.WHITE_KNIGHT, 1, 0);
        SpawnChessman((int)Chessmen.WHITE_KNIGHT, 6, 0);
        for (int column = 0; column < 8; column++)
            SpawnChessman((int)Chessmen.WHITE_PAWN, column, 1);
        SpawnChessman((int)Chessmen.BLACK_KING, 4, 7);
        SpawnChessman((int)Chessmen.BLACK_QUEEN, 3, 7);
        SpawnChessman((int)Chessmen.BLACK_ROOK, 0, 7);
        SpawnChessman((int)Chessmen.BLACK_ROOK, 7, 7);
        SpawnChessman((int)Chessmen.BLACK_BISHOP, 2, 7);
        SpawnChessman((int)Chessmen.BLACK_BISHOP, 5, 7);
        SpawnChessman((int)Chessmen.BLACK_KNIGHT, 1, 7);
        SpawnChessman((int)Chessmen.BLACK_KNIGHT, 6, 7);
        for (int column = 0; column < 8; column++)
            SpawnChessman((int)Chessmen.BLACK_PAWN, column, 6);

    }

    //Turn board coordinates into a Vector3 (world coordinates)
    private Vector3 GetTileCenter(int x, int y)
    {
        Vector3 origin = Vector3.zero;
        origin.x += (TILE_SIZE * x) + TILE_OFFSET;
        origin.z += (TILE_SIZE * y) + TILE_OFFSET;
        return origin;
    }
}
