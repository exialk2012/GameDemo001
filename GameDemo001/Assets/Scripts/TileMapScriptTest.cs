using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapScriptTest : MonoBehaviour
{
    Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3Int vector = tilemap.WorldToCell(ray.GetPoint(-ray.origin.z / ray.direction.z));
            print($"{vector}：{tilemap.HasTile(vector)}");
            if (tilemap.HasTile(vector))
            {
                tilemap.SetColor(vector, Color.black);
            }
        }

    }
}
