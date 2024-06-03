using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Elevator elevator;

    public bool activatorlever;
    public bool PlayerIn;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerIn && Input.GetKeyDown(KeyCode.E) && !elevator.isMooving && (activatorlever || elevator.activated))
        {
            transform.localScale *= new Vector2(-1, 1);
            elevator.activated = true;
            StartCoroutine(nameof(use));
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

    IEnumerator use()
    {
        yield return new WaitForSeconds(1f);
        elevator.GoUp();
        elevator.GoDown();
    }
}
