using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour
{
    public float delay2 = 14;
    void Start()
    {
        StartCoroutine(LoadMenuAfterDelay(delay2));
    }

    IEnumerator LoadMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("MenuBeatEmAll");
    }
}
