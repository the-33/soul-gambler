using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerAnimations animationHandler;
    public UIController UI;

    public bool IsAttacking;
    private int attackBuffer = 0;
    public int maxBufferSize;
    private BoxCollider2D AttackCollider;
    public bool IsParrying;

    public Weapon handedWeapon;
    public Weapon equippedWeapon1;
    public Weapon equippedWeapon2;

    public bool changeWeapon;

    private void Start()
    {
        AttackCollider = transform.Find("Weapon").GetComponent<BoxCollider2D>();
        animationHandler = GetComponent<PlayerAnimations>();
        handedWeapon = equippedWeapon1;
    }

    private void Update()
    {
        #region ATTACK
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(attackBuffer < maxBufferSize && IsAttacking) attackBuffer++;
            if(!IsAttacking)
            {
                IsAttacking = true;
                Attack();
            }
        }
        #endregion

        #region PARRY
        if (Input.GetKeyDown(KeyCode.Mouse1) && !IsAttacking)
        {
            IsAttacking = true;
            Parry();
        }
        #endregion

        #region CHANGE WEAPON
        if(Input.mouseScrollDelta.y != 0)
        {
            if (!IsAttacking) ChangeWeapon(); else changeWeapon = true;
        }

        if(changeWeapon && !IsAttacking)
        {
            ChangeWeapon();
            changeWeapon = false;
        }
        #endregion
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
    }
    #endregion

    #region PARRY METHODS
    private void Parry()
    {
        animationHandler.parry = true;
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
        }
        else if(handedWeapon.weaponName == equippedWeapon2.weaponName)
        {
            handedWeapon = equippedWeapon1;
        }

        switch(handedWeapon.name)
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

        UI.SwitchWeapons(handedWeapon.name);
    }
}
