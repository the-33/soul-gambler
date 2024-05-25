using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health;
    public float stamina;
    public int maxHealth;
    public int maxStamina;
    public bool outOfStamina;

    public int vitality;
    public int endurance;
    public int strength;
    public int dexterity;
    public int luck;

    private PlayerMovement mov;
    private PlayerAnimations anim;
    private PlayerAttack atk;
    [SerializeField] private UIController UI;
    [SerializeField] private PlayerData Data;

    // Start is called before the first frame update
    void Start()
    {
        mov = GetComponent<PlayerMovement>();
        anim = GetComponent<PlayerAnimations>();
        atk = GetComponent<PlayerAttack>();

        UI.UpdateStamina(stamina, maxStamina);
        UI.UpdateHealth(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        #region STAMINA
        if (mov.IsRunning && stamina > 0)
        {
            stamina -= (Time.deltaTime * Data.staminaCostRunning);
            if(stamina < 0)
            { 
                stamina = 0; 
                outOfStamina = true;
            }
            UI.UpdateStamina(stamina, maxStamina);
        }
        
        if(!mov.IsRunning && !mov.IsDashAnimation && stamina < maxStamina)
        {
            stamina += Time.deltaTime * Data.staminaRegen;
            if(stamina > maxStamina)
            {
                stamina = maxStamina;
            }
            UI.UpdateStamina(stamina, maxStamina);
        }

        if(stamina >= maxStamina*0.75f)
        {
            outOfStamina = false;
        }
        #endregion
    }

    #region STAMINA METHODS
    public void DropStamina(float amount)
    {
        if(stamina - amount >= 0)
        {
            stamina -= amount;
        }
        else
        {
            outOfStamina = true;
            stamina = 0;
        }
        UI.UpdateStamina(stamina, maxStamina);
    }
    #endregion

    #region HEALTH METHODS
    public void DropHealth(int amount)
    {
        if (health - amount >= 0)
        {
            health -= amount;
        }
        else
        {
            mov.Die();
        }
        UI.UpdateHealth(health, maxHealth);
    }

    public void RiseHealth(int amount)
    {
        if (health + amount <= maxHealth)
        {
            health += amount;
        }
        else
        {
            health = maxHealth;
        }
        UI.UpdateHealth(health, maxHealth);
    }
    #endregion
}
