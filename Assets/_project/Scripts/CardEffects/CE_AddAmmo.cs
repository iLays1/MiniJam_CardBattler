using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Card Effect/AddAmmo", fileName = "AddAmmo")]
public class CE_AddAmmo : CardEffect
{
    public int amount = 1;
    public override void OnUse()
    {
        PlayerResources.instance.AddAmmo(amount);
        ResourceUI.OnRefreshResourceUI.Invoke();
        if (amount > 0)
            AudioManager.instance.Play("Reload");
    }

    public override void ShowGuides()
    {
        var r = PlayerResources.instance;
        ResourceUI.instance.ammoText.text = $"Ammo:{Mathf.Clamp(r.ammo + amount, -100, r.maxAmmo)}/{r.maxAmmo}";

        if (amount < 0)
            ResourceUI.instance.ammoText.color = Color.red;
        if (amount > 0)
            ResourceUI.instance.ammoText.color = Color.green;
    }
    public override void HideGuides()
    {
        ResourceUI.instance.ammoText.color = Color.white;
        ResourceUI.OnRefreshResourceUI.Invoke();
    }

    public override bool IsUsable()
    {
        if(PlayerResources.instance.ammo + amount < 0)
        {
            return false;
        }

        return true;
    }
}
