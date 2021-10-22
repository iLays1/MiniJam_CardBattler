using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public static PlayerResources instance;

    public int ammo;
    public int maxAmmo = 6;
    public int move;
    public int maxMove = 4;
    public int energy;
    public int maxEnergy = 3;

    private void Awake()
    {
        instance = this;
    }

    public void AddAmmo(int amount)
    {
        ammo += amount;
        ammo = Mathf.Clamp(ammo,0,maxAmmo);
        ResourceUI.OnRefreshResourceUI.Invoke();
    }
    public void AddMove(int amount)
    {
        move += amount;
        move = Mathf.Clamp(move, 0, maxMove);
        ResourceUI.OnRefreshResourceUI.Invoke();
    }
    public void AddEnergy(int amount)
    {
        energy += amount;
        energy = Mathf.Clamp(energy, 0, maxEnergy);
        ResourceUI.OnRefreshResourceUI.Invoke();
    }
}
