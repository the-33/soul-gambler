using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerAnimations animationHandler { get; private set; }
    public UIController UI;
    public PlayerStats Stats { get; private set; }

    public bool IsAttacking;
    private int attackBuffer = 0;
    public int maxBufferSize;
    private BoxCollider2D AttackCollider;
    public bool IsParrying;

    public Weapon handedWeapon;
    public Weapon equippedWeapon1;
    public Weapon equippedWeapon2;

    public int handedWeaponNum;

    private bool changeWeapon;
    private bool parry;

    public int Weapon1Damage { get; private set; }
    public int Weapon2Damage { get; private set; }

    private void Start()
    {
        AttackCollider = transform.Find("Weapon").GetComponent<BoxCollider2D>();
        animationHandler = GetComponent<PlayerAnimations>();
        Stats = GetComponent<PlayerStats>();
        handedWeapon = equippedWeapon1;
        handedWeaponNum = 1;
    }

    private void Update()
    {
        if (!UI.MenuActive)
        {
            //#region ATTACK
            //if (Input.GetKeyDown(KeyCode.Mouse0) && !Stats.outOfStamina && handedWeapon.minDex <= Stats.dexterity && handedWeapon.minStr <= Stats.strength)
            //{
            //    if (attackBuffer < maxBufferSize && IsAttacking) attackBuffer++;
            //    if (!IsAttacking)
            //    {
            //        IsAttacking = true;
            //        Attack();
            //    }
            //}
            //#endregion

            //#region PARRY
            //if (Input.GetKeyDown(KeyCode.Mouse1) && !Stats.outOfStamina)
            //{
            //    if (!IsAttacking)
            //    {
            //        IsAttacking = true;
            //        Parry();
            //    }
            //    else parry = true;
            //}

            //if (parry && !IsAttacking)
            //{
            //    IsAttacking = true;
            //    Parry();
            //    parry = false;
            //}
            //#endregion

            //#region CHANGE WEAPON
            //if (Input.mouseScrollDelta.y != 0)
            //{
            //    if (!IsAttacking) ChangeWeapon(); else changeWeapon = true;
            //}

            //if (changeWeapon && !IsAttacking)
            //{
            //    ChangeWeapon();
            //    changeWeapon = false;
            //}
            //#endregion
        }
    }

    #region ATTACK METHODS
    public void CheckBuffer()
    {
        if (attackBuffer > 0)
        {
            Attack();
            attackBuffer--;
        }
        else
        {
            IsAttacking = false;
            attackBuffer = 0;
            AttackCollider.enabled = false;
        }
    }

    private void Attack()
    {
        AttackCollider.enabled = true;
        animationHandler.attack = true;
        Stats.DropStamina(handedWeapon.staminaCost);
    }
    #endregion

    #region PARRY METHODS
    private void Parry()
    {
        animationHandler.parry = true;
        Stats.DropStamina(0.5f);
    }

    public void EndParry()
    {
        IsAttacking = false;
        CheckBuffer();
    }

    public IEnumerator ParryTime()
    {
        IsParrying = true;
        yield return new WaitForSeconds(0.25f);
        IsParrying = false;
    }
    #endregion

    private void ChangeWeapon()
    {
        if(handedWeapon.weaponName == equippedWeapon1.weaponName)
        {
            handedWeapon = equippedWeapon2;
            handedWeaponNum = 2;
        }
        else if(handedWeapon.weaponName == equippedWeapon2.weaponName)
        {
            handedWeapon = equippedWeapon1;
            handedWeaponNum = 1;
        }

        switch(handedWeapon.weaponName)
        {
            case "Sword":
                animationHandler.weapon = PlayerAnimations.Weapons.Sword;
                break;
            case "Dagger":
                animationHandler.weapon = PlayerAnimations.Weapons.Dagger;
                break;
            case "Zweihander":
                animationHandler.weapon = PlayerAnimations.Weapons.Zweihander;
                break;
            case "Double Curved Swords":
                animationHandler.weapon = PlayerAnimations.Weapons.DoubleCurvedSwords;
                break;
            case "Spear":
                animationHandler.weapon = PlayerAnimations.Weapons.Spear;
                break;
            case "Halberd":
                animationHandler.weapon = PlayerAnimations.Weapons.Halberd;
                break;
            case "GreatAxe":
                animationHandler.weapon = PlayerAnimations.Weapons.GreatAxe;
                break;
        }

        if(handedWeapon.minDex > Stats.dexterity || handedWeapon.minStr > Stats.strength)
        {
            UI.Cross.enabled = true;
        }
        else
        {
            UI.Cross.enabled = false;
        }

        UI.SwitchWeapons(handedWeapon.weaponName);
    }

    public void UpdateWeaponsDamage()
    {
        Weapon1Damage = equippedWeapon1.weaponBaseDamage + equippedWeapon1.weaponLevel*2;
    }
}
