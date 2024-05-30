using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpeedBoostData
{
    public float BoostFactor;
    public float Duration;

    public SpeedBoostData(float boostFactor, float duration)
    {
        BoostFactor = boostFactor;
        Duration = duration;
    }
}
