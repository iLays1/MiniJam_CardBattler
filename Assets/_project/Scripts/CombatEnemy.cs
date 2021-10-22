using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CombatEnemy : MonoBehaviour
{
    public UnityEvent OnDeath = new UnityEvent();
    public UnityEvent OnHpChange = new UnityEvent(); 
    public LaneManager laneManager;
    public PositionTile parentTile;
    public Transform spriteContainer;

    public int laneIndex;
    public int x;

    public int hp = 10;

    private void Awake()
    {
        laneManager = FindObjectOfType<LaneManager>();
    }
    private void Start()
    {
        SetPos(x,laneIndex);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        spriteContainer.DOPunchPosition(Vector3.right * 0.4f, 0.3f);

        if(hp <= 0)
        {
            hp = 0;
            Kill();
        }

        OnHpChange.Invoke();
    }
    public void Kill()
    {
        AudioManager.instance.Play("EDeath");
        OnDeath.Invoke();
        parentTile.enemyInTile = null;
        Destroy(gameObject);
    }
    
    public bool SetPos(int newX, int index = -1)
    {
        if (index == -1)
            index = laneIndex;

        if (index > laneManager.lanes.Length - 1)
            return false;
        if (index < 0)
            return false;
        if (newX > laneManager.lanes[0].positionTiles.Count - 1)
            return false;
        if (newX < 0)
            return false;

        var newTile = laneManager.lanes[index].positionTiles[newX];

        if (newTile.enemyInTile != null)
            return false;

        if (parentTile != null)
        {
            parentTile.enemyInTile = null;
        }

        AudioManager.instance.Play("Move");
        x = newX;
        laneIndex = index;

        parentTile = laneManager.lanes[index].positionTiles[newX];
        parentTile.enemyInTile = this;

        transform.DOMove(parentTile.transform.position, 0.2f);

        return true;
    }
}