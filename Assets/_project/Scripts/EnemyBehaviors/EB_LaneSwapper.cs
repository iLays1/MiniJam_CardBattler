using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EB_LaneSwapper : EnemyBehavior
{
    public int power;

    public override bool Advance()
    {
        if(enemySelf.x - 1 < 0)
        {
            transform.DOPunchPosition(Vector3.left * 0.2f, 0.2f);
            PlayerLaneUnit.instance.TakeDamage(power);
            return true;
        }

        return enemySelf.SetPos(enemySelf.x - 1, Random.Range(0, laneManager.lanes.Length));
    }
}
