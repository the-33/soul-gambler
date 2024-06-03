using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCloser : MonoBehaviour
{
    private bool mouse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1)) && !mouse)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnMouseEnter()
    {
        mouse = true;
    }

    private void OnMouseExit()
    {
        mouse= false;
    }
}
