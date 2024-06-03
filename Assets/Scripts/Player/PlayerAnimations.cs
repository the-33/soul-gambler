using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator anim { get; private set; }
    public PlayerMovement mov { get; private set; }
    public PlayerAttack atk { get; private set; }

    public enum Weapons
    {
        Sword,
        Dagger,
        Zweihander,
        DoubleCurvedSwords,
        Spear,
        Halberd,
        GreatAxe,
    }

    public Weapons weapon = new Weapons();

    public bool startedJumping { private get; set; }
    public bool startedRolling { private get; set; }
    public bool attack {  private get; set; }
    public bool parry { private get; set; }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        mov = GetComponent<PlayerMovement>();
        atk = GetComponent<PlayerAttack>();
        weapon = Weapons.Sword;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("Weapon", (int)weapon);

        #region WALKING/RUNNING
        float animatorSpeed = Mathf.Abs(mov._moveInput.x);
        if (mov.IsRunning)
        {
            animatorSpeed *= mov.Data.runningMultiplier;
        }
        anim.SetFloat("Speed", animatorSpeed);
        #endregion

        #region ROLL
        anim.ResetTrigger("Roll");
        if (startedRolling)
        {
            startedRolling = false;
            if (!mov.IsRunning && mov._moveInput.x != 0)
            {
                anim.SetTrigger("Roll");
            }
        }
        #endregion

        #region JUMP
        if(startedJumping)
        {
            anim.SetTrigger("Jump");
            startedJumping = false;
        }

        anim.SetBool("OnGround", mov.IsOnGround);

        if (mov.RB.velocity.y > 0f)
        {
            anim.SetBool("Falling", false);
        }

        if (mov.RB.velocity.y <= 0f)
        {
            anim.SetBool("Falling", true);
        }
        #endregion

        #region CROUCH
        anim.SetBool("Crouching", mov.IsCrouching);
        #endregion

        #region SLIDE
        anim.SetBool("Sliding", mov.IsSliding);
        #endregion

        #region ATTACK
        if(attack)
        {
            anim.ResetTrigger("Attack");
            anim.SetTrigger("Attack");
            attack = false;
        }
        #endregion

        #region PARRY
        if(parry)
        {
            anim.ResetTrigger("Parry");
            anim.SetTrigger("Parry");
            parry = false;
        }
        #endregion
    }

    public void UpdateAttackBuffer()
    {
        atk.CheckBuffer();
    }
}
