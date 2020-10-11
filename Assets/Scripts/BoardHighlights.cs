using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardHighlights : MonoBehaviour
{
    public static BoardHighlights instance { set; get; }

    public GameObject highlightPrefab;

    private List<GameObject> highlights;

    private void Start()
    {
        instance = this;
        highlights = new List<GameObject>();
    }

    private GameObject GetHighlightObject()
    {
        //This function takes in a predicate that returns a game object 
        //Aka it searches `highlights` for the first object
        GameObject go = highlights.Find(g => !g.activeSelf);

        if (go == null)
        {
            go = Instantiate(highlightPrefab);
            highlights.Add(go);
        }

        return go;
    }

    public void HighlightAllowedMoves(bool[,] moves)
    {
        //Loop over every square in the board 
        for (int i = 0; i < BoardManager.BOARD_SIZE; i++)
        {
            for (int j = 0; j < BoardManager.BOARD_SIZE; j++)
            {
                bool isAnAllowedMove = moves[i, j];
                if (isAnAllowedMove)
                {
                    GameObject go = GetHighlightObject();
                    go.SetActive(true);
                    go.transform.position = new Vector3(i + BoardManager.TILE_OFFSET, 0, j + BoardManager.TILE_OFFSET);
                }
            }
        }
    }

    public void HideHighlights()
    {
        foreach (GameObject go in highlights)
            go.SetActive(false);
    }
}
