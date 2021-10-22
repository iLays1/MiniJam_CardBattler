using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    public static LaneManager instance;
    public PlayerLaneUnit playerLaneUnit;
    public Lane[] lanes;

    private void Awake()
    {
        instance = this;
    }
}
