using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapMask : MonoBehaviour
{
    //-- UnityTilemapMask - Open source repo hosted on github
    //-- License: MIT

    public GameObject maskCell;
    [HideInInspector]
    public GameObject maskParentObj; // Must be public for correct handling of game/editor destroying

    public void GenerateMask()
    {
        Tilemap tilemap = GetComponent<Tilemap>();

        Vector3Int startCoord = tilemap.origin;
        Vector3Int size = tilemap.size;

        // Destroy old mask if needed
        if (maskParentObj != null)
        {
            if (Application.isEditor)
            {
                DestroyImmediate(maskParentObj);
                maskParentObj = null;
            }
            else Destroy(maskParentObj);
        }

        maskParentObj = new GameObject("TilemapMask");
        maskParentObj.transform.parent = transform;

        //Iterate over each cell
        for (int x = startCoord.x; x < startCoord.x + size.x; x++)
        {
            for (int y = startCoord.y; y < startCoord.y + size.y; y++)
            {
                //Check if cell isn't empty
                if (tilemap.GetTile(new Vector3Int(x, y, startCoord.z)) != null)
                {
                    //Create maskCell on the cell coords
                    Vector3 coord = tilemap.CellToWorld(new Vector3Int(x, y, startCoord.z)) + new Vector3(0.5f, 0.5f, 0);
                    GameObject cell = Instantiate(maskCell, coord, Quaternion.identity, maskParentObj.transform);
                    cell.GetComponent<SpriteMask>().sprite = tilemap.GetSprite(new Vector3Int(x, y, startCoord.z));
                }
            }
        }
    }
}

