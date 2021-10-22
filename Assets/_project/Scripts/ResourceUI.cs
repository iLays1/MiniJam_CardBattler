using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ResourceUI : MonoBehaviour
{
    public static ResourceUI instance;
    public static UnityEvent OnRefreshResourceUI = new UnityEvent();

    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI moveText;
    public TextMeshProUGUI energyText;

    private void Awake()
    {
        instance = this;
        OnRefreshResourceUI.AddListener(RefreshUI);
        CardData.OnCardDiscarded.AddListener((CardData c) => RefreshUI());
    }
    private void Start()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        var r = PlayerResources.instance;
        ammoText.text = $"Ammo:{r.ammo}/{r.maxAmmo}";
        ammoText.color = Color.white;
        moveText.text = $"Move:{r.move}/{r.maxMove}";
        moveText.color = Color.white;
        energyText.text = $"Energy:{r.energy}/{r.maxEnergy}";
        energyText.color = Color.white;
    }
}
