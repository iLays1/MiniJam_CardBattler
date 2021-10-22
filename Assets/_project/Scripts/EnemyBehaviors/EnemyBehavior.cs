using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehavior : MonoBehaviour
{
    protected LaneManager laneManager;
    public CombatEnemy enemySelf;

    public abstract bool Advance();

    protected virtual void Start()
    {
        laneManager = FindObjectOfType<LaneManager>();
        enemySelf = GetComponent<CombatEnemy>();
    }
}
