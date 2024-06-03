using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject win;
    public GameObject score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            win.SetActive(true);
            score.GetComponent<TextMeshProUGUI>().text = "Tiempo: " + collision.GetComponent<PlayerStats>().coins;
        }
    }
}
