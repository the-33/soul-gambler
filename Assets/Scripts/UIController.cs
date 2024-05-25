using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject WeaponsIcon;

    [SerializeField] private Image staminaFrame;
    [SerializeField] private Image staminaFillBack;
    [SerializeField] private Image staminaFillColor;

    [SerializeField] private Image healthFrame;
    [SerializeField] private Image healthFillBack;
    [SerializeField] private Image healthFillColor;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchWeapons(string name)
    {
        for(int i = 0; i<WeaponsIcon.transform.childCount; i++)
        {
            WeaponsIcon.transform.GetChild(i).gameObject.GetComponent<Image>().enabled = false;
        }
        StartCoroutine(nameof(FlashWeapons));
        WeaponsIcon.transform.Find(name).gameObject.GetComponent<Image>().enabled = true;
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
