using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int health {  get; private set; }
    public float stamina { get; private set; }
    [Header("Health and stamina")]
    public int maxHealth;
    public int maxStamina;

    public bool outOfStamina {  get; private set; }
    public bool ableToRun { get; private set; }

    [Header("Atributes")]
    public int vitality;
    public int endurance;
    public int strength;
    public int dexterity;
    public int luck;

    public int level {  get; private set; }
    public int coins { get; private set; }
    public float timer { get; private set; } = 0f;

    public PlayerMovement mov { get; private set; }
    public PlayerAnimations anim { get; private set; }
    public PlayerAttack atk { get; private set; }
    [SerializeField] private UIController UI;
    [SerializeField] private PlayerData Data;

    [SerializeField] private float timeToResetStamina;
    private float staminaResetCounter;

    // Start is called before the first frame update
    void Start()
    {
        mov = GetComponent<PlayerMovement>();
        anim = GetComponent<PlayerAnimations>();
        atk = GetComponent<PlayerAttack>();

        UI.UpdateStamina(stamina, maxStamina);
        UI.UpdateHealth(health, maxHealth);

        health = maxHealth;
        stamina = maxStamina;
        UI.UpdateStamina(stamina, maxStamina);
        UI.UpdateHealth(health, maxHealth);
        ableToRun = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        coins = (int)timer;

        if(coins > 9999999)
        {
            IEnumerator ChangLevel()
            {
                float fadeTime = GameObject.Find("Fadings").GetComponent<Fading>().BeginFade(1);
                yield return new WaitForSeconds(fadeTime);
                SceneManager.LoadScene(0);
            }

            StartCoroutine(ChangLevel());
        }

        ////#region STAMINA
        //if (mov.IsRunning && stamina > 0 && mov.IsOnGround)
        //{
        //    stamina -= (Time.deltaTime * Data.staminaCostRunning);
        //    UI.UpdateStamina(stamina, maxStamina);
        //}

        //if (stamina <= 0 && !outOfStamina)
        //{
        //    stamina = 0;
        //    outOfStamina = true;
        //    ableToRun = false;
        //    staminaResetCounter = timeToResetStamina;
        //    UI.UpdateStamina(stamina, maxStamina);
        //}

        //if (!mov.IsRunning && !mov.IsDashAnimation && !atk.IsAttacking && stamina < maxStamina && !outOfStamina)
        //{
        //    stamina += Time.deltaTime * Data.staminaRegen;
        //    if (stamina > maxStamina)
        //    {
        //        stamina = maxStamina;
        //    }
        //    UI.UpdateStamina(stamina, maxStamina);
        //}        

        //if(outOfStamina)
        //{
        //    if(staminaResetCounter > 0)
        //    {
        //        staminaResetCounter -= Time.deltaTime;
        //    }
        //    else
        //    {
        //        staminaResetCounter = 0;
        //        outOfStamina = false;
        //        stamina += Time.deltaTime * Data.staminaRegen;
        //    }
        //}

        //if(!ableToRun && !outOfStamina && (stamina >= 4 || !Input.GetKey(KeyCode.LeftShift)))
        //{
        //    ableToRun=true;
        //}
        //#endregion
    }

    #region STAMINA METHODS
    public void DropStamina(float amount)
    {
        //if(stamina - amount >= 0)
        //{
        //    stamina -= amount;
        //}
        //else
        //{
        //    stamina = 0;
        //    outOfStamina = true;
        //    staminaResetCounter = timeToResetStamina;
        //}
        //UI.UpdateStamina(stamina, maxStamina);
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
