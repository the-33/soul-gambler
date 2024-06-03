using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Vector3 downPos = new Vector3 (0, 0.122345f, 0f);
    public Vector3 upPos = new Vector3 (0, 77.12234f, 0f);
    public Vector3 target;

    public bool isDown = true;
    public bool isMooving = false;

    public float moovingSpeed;

    public bool activated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMooving)
        {
            transform.position = Vector3.MoveTowards(transform.position,new Vector3 (transform.position.x, target.y, transform.position.z), moovingSpeed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, new Vector2(transform.position.x, target.y)) < 0.1f)
        {
            isMooving = false;
            if(target == upPos)
            {
                isDown = false;
            }
            else if(target == downPos)
            {
                isDown = true;
            }
        }
    }

    public void GoUp()
    {
        if (isDown)
        {
            target = upPos;
            isMooving=true;
        }
    }

    public void GoDown()
    {
        if (!isDown)
        {
            target = downPos;
            isMooving=true;
        }
    }
}
