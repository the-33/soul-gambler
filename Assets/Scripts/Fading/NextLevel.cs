using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{

    public string levelToLoad;


    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(nameof(ChangLevel));
    }
    IEnumerator ChangLevel()
    {
        float fadeTime = GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(0);
    }
}
