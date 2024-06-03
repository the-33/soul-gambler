using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon")]

public class Weapon:ScriptableObject
{
    public string weaponName;
    public Sprite icon;

    public int weaponBaseDamage;
    [Range(0, 5)] public int weaponLevel;

    #region SCALING
    public enum ScalingTiers
    {
        None = 0,
        E,
        D,
        C,
        B,
        A,
        S,
    }

    public ScalingTiers StrScaling;
    public ScalingTiers DexScaling;
    #endregion

    public int minStr;
    public int minDex;

    public int CritDamage;

    public int staminaCost;
}
