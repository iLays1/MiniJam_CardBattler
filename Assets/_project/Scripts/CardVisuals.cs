using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardVisuals : MonoBehaviour
{
    public Image cardImage;
    public TextMeshProUGUI cardName;
    public TextMeshProUGUI cardDesc;
    public TextMeshProUGUI cardCost;

    public void LoadCardData(CardData data)
    {
        cardImage.sprite = data.cardImage;
        cardName.text = data.cardName;
        cardDesc.text = data.cardDesc;
        cardCost.text = data.cardCost.ToString();
    }
}
