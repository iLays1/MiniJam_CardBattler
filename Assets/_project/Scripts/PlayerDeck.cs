using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class PlayerDeck : MonoBehaviour
{
    public static PlayerDeck instance;
    public List<CardData> startingCards;
    public CardHand hand;

    public TextMeshProUGUI deckText;
    public TextMeshProUGUI discardText;

    Stack<CardData> cards;
    List<CardData> discardedCards = new List<CardData>();

    System.Random rnd = new System.Random();

    private void Awake()
    {
        instance = this;
        CardData.OnCardDiscarded.AddListener(CardPlayed);
        hand = GetComponent<CardHand>();
    }
    private void Start()
    {
        cards = new Stack<CardData>();
        foreach (CardData t in startingCards)
            cards.Push(t);

        Debug.Log(cards.Count);

        ShuffleDeck();
        UpdateUi();
    }
    
    public CardData DrawCard()
    {
        AudioManager.instance.Play("Draw");
        if (cards.Count <= 0)
            ShuffleDeck();
        if (cards.Count <= 0)
        {
            Debug.Log("No Discard! No cards to shuffle!");
            return null;
        }

        var cardData = cards.Pop();
        hand.CreateCard(cardData);
        UpdateUi();

        return cardData;
    }

    public void CardPlayed(CardData card)
    {
        discardedCards.Add(card);
        UpdateUi();
    }
    
    public void ShuffleDeck()
    {
        List<CardData> newDeck = new List<CardData>();

        foreach (var c in discardedCards)
        {
            newDeck.Add(c);
        }
        foreach (var c in cards)
        {
            newDeck.Add(c);
        }

        discardedCards.Clear();

        var array = newDeck.ToArray();
        CustomUtility.Shuffle(array);

        cards = new Stack<CardData>();
        foreach (CardData t in array)
            cards.Push(t);

        UpdateUi();
    }

    void UpdateUi()
    {
        deckText.text = cards.Count.ToString();
        discardText.text = discardedCards.Count.ToString();
    }
}
