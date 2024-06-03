using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PlayerAnimations;

public class Equipment : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private GameObject SelectPanel;
    [SerializeField] private GameObject WeaponTemplate;
    [SerializeField] private GameObject scrollRect;

    [SerializeField] private Image Weapon1Icon;
    [SerializeField] private Image Weapon2Icon;

    [SerializeField] private PlayerAttack atk;

    public bool arma1;
    public bool arma2;

    // Start is called before the first frame update
    void Start()
    {
        Weapon1Icon.sprite = atk.equippedWeapon1.icon;
        Weapon2Icon.sprite = atk.equippedWeapon2.icon;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ClosePanel()
    {
        SelectPanel.SetActive(false);
    }

    public void EquipHand1()
    {
        ShowPanelWithWeapons();
        arma1 = true;
        arma2 = false;
    }

    public void EquipHand2() 
    {
        ShowPanelWithWeapons();
        arma1 = false;
        arma2 = true;
    }

    public void Equip(Weapon weapon)
    {
        if(arma1)
        {
            atk.equippedWeapon1 = weapon;
            Weapon1Icon.sprite = weapon.icon;
            if(atk.handedWeaponNum == 1) atk.handedWeapon = weapon; atk.UI.SwitchWeapons(weapon.weaponName);
        }

        if(arma2)
        {
            atk.equippedWeapon2 = weapon;
            Weapon2Icon.sprite = weapon.icon;
            if (atk.handedWeaponNum == 2) atk.handedWeapon = weapon; atk.UI.SwitchWeapons(weapon.weaponName);
        }
        ClosePanel();
    }

    private void ShowPanelWithWeapons()
    {
        SelectPanel.SetActive(true);

        foreach (Transform child in scrollRect.transform)
        {
            if (child.gameObject == WeaponTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach (Weapon weapon in inventory.weaponsInventory)
        {
            GameObject weaponIcon = Instantiate(WeaponTemplate, WeaponTemplate.transform.parent);
            weaponIcon.SetActive(true);
            weaponIcon.GetComponent<WeaponIcon>().weapon = weapon;
        }
    }
}
