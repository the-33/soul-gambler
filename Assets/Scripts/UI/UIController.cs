using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private PlayerStats playerst;
    [SerializeField] private PlayerAttack playerat;

    #region ICONS
    [SerializeField] private GameObject WeaponsIcon;
    [SerializeField] private GameObject ItemsIcon;
    public Image Cross;
    #endregion

    #region STAMINA AND HEALTH
    [SerializeField] private Image staminaFrame;
    [SerializeField] private Image staminaFillBack;
    [SerializeField] private Image staminaFillColor;

    [SerializeField] private Image healthFrame;
    [SerializeField] private Image healthFillBack;
    [SerializeField] private Image healthFillColor;
    #endregion

    #region MENU
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject MenuEquip;
    [SerializeField] private GameObject MenuItems;
    [SerializeField] private GameObject MenuStats;
    #endregion

    #region STATS
    [SerializeField] private GameObject Level;
    [SerializeField] private GameObject Coins;
    [SerializeField] private GameObject CoinsCorner;
    [SerializeField] private GameObject Vitality;
    [SerializeField] private GameObject Endurance;
    [SerializeField] private GameObject Strenght;
    [SerializeField] private GameObject Dexterity;
    [SerializeField] private GameObject Luck;
    [SerializeField] private GameObject HP;
    [SerializeField] private GameObject Stamina;
    [SerializeField] private GameObject Weapon1;
    [SerializeField] private GameObject Weapon2;
    #endregion

    public bool MenuActive { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if(!Menu.activeSelf)
        //    {
        //        ShowMenu();
        //        MenuActive = true;
        //    }
        //    else
        //    {
        //        CloseMenu();
        //        MenuActive= false;
        //    }
        //}

        CoinsCorner.GetComponent<TextMeshProUGUI>().text = playerst.coins.ToString();
    }

    public void UpdateStats()
    {
        Level.GetComponent<TextMeshProUGUI>().text = "Level: " + playerst.level;
        Coins.GetComponent<TextMeshProUGUI>().text = "Dry Eyes: " + playerst.coins;
        Vitality.GetComponent<TextMeshProUGUI>().text = "Vitality: " + playerst.vitality;
        Endurance.GetComponent<TextMeshProUGUI>().text = "Endurance: " + playerst.endurance;
        Strenght.GetComponent<TextMeshProUGUI>().text = "Strenght: " + playerst.strength;
        Dexterity.GetComponent<TextMeshProUGUI>().text = "Dexterity: " + playerst.dexterity;
        Luck.GetComponent<TextMeshProUGUI>().text = "Luck: " + playerst.luck;
        HP.GetComponent<TextMeshProUGUI>().text = "HP: " + playerst.health + "/" + playerst.maxHealth;
        Stamina.GetComponent<TextMeshProUGUI>().text = "Stamina: " + playerst.maxStamina;
        Weapon1.GetComponent<TextMeshProUGUI>().text = "R Weapon: " + playerat.Weapon1Damage;
        Weapon2.GetComponent<TextMeshProUGUI>().text = "L Weapon: " + playerat.Weapon2Damage;
    }

    public void ShowMenu()
    {
        Menu.SetActive(true);
    }

    public void CloseMenu()
    {
        Menu.SetActive(false);
    }

    public void ShowMenuEquip()
    {
        MenuEquip.SetActive(true);
        MenuStats.SetActive(false);
        MenuItems.SetActive(false);
    }

    public void ShowMenuStats() 
    {
        MenuEquip.SetActive(false);
        MenuStats.SetActive(true);
        MenuItems.SetActive(false);
        UpdateStats();
    } 

    public void ShowMenuItems()
    {
        MenuEquip.SetActive(false);
        MenuStats.SetActive(false);
        MenuItems.SetActive(true);
    }

    public void SwitchWeapons(string name)
    {
        for(int i = 0; i<WeaponsIcon.transform.childCount; i++)
        {
            if(WeaponsIcon.transform.GetChild(i).gameObject.name != "Flash" && WeaponsIcon.transform.GetChild(i).gameObject.name != "Cruz") WeaponsIcon.transform.GetChild(i).gameObject.SetActive(false);
        }
        StartCoroutine(nameof(FlashWeapons));
        WeaponsIcon.transform.Find(name).gameObject.SetActive(true);
    }

    IEnumerator FlashWeapons()
    {
        WeaponsIcon.transform.Find("Flash").gameObject.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        WeaponsIcon.transform.Find("Flash").gameObject.GetComponent<Image>().enabled = false;
    }

    public void UpdateStamina(float stamina, int maxStamina)
    {
        staminaFrame.gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 6*maxStamina);
        staminaFillBack.gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 6*maxStamina+10);
        staminaFillColor.fillAmount = stamina / maxStamina;
    }

    public void UpdateHealth(float health, int maxHealth)
    {
        healthFrame.gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 6 * maxHealth);
        healthFillBack.gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 6 * maxHealth + 10);
        healthFillColor.fillAmount = health / maxHealth;
    }
}
