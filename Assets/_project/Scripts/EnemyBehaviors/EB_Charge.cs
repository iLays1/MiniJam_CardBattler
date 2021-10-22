using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EB_Charge : EnemyBehavior
{
    public int power;

    public override bool Advance()
    {
        if (enemySelf.x - 1 < 0)
        {
            transform.DOPunchPosition(Vector3.left * 0.2f, 0.2f);
            PlayerLaneUnit.instance.TakeDamage(power);
            return true;
        }

        bool moved = false;

        if (enemySelf.SetPos(enemySelf.x - 1, enemySelf.laneIndex))
        {
            moved = true;
        }
        if (enemySelf.SetPos(enemySelf.x - 1, enemySelf.laneIndex))
        {
            moved = true;
        }

        return moved;
    }
}
