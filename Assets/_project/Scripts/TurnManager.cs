using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnManager : MonoBehaviour
{
    public static UnityEvent OnBattleWin = new UnityEvent();
    public static UnityEvent OnPlayerTurnStart = new UnityEvent();
    public static UnityEvent OnPlayerTurnEnd = new UnityEvent();

    PlayerDeck deck;
    CardHand hand;
    public List<EnemyBehavior> combatEnemies;
    public int drawAmount = 3;
    bool playerTurn = true;

    private void Awake()
    {
        PlayerLaneUnit.OnDeath.AddListener(GameOver);
        
    }
    private void Start()
    {
        combatEnemies = new List<EnemyBehavior>();
        foreach (var e in FindObjectsOfType<EnemyBehavior>())
        {
            combatEnemies.Add(e);
            e.enemySelf.OnDeath.AddListener(CheckForWin);
        }

        deck = FindObjectOfType<PlayerDeck>();
        hand = FindObjectOfType<CardHand>();

        StartTurn();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            EndTurn();
    }

    public void CheckForWin()
    {
        int unitCount = 0;
        foreach(var e in combatEnemies)
        {
            if (e != null)
                unitCount++;
        }

        if(unitCount <= 1)
        {
            PlayerLaneUnit.instance.canMove = false;
            playerTurn = false;
            OnBattleWin.Invoke();
        }
    }

    void GameOver()
    {
        playerTurn = false;
        StopAllCoroutines();
    }

    public void StartTurn()
    {
        StartCoroutine(StartTurnCoroutine());
    }
    IEnumerator StartTurnCoroutine()
    {
        PlayerResources.instance.AddEnergy(9999);
        for (int i = 0; i < drawAmount; i++)
        {
            deck.DrawCard();
            yield return new WaitForSeconds(0.1f);
        }

        playerTurn = true;
        OnPlayerTurnStart.Invoke();
    }
    public void EndTurn()
    {
        if (!playerTurn) return;

        AudioManager.instance.Play("EndTurn");

        playerTurn = false;
        StartCoroutine(EndTurnCoroutine());
    }
    IEnumerator EndTurnCoroutine()
    {
        hand.EmptyHand();
        OnPlayerTurnEnd.Invoke();

        combatEnemies.Sort((a,b) => a.enemySelf.x.CompareTo(b.enemySelf.x));

        foreach(var e in combatEnemies)
        {
            if (e == null)
                continue;
            
            int count = 0;
            while (count < 20)
            {
                if(e.Advance())
                {
                    break;
                }

                count++;
            }
            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds(0.3f);
        
        StartTurn();
    }
}
