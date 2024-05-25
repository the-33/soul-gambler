using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon")]

public class Weapon:ScriptableObject
{
    public string weaponName;

    public int weaponDamage;
    public int staminaCost;
}
