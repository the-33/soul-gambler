using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIcon : MonoBehaviour
{
    public Weapon weapon;

    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI weaponName;
    [SerializeField] private TextMeshProUGUI damage;
    [SerializeField] private TextMeshProUGUI strenghtScaling;
    [SerializeField] private TextMeshProUGUI dexterityScaling;
    [SerializeField] private TextMeshProUGUI critDamage;

    [SerializeField] private Equipment equipment;

    // Start is called before the first frame update
    void Start()
    {
        if(weapon != null)
        {
            icon.sprite = weapon.icon;
            if (weapon.weaponLevel != 0) weaponName.text = weapon.weaponName + " +" + weapon.weaponLevel; else weaponName.text = weapon.weaponName;
            damage.text = "Damage: " + weapon.weaponBaseDamage;
            strenghtScaling.text = "Str. scaling: " + weapon.StrScaling;
            dexterityScaling.text = "Dex. scaling: " + weapon.DexScaling;
            critDamage.text = "Crit. damage: " + weapon.CritDamage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Equip()
    {
        equipment.Equip(weapon);
    }
}
