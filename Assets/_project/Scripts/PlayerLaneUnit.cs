using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLaneUnit : MonoBehaviour
{
    public static UnityEvent OnDeath = new UnityEvent();
    public static PlayerLaneUnit instance;

    public int lanePos;
    public int hp = 20;
    [HideInInspector]
    public UnityEvent OnHpChange = new UnityEvent();

    public SpriteRenderer playerRend;
    public Sprite downSprite;
    public bool canMove = true;

    LaneManager laneManager;
    PlayerResources resources;

    private void Start()
    {
        instance = this;
        resources = PlayerResources.instance;
        laneManager = FindObjectOfType<LaneManager>();
        SetPos(lanePos);

        TurnManager.OnPlayerTurnStart.AddListener(() => canMove = true);
        TurnManager.OnPlayerTurnEnd.AddListener(() => canMove = false);
    }

    private void Update()
    {
        if (!canMove) return;

        if (Input.GetKeyDown(KeyCode.W))
            MoveInDir(1);
        if (Input.GetKeyDown(KeyCode.S))
            MoveInDir(-1);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        AudioManager.instance.Play("PHit");

        transform.DOComplete();
        transform.DOPunchPosition(Vector3.left * 0.5f, 0.4f);

        if (hp <= 0)
        {
            hp = 0;
            Kill();
        }

        OnHpChange.Invoke();
    }
    public void Kill()
    {
        StartCoroutine(LoseCoroutine());
    }
    IEnumerator LoseCoroutine()
    {
        AudioManager.instance.Play("PDeath");
        canMove = false;
        playerRend.sprite = downSprite;
        OnDeath.Invoke();
        yield return new WaitForSeconds(3f);
        SceneLoader.instance.LoadScene(0, 4f);
    }

    private void MoveInDir(int dir)
    {
        if (resources.move < 1)
            return;
        resources.AddMove(-1);
        SetPos(lanePos + dir);
    }

    public void SetPos(int index)
    {
        if (index > laneManager.lanes.Length-1)
            return;

        if (index < 0)
            return;

        AudioManager.instance.Play("Move");
        lanePos = index;
        transform.DOMoveY(laneManager.lanes[index].transform.position.y, 0.2f);
    }
}
