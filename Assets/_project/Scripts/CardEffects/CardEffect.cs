using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "New Card Effects/Card Effect", fileName = "CardEffect")]
public abstract class CardEffect : ScriptableObject
{
    public abstract void OnUse();
    public abstract void ShowGuides();
    public abstract void HideGuides();
    public abstract bool IsUsable();
}
