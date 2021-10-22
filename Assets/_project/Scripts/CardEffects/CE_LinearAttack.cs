using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "New Card Effect/LinearAttack", fileName = "LinearAttack")]
public class CE_LinearAttack : CardEffect
{
    public int damage = 4;
    
    public override void OnUse()
    {
        var player = PlayerLaneUnit.instance;
        Lane pLane = LaneManager.instance.lanes[player.lanePos];
        CombatEnemy target = null;
        foreach (var t in pLane.positionTiles)
        {
            if(t.enemyInTile != null)
            {
                target = t.enemyInTile;
                break;
            }
        }

        player.transform.DOPunchPosition(Vector3.right * 0.2f, 0.2f);

        AudioManager.instance.Play("Shoot");
        target.TakeDamage(damage);
    }

    public override void ShowGuides()
    {
        Lane pLane = LaneManager.instance.lanes[PlayerLaneUnit.instance.lanePos];
        foreach (var t in pLane.positionTiles)
        {
            t.HighlightTile();
            if (t.enemyInTile != null)
            {
                break;
            }
        }
    }
    public override void HideGuides()
    {
        PositionTile.OnClearVisuals.Invoke();
    }

    public override bool IsUsable()
    {
        Lane pLane = LaneManager.instance.lanes[PlayerLaneUnit.instance.lanePos];
        foreach (var t in pLane.positionTiles)
        {
            if (t.enemyInTile != null)
                return true;
        }
        return false;
    }

}
