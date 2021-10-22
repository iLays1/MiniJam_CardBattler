using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Card Effect/DrawCard", fileName = "DrawCard")]
public class CE_DrawCard : CardEffect
{
    public int amount = 1;
    public override void OnUse()
    {
        for (int i = 0; i < amount; i++)
        {
            PlayerDeck.instance.DrawCard();
        }
    }

    public override void ShowGuides()
    {
        //none
    }
    public override void HideGuides()
    {
        //none
    }

    public override bool IsUsable()
    {
        return true;
    }
}
