using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PositionTile : MonoBehaviour
{
    public static UnityEvent OnClearVisuals = new UnityEvent();
    public CombatEnemy enemyInTile;
    public SpriteRenderer colorTile;
    public Color highlightColor;
    Color oColor;

    private void Awake()
    {
        oColor = colorTile.color;
        OnClearVisuals.AddListener(() => colorTile.color = oColor);
    }

    public void HighlightTile()
    {
        colorTile.color = highlightColor;
    }
}
