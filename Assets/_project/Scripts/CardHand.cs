using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHand : MonoBehaviour
{
    public GameCard cardPrefab;
    public List<GameCard> cardsInHand;
    PlayerDeck deck;

    private void Start()
    {
        deck = GetComponent<PlayerDeck>();
    }

    public void CreateCard(CardData data)
    {
        var newCard = Instantiate(cardPrefab, this.transform);
        cardsInHand.Add(newCard);
        newCard.data = data;
        newCard.GetComponentInChildren<CardVisuals>().LoadCardData(data);
    }
    public void EmptyHand()
    {
        foreach(var card in cardsInHand)
        {
            if (card == null) continue;
            card.DiscardCard();
        }
        cardsInHand.Clear();
    }
}
