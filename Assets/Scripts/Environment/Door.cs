using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool closed = true;
    public bool PlayerIn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerIn && Input.GetKeyDown(KeyCode.E) && GameObject.Find("Player").GetComponent<PlayerInventory>().key && closed)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Open");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            closed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player") PlayerIn = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player") PlayerIn = false;
    }
}
