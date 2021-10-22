using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public PositionTile prefab;
    public int length;
    public List<PositionTile> positionTiles = new List<PositionTile>();

    private void Awake()
    {
        CreateTiles();
    }

    public void CreateTiles()
    {
        for (int i = 0; i < length; i++)
        {
            var go = Instantiate(prefab, transform);

            Vector3 pos = new Vector3(transform.position.x + i * 1.1f, transform.position.y);
            go.transform.position = pos;

            positionTiles.Add(go);
        }
    }
}
