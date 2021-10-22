using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Card Effect/AddMove", fileName = "AddMove")]
public class CE_AddMove : CardEffect
{
    public int amount = 1;
    public override void OnUse()
    {
        AudioManager.instance.Play("GainMove");

        PlayerResources.instance.AddMove(amount);
        ResourceUI.OnRefreshResourceUI.Invoke();
    }

    public override void ShowGuides()
    {
        var r = PlayerResources.instance;
        ResourceUI.instance.moveText.text = $"Move:{Mathf.Clamp(r.move + amount, -100, r.maxMove)}/{r.maxMove}";

        if (amount < 0)
            ResourceUI.instance.moveText.color = Color.red;
        if (amount > 0)
            ResourceUI.instance.moveText.color = Color.green;
    }
    public override void HideGuides()
    {
        ResourceUI.instance.moveText.color = Color.white;
        ResourceUI.OnRefreshResourceUI.Invoke();
    }

    public override bool IsUsable()
    {
        return true;
    }
}
