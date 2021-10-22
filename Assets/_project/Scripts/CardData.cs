using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardDataEvent : UnityEvent<CardData> { }

[CreateAssetMenu(menuName = "new Card Data", fileName = "CardData")]
public class CardData : ScriptableObject
{
    public static CardDataEvent OnCardDiscarded = new CardDataEvent();

    public string cardName;
    public int cardCost = 1;
    [TextArea]
    public string cardDesc;
    public Sprite cardImage;

    public CardEffect[] effects;
}
