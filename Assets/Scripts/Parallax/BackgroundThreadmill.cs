using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundThreadmill : MonoBehaviour
{
    public List<Transform> backgrounds = new List<Transform>();
    public Transform cameraTransform;

    [SerializeField] private float offset;

    // Start is called before the first frame update
    void Start()
    {
        if(cameraTransform == null)
            cameraTransform = Camera.main.transform;
        foreach(Transform child in transform)
        {
            backgrounds.Add(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (backgrounds[0].position.x < cameraTransform.position.x - backgrounds[0].gameObject.GetComponent<SpriteRenderer>().bounds.size.x + offset)
        {
            backgrounds[0].position = new Vector3(backgrounds[2].position.x + (backgrounds[0].gameObject.GetComponent<SpriteRenderer>().bounds.size.x + offset), backgrounds[2].position.y, backgrounds[2].position.z);
            Transform auxiliary = backgrounds[0];
            backgrounds.Remove(backgrounds[0]);
            backgrounds.Insert(2, auxiliary);
        }

        if (backgrounds[2].position.x > cameraTransform.position.x + backgrounds[0].gameObject.GetComponent<SpriteRenderer>().bounds.size.x + offset)
        {
            backgrounds[2].position = new Vector3(backgrounds[0].position.x - (backgrounds[0].gameObject.GetComponent<SpriteRenderer>().bounds.size.x + offset), backgrounds[2].position.y, backgrounds[2].position.z);
            Transform auxiliary = backgrounds[2];
            backgrounds.Remove(backgrounds[2]);
            backgrounds.Insert(0, auxiliary);
        }
    }
}
