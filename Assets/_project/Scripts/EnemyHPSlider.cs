using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPSlider : MonoBehaviour
{
    public CombatEnemy unit;
    public Slider slider;
    public TextMeshProUGUI hpText;

    private void Awake()
    {
        unit.OnHpChange.AddListener(UpdateUI);
        slider.maxValue = unit.hp;
        UpdateUI();
    }

    public void UpdateUI()
    {
        slider.value = unit.hp;
        hpText.text = unit.hp.ToString();
    }
}
