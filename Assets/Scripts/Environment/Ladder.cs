using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ladder : MonoBehaviour
{
    public Transform Top;
    public bool PlayerIn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerIn) StartCoroutine(nameof(Climb), GameObject.Find("Player"));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player") PlayerIn = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player") PlayerIn = false;
    }

    IEnumerator Climb(GameObject gm)
    {
        float fadeTime = GameObject.Find("Fadings").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        gm.transform.position = Top.position;
        GameObject.Find("Fadings").GetComponent<Fading>().BeginFade(-1);
    }
}
